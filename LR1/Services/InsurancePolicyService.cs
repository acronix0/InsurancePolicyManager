using System.Globalization;
using LR1.Views;

namespace LR1.Services
{
    internal class InsurancePolicyService
    {
        private static List<InsurancePolicy> policies = new List<InsurancePolicy>();
        private ConsoleView view;
        public InsurancePolicyService(ConsoleView view)
        {
            this.view = view;
        }
        public void Init()
        {
            view.PrintTitle("Система учета страховых полисов");

            bool exit = false;
            while (!exit)
            {
                view.PrintInfo("Выберите действие:");
                view.PrintInfo("1. Добавить страховой полис");
                view.PrintInfo("2. Добавить полис ОМС");
                view.PrintInfo("3. Добавить полис на жильё");
                view.PrintInfo("4. Отобразить все полисы");
                view.PrintInfo("5. Поиск полиса");
                view.PrintInfo("6. Выйти");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddPolicy();
                        break;
                    case "2":
                        AddMedicalInsurance();
                        break;
                    case "3":
                        AddHousingInsurance();
                        break;
                    case "4":
                        PrintPolicies();
                        break;
                    case "5":
                        Search();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        view.PrintError("Некорректный ввод, попробуйте снова.");
                        break;
                }
            }
            return;
        }
        private void printMedicalInsurance(MandatoryMedicalInsurance police)
        {
            view.PrintInfo($"Полис страхования №:{police.Id}");
            view.PrintInfo($"Владелец :{police.OwnerSurname} {police.OwnerName} {police.OwnerLastName}");
            view.PrintInfo($"Дата рождения :{police.Birthday.ToShortDateString()}");
            view.PrintInfo("------------------------------------------------------");
        }
        private void printPolicy(InsurancePolicy police)
        {
            view.PrintInfo($"Полис страхования №:{police.Id}");
            view.PrintInfo($"Владелец :{police.OwnerSurname} {police.OwnerName} {police.OwnerLastName}");
            view.PrintInfo($"Дата рождения :{police.Birthday.ToShortDateString()}");
            view.PrintInfo("------------------------------------------------------");
        }
        private void printHousingInsurance(HousingInsurance police)
        {
            view.PrintInfo($"Полис страхования №:{police.Id}");
            view.PrintInfo($"Владелец :{police.OwnerSurname} {police.OwnerName} {police.OwnerLastName}");
            view.PrintInfo($"Дата рождения :{police.Birthday.ToShortDateString()}");
            view.PrintInfo($"Адрес :{police.ResidentialAddress}");
            view.PrintInfo($"Страховая стоимость :{police.Price}");
            view.PrintInfo("------------------------------------------------------");
        }
        private InsurancePolicy createPolicy()
        {
            view.PrintInfo("Добавление нового страхового полиса");

            long id;
            while (!long.TryParse(view.Prompt("Введите ID полиса: "), out id))
                view.PrintError("Некорректный ввод. Введите числовой ID полиса: ");

            string ownerName = view.Prompt("Введите имя владельца: ");
            string ownerSurname = view.Prompt("Введите фамилию владельца: ");
            string ownerLastName = view.Prompt("Введите отчество владельца: ");
            string dateString = view.Prompt("Введите дату рождения владельца (dd.MM.yyyy): ");

            DateTime birthday;
            while (!DateTime.TryParseExact(dateString, "dd.MM.yyyy", null, DateTimeStyles.None, out birthday))
            {
                Console.Write("Некорректный ввод. Введите дату в формате dd.MM.yyyy: ");
            }

            return new InsurancePolicy(id, ownerName, ownerSurname, ownerLastName, birthday);
        }
        private void AddPolicy()
        {
            policies.Add(createPolicy());
            view.PrintInfo("Страховой полис добавлен.\n");
        }

        private void PrintPolicies()
        {
            foreach (var policy in policies)
            {
                if (policy is MandatoryMedicalInsurance)
                    printMedicalInsurance((MandatoryMedicalInsurance)policy);
                else if (policy is HousingInsurance)
                    printHousingInsurance((HousingInsurance)policy);
                else
                    printPolicy(policy);
            }
        }

        private void AddMedicalInsurance()
        {
            policies.Add(MandatoryMedicalInsurance.Clone(createPolicy()));
            view.PrintInfo("Полис ОМС добавлен.");
        }

        private void AddHousingInsurance()
        {
            var policy = createPolicy();
            string adress = view.Prompt("Введите адрес жилья: ");

            decimal price;
            while (!decimal.TryParse(view.Prompt("Введите страховую стоимость: "), NumberStyles.Any, new CultureInfo("ru-RU"), out price))
                view.PrintError("Некорректный ввод. страховую стоимость в формате 123.456: ");

            policies.Add(HousingInsurance.Clone(policy, adress, price));

            view.PrintInfo("Полис страхования жилья добавлен.");
        }
        
        private void Search()
        {
            List<InsurancePolicy> result;
            var housingInsurances = policies.OfType<HousingInsurance>().ToList();

            var input = view.Prompt("Введите фамилию, имя, отчество владельца или номер полиса: ");

            policies.Where(p => p.Concat().Contains(input)).ToList().ForEach(policy =>
            {
                if (policy is MandatoryMedicalInsurance)
                    printMedicalInsurance((MandatoryMedicalInsurance)policy);
                else if (policy is HousingInsurance)
                    printHousingInsurance((HousingInsurance)policy);
                else
                    printPolicy(policy);
            });
        }
    }
}

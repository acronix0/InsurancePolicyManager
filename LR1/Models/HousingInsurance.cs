using LR1;
using System.Diagnostics;

public class HousingInsurance : InsurancePolicy, IModel
{
    public string ResidentialAddress { get; set; }
    public decimal Price { get; set; }
    public HousingInsurance(long id, string ownerName, string ownerSurname, string ownerLastName, DateTime birthday, string residentialAddress, decimal price)
               : base(id, ownerName, ownerSurname, ownerLastName, birthday)
    {
        ResidentialAddress = residentialAddress;
        Price = price;
    }
    public static HousingInsurance GetInstance()        
    {
        return  new HousingInsurance(0, string.Empty, string.Empty, string.Empty, new DateTime(), string.Empty, decimal.Zero);
    }

    internal static HousingInsurance Clone(InsurancePolicy insurancePolicy, string residentialAddress, decimal price)
    {
        return new HousingInsurance(insurancePolicy.Id, insurancePolicy.OwnerName, insurancePolicy.OwnerSurname, insurancePolicy.OwnerLastName, insurancePolicy.Birthday, residentialAddress, price);
    }
    public override string ToString() => "Полис страхования жилья";
    public override string Concat() => base.Concat() + ResidentialAddress;
}
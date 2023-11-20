using LR1;

public class InsurancePolicy: IModel
{
    public long Id { get; set; }
    public string OwnerName { get; set; }
    public  string OwnerSurname { get; set; }
    public string OwnerLastName { get; set; }
    private DateTime birthday { get; set; }
    public DateTime Birthday
    {
        get => birthday;
        set
        {
            var age = DateTime.Now.Year - value.Year;
            if (age > 0 && age < 110) birthday = value;
        }
    }
    
    public InsurancePolicy(long id, string ownerName, string ownerSurname, string ownerLastName, DateTime birthday)
    {
        Id = id;
        OwnerName = ownerName;
        OwnerSurname = ownerSurname;
        OwnerLastName = ownerLastName;
        Birthday = birthday;
    }
    public override string ToString()
    {
        return "Страховой полис";
    }

    public virtual string Concat() => Id + OwnerName + OwnerSurname + OwnerLastName;

}

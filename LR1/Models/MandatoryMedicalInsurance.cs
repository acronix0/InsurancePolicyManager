public class MandatoryMedicalInsurance: InsurancePolicy
{
    public MandatoryMedicalInsurance(long id, string ownerName, string ownerSurname, string ownerLastName, DateTime birthday)
               : base(id, ownerName, ownerSurname, ownerLastName, birthday){}

    internal static MandatoryMedicalInsurance Clone(InsurancePolicy insurancePolicy)
    {
        return new MandatoryMedicalInsurance(insurancePolicy.Id, insurancePolicy.OwnerName, insurancePolicy.OwnerSurname, insurancePolicy.OwnerLastName, insurancePolicy.Birthday);
    }

    public override string ToString() => "Полис ОМС";

    public override string Concat() => base.Concat();
}


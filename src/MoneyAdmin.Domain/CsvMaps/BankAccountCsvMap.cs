using CsvHelper.Configuration;

namespace MoneyAdmin.Domain.CsvMaps
{
    public class BankAccountCsvMap : ClassMap<BankAccount>
    {
        public BankAccountCsvMap()
        {
            Map(m => m.Name)
                .Name("Name")
                .Validate(field =>
                    !string.IsNullOrWhiteSpace(field) &&
                    !(field.Length < 2) &&
                    !(field.Length > 60));

            Map(m => m.Balance)
                .Name("Balance");
        }
    }
}

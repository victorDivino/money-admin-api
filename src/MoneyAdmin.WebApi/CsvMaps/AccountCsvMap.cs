using CsvHelper.Configuration;
using MoneyAdmin.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyAdmin.WebApi.CsvMaps
{
    public class AccountCsvMap : ClassMap<Account>
    {
        public AccountCsvMap()
        {
            Map(m => m.Name)
                .Name("Name")
                .Validate(field =>
                    !string.IsNullOrWhiteSpace(field) &&
                    !(field.Length < 2) &&
                    !(field.Length > 100));

            Map(m => m.Amount).Name("Amount");
        }
    }
}

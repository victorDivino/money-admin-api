using System;

namespace MoneyAdmin.WebApi.ViewModels
{
    public sealed class BankAccountViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}

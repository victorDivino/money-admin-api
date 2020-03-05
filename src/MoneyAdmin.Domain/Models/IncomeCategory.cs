namespace MoneyAdmin.Domain.Models
{
    public sealed class IncomeCategory : Category
    {
        private IncomeCategory() { }

        public IncomeCategory(string name) : base(name)
        {
        }
    }
}
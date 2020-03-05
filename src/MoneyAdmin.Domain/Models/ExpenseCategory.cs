namespace MoneyAdmin.Domain.Models
{
    public sealed class ExpenseCategory : Category
    {
        private ExpenseCategory() { }

        public ExpenseCategory(string name)
            : base(name)
        {
        }
    }
}
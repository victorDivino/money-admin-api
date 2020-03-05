using MoneyAdmin.Domain.Interfaces;
using MoneyAdmin.Domain.Models;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public sealed class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(MoneyAdminContext context) : base(context)
        {
        }
    }
}

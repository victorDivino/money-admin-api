using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(MoneyAdminContext context) : base(context)
        {
        }
    }
}

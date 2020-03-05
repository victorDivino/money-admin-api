using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public class AccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        public AccountRepository(MoneyAdminContext context) : base(context)
        {
        }
    }
}

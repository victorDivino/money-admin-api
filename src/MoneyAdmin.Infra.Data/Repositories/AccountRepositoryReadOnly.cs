using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public class AccountRepositoryReadOnly : RepositoryReadOnly<BankAccount>, IBankAccountRepositoryReadOnly
    {
        public AccountRepositoryReadOnly(MoneyAdminContext context) : base(context)
        {
        }
    }
}

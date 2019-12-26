using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public class AccountRepositoryReadOnly : RepositoryReadOnly<Account>, IAccountRepositoryReadOnly
    {
        public AccountRepositoryReadOnly(MoneyAdminContext context) : base(context)
        {
        }
    }
}

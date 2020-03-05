using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public class BankAccountRepositoryReadOnly : RepositoryReadOnly<BankAccount>, IBankAccountRepositoryReadOnly
    {
        public BankAccountRepositoryReadOnly(MoneyAdminContext context) : base(context)
        {
        }
    }
}

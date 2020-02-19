using System;
using MoneyAdmin.Domain.Interfaces;
using MoneyAdmin.Infra.Data.Repositories;

namespace MoneyAdmin.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoneyAdminContext _context;
        private IAccountRepository accountRepository;

        public UnitOfWork(MoneyAdminContext context)
        {
            _context = context;
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(_context);

                return accountRepository;
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Commit();
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

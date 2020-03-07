using System;
using MoneyAdmin.Domain.Interfaces;
using MoneyAdmin.Infra.Data.Repositories;

namespace MoneyAdmin.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoneyAdminContext _context;
        private IBankAccountRepository bankAccountRepository;
        private IExpenseRepository expenseRepository;

        public UnitOfWork(MoneyAdminContext context)
        {
            _context = context;
        }

        public IBankAccountRepository BankAccountRepository
        {
            get
            {
                if (bankAccountRepository == null)
                    bankAccountRepository = new BankAccountRepository(_context);

                return bankAccountRepository;
            }
        }

        public IExpenseRepository ExpenseRepository
        {
            get
            {
                if (expenseRepository == null)
                    expenseRepository = new ExpenseRepository(_context);

                return expenseRepository;
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

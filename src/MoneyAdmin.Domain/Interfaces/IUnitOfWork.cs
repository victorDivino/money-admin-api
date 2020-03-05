using System;

namespace MoneyAdmin.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBankAccountRepository AccountRepository { get; }
        IExpenseRepository ExpenseRepository { get; }

        int Commit();
    }
}
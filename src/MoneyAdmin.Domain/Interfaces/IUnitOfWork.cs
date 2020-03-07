using System;

namespace MoneyAdmin.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBankAccountRepository BankAccountRepository { get; }
        IExpenseRepository ExpenseRepository { get; }

        int Commit();
    }
}
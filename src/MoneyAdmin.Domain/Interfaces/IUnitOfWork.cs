using System;

namespace MoneyAdmin.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        int Commit();
    }
}
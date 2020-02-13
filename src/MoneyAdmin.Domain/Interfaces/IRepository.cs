using System;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        T GetById(Guid id);
        void Save();
    }
}

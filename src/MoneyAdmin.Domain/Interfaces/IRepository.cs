using System;
using System.Collections.Generic;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        T GetById(Guid id);
    }
}

using MoneyAdmin.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MoneyAdmin.Domain.Interfaces
{
    public interface IRepositoryReadOnly<T> where T : Entity
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Interfaces
{
    public interface IRepositoryReadOnly<T> where T : Entity
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
    }
}

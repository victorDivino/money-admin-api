using System;
using System.Collections.Generic;
using System.Linq;
using MoneyAdmin.Domain.Core.Models;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public class RepositoryReadOnly<T> : IRepositoryReadOnly<T> where T : Entity
    {
        private readonly MoneyAdminContext _context;

        public RepositoryReadOnly(MoneyAdminContext context)
        {
            _context = context;
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}

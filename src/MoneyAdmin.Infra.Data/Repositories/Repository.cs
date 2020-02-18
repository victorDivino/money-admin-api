using System;
using System.Collections.Generic;
using System.Linq;
using MoneyAdmin.Domain.Core.Models;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly MoneyAdminContext _context;

        public Repository(MoneyAdminContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(m => m.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

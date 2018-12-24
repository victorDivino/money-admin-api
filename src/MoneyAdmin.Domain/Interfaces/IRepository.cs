using MoneyAdmin.Domain.Core.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyAdmin.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task Add(T entity);
        Task<Entity> GetById(ObjectId id);
        Task<List<T>> GetAll();
    }
}

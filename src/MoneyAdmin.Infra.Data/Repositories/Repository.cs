using Canducci.MongoDB.Repository.MongoAttribute;
using MoneyAdmin.Domain.Core.Models;
using MoneyAdmin.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected string CollectionName
        {
            get
            {
                var dnAttribute = typeof(T).GetCustomAttributes(typeof(MongoCollectionName), true).FirstOrDefault() as MongoCollectionName;
                return dnAttribute?.TableName;
            }
        }
        private readonly MoneyAdminContext _context;

        public Repository(MoneyAdminContext context) => _context = context;

        public Task Add(T entity)
            => _context.Database.GetCollection<T>(CollectionName).InsertOneAsync(entity);

        public Task<List<T>> GetAll()
            => _context.Database.GetCollection<T>(CollectionName).Find(new BsonDocument()).ToListAsync();

        public async Task<Entity> GetById(ObjectId id)
        {
            var query = Builders<T>.Filter.Eq(e => e._id, id);
            var cursor = await _context.Database.GetCollection<T>(CollectionName).FindAsync(query);
            return await cursor.FirstOrDefaultAsync();
        }
    }
}

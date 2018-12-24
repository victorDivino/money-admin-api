using Canducci.MongoDB.Repository.MongoAttribute;
using MoneyAdmin.Domain.Core.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace MoneyAdmin.Domain
{
    [MongoCollectionName("accounts")]
    public class Account : Entity
    {
        public Account(string name)
        {
            Name = name;
        }

        [BsonRequired()]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("amount")]
        public decimal Amount { get; set; }
    }
}

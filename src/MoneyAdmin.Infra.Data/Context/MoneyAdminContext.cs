using MongoDB.Driver;
using System;

namespace MoneyAdmin.Infra.Data
{
    public class MoneyAdminContext
    {
        public IMongoDatabase Database { get; }

        public MoneyAdminContext(MongoClient mongoClient)
        {
            try
            {
                Database = mongoClient.GetDatabase("moneyadmin");
            }
            catch (Exception ex)
            {
                throw new Exception("Could not connect to server.", ex);
            }
        }
    }
}

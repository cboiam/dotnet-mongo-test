using DotnetMongoTest.Infra.Interfaces;
using MongoDB.Driver;

namespace DotnetMongoTest.Infra
{
    public class MongoContext : IMongoContext
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;

        public MongoContext()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("dotnetMongoTest");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return database.GetCollection<T>(name);
        }
    }
}
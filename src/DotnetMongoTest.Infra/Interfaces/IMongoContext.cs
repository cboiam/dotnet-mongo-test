using MongoDB.Driver;

namespace DotnetMongoTest.Infra.Interfaces
{
    public interface IMongoContext
    {
         IMongoCollection<T> GetCollection<T>(string name);
    }
}
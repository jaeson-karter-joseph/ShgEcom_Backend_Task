using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShgEcom.Domain.Entites;

namespace ShgEcom.Infrastructure.Persistence.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    }
}

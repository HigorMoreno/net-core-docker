using Catalog.API.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Infrastructure
{
    public class CatalogContext
    {
        private readonly IMongoDatabase _database = null;

        public CatalogContext(IOptions<CatalogSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Product> Product
        {
            get
            {
                return _database.GetCollection<Product>("Product");
            }
        }
    }
}

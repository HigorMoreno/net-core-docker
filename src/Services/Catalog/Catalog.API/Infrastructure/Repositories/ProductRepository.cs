using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.API.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly CatalogContext _context;

        public ProductRepository(IOptions<CatalogSettings> settings)
        {
            _context = new CatalogContext(settings);
        }

        public async Task AddProductAsync(Product item)
        {
            await _context.Product.InsertOneAsync(item);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Product.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProductAsync(string id)
        {
            ObjectId internalId = GetInternalId(id);
            return await _context.Product
                            .Find(p => p.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveProductAsync(string id)
        {
            DeleteResult actionResult = await _context.Product.DeleteOneAsync(
                     Builders<Product>.Filter.Eq("Id", id));

            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        #region Private

        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
        #endregion
    }
}

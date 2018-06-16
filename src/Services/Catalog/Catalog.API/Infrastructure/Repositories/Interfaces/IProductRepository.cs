using Catalog.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(string id);
        Task AddProductAsync(Product item);
        Task<bool> RemoveProductAsync(string id);
    }
}

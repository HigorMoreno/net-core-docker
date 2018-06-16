using Catalog.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(string id);
        Task AddProductAsync(Product item);
        Task<bool> RemoveProductAsync(string id);
    }
}

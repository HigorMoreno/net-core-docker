using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Infrastructure.Repositories;
using Catalog.API.Model;

namespace Catalog.API.Infrastructure.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task AddProductAsync(Product item) => await _productRepository.AddProductAsync(item);

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _productRepository.GetAllProductsAsync();
        
        public async Task<Product> GetProductAsync(string id) => await _productRepository.GetProductAsync(id);

        public async Task<bool> RemoveProductAsync(string id) => await _productRepository.RemoveProductAsync(id);
    }
}

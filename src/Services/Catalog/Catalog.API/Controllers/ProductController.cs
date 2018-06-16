using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Infrastructure.Services;
using Catalog.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProduct(string id)
        {
            return Ok(await _productService.GetProductAsync(id));
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            await _productService.AddProductAsync(product);
            return Ok(HttpStatusCode.Created);
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RemoveProduct(string id)
        {
            var result = await _productService.RemoveProductAsync(id);

            return Ok(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }


    }
}
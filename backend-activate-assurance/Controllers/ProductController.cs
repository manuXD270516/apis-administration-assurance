using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using activate_assurance.Models;
using activate_assurance.Services;
using backend_activate_assurance.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_activate_assurance.Controllers
{
    [ApiController]
    [Route(IProductEndpoint.PRODUCT_ENDPOINT_BASE)]
    public class ProductController : ControllerBase, IProductEndpoint
    {

        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> addProduct(Product product)
        {
            return await productServices.addAsync(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> findAllProducts()
        {
            return await productServices.findAllAsync();
        }

        [HttpGet]
        [Route(IProductEndpoint.SEARCH_PRODUCT)]
        public async Task<ActionResult<Product>> findProductByCodeOrSerial(string productCode = "", string productSerial = "")
        {
            return await productServices.findProductByCodeOrSerial(productCode, productSerial);
        }

        [HttpGet]
        [Route(IProductEndpoint.PRODUCT_PARAM_ID)]
        public async Task<ActionResult<Product>> findProductById(int productId)
        {
            return await productServices.findByIdAsync(productId);
        }

        [HttpPut]
        [Route(IProductEndpoint.PRODUCT_PARAM_ID)]
        public async Task<ActionResult<Product>> updateProduct(int productId, Product product)
        {
            return await productServices.updateAsync(productId, product);
        }

        //[HttpPost]
        //public Ac
    }
}
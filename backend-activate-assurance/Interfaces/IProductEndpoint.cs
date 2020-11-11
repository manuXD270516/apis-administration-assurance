using activate_assurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_activate_assurance.Interfaces
{
    public interface IProductEndpoint: IEndpointTemplate
    {
        public const string RESOURCE = "product";
        public const string PRODUCT_ENDPOINT_BASE = ENDPOINT_BASE + "/" + RESOURCE;
        public const string SEARCH_PRODUCT = "search" + "/"; //+ PRODUCT_PARAM_CODE;
        public const string PRODUCT_PARAM_ID = "{productId}";
        public const string PRODUCT_PARAM_CODE = "{productCode}";

        Task<ActionResult<List<Product>>> findAllProducts();
        Task<ActionResult<Product>> findProductById(int productId);
        Task<ActionResult<Product>> findProductByCodeOrSerial(string productCode, string productSerial);
        Task<ActionResult<Product>> addProduct(Product product);
        Task<ActionResult<Product>> updateProduct(int productId, Product product);
        //ActionResult<P>

    }
}

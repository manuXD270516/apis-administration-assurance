using activate_assurance.Models;
using activate_assurance.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace activate_assurance.Services
{
    public interface IProductServices : IServicesTemplate<Product>
    {
        Task<ActionResult<Product>> findProductByCodeOrSerial(string productCode, string productSerial);
    }
}

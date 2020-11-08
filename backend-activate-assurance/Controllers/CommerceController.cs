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
    [Route(ICommerceEndpoint.COMMERCE_ENDPOINT_BASE)]
    public class CommerceController : ControllerBase, ICommerceEndpoint
    {

        private readonly ICommerceServices commerceServices;

        public CommerceController(ICommerceServices commerceServices)
        {
            this.commerceServices = commerceServices;
        }

        [HttpPost]
        public async Task<ActionResult<Commerce>> addCommerce(Commerce commerce)
        {
            return await commerceServices.addAsync(commerce);
        }

        [HttpGet]
        public async Task<ActionResult<List<Commerce>>> findAllCommerces()
        {
            return await commerceServices.findAllAsync();
        }

        [HttpGet]
        [Route(ICommerceEndpoint.COMMERCE_PARAM_ID)]
        public async Task<ActionResult<Commerce>> findCommerceById(int commerceId)
        {
            return await commerceServices.findByIdAsync(commerceId);
        }

        [HttpPut]
        [Route(ICommerceEndpoint.COMMERCE_PARAM_ID)]
        public async Task<ActionResult<Commerce>> updateCommerce(int commerceId, Commerce commerce)
        {
            return await commerceServices.updateAsync(commerceId, commerce);
        }

        //[HttpPost]
        //public Ac
    }
}
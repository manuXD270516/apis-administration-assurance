using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using activate_assurance.Models;
using activate_assurance.Models.DTOs;
using activate_assurance.Services;
using backend_activate_assurance.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace backend_activate_assurance.Controllers
{
    [ApiController]
    [Route(IUsersCommerceEndpoint.USERSCOMMERCE_ENDPOINT_BASE)]
    public class UsersCommerceController : ControllerBase, IUsersCommerceEndpoint
    {

        private readonly IUsersCommerceServices usersCommerceServices;

        public UsersCommerceController(IUsersCommerceServices commerceServices)
        {
            this.usersCommerceServices = commerceServices;
        }

        [HttpPost]
        public async Task<ActionResult<UsersCommerce>> addUsersCommerce(UsersCommerce usersCommerce)
        {
            return await usersCommerceServices.addAsync(usersCommerce);
        }

        [HttpPost]
        [Route(IUsersCommerceEndpoint.MASSIVE_REGISTERS)]
        public async Task<ActionResult<List<UsersCommerce>>> addProducts(List<UsersCommerce> usersCommerces)
        {
            return await usersCommerceServices.addMassiveAsync(usersCommerces);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersCommerce>>> findAllUsersCommerces()
        {
            return await usersCommerceServices.findAllAsync();
        }

        [HttpGet]
        [Route(IUsersCommerceEndpoint.GET_PROFILE)]
        public async Task<ActionResult<ProfileUserCommerceDTO>> findProfileUsersCommerce(int usersCommerceId)
        {
            return await usersCommerceServices.findProfileUsersCommerce(usersCommerceId);
        }

        [HttpGet]
        [Route(IUsersCommerceEndpoint.USERSCOMMERCE_PARAM_ID)]
        public async Task<ActionResult<UsersCommerce>> findUsersCommerceById(int usersCommerceId)
        {
            return await usersCommerceServices.findByIdAsync(usersCommerceId);
        }

        [HttpPut]
        [Route(IUsersCommerceEndpoint.USERSCOMMERCE_PARAM_ID)]
        public async Task<ActionResult<UsersCommerce>> updateUsersCommerce(int usersCommerceId, UsersCommerce usersCommerce)
        {
            return await usersCommerceServices.updateAsync(usersCommerceId, usersCommerce);
        }

        //[HttpPost]
        //public Ac
    }
}
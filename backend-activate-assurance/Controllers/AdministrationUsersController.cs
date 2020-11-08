using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using activate_assurance.Models.DTOs;
using activate_assurance.Services;
using backend_activate_assurance.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace backend_activate_assurance.Controllers
{
    [Route(IAdministrationUsersEndpoint.ADMUSERS_ENDPOINT_BASE)]
    [ApiController]
    public class AdministrationUsersController : ControllerBase, IAdministrationUsersEndpoint
    {

        private readonly IUsersCommerceServices usersCommerceServices;
        public AdministrationUsersController(IUsersCommerceServices usersCommerceServices)
        {
            this.usersCommerceServices = usersCommerceServices;
        }

        [HttpPost]
        [Route(IAdministrationUsersEndpoint.LOGIN)]
        public Task<ActionResult<AuthenticationDTO>> authenticate(UserLoginDTO userLogin)
        {
            return usersCommerceServices.authenticate(userLogin);
        }
    }
}
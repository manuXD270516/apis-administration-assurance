using activate_assurance.Models;
using activate_assurance.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_activate_assurance.Interfaces
{
    public interface IUsersCommerceEndpoint: IEndpointTemplate
    {
        public const string RESOURCE = "usersCommerce";
        public const string USERSCOMMERCE_ENDPOINT_BASE = ENDPOINT_BASE + "/" + RESOURCE;
        public const string USERSCOMMERCE_PARAM_ID = "{usersCommerceId}";
        public const string GET_PROFILE = "profile"+"/"+ USERSCOMMERCE_PARAM_ID;

        Task<ActionResult<List<UsersCommerce>>> findAllUsersCommerces();
        Task<ActionResult<UsersCommerce>> findUsersCommerceById(int usersCommerceId);
        Task<ActionResult<ProfileUserCommerceDTO>> findProfileUsersCommerce(int usersCommerceId);
        Task<ActionResult<UsersCommerce>> addUsersCommerce(UsersCommerce usersCommerce);
        Task<ActionResult<UsersCommerce>> updateUsersCommerce(int usersCommerceId, UsersCommerce usersCommerce);
        //ActionResult<P>

    }
}

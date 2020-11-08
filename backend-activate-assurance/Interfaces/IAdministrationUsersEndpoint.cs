using activate_assurance.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_activate_assurance.Interfaces
{
    interface IAdministrationUsersEndpoint: IEndpointTemplate
    {

        public const string RESOURCE = "admin";
        public const string ADMUSERS_ENDPOINT_BASE = ENDPOINT_BASE + "/" + RESOURCE;
        public const string LOGIN= "login";

        //public const string ASSURANCE_PARAM_ID = "{assuranceId}";
        Task<ActionResult<AuthenticationDTO>> authenticate(UserLoginDTO userLogin);
    }
}

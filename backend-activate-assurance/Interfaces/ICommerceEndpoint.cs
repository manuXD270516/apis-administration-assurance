using activate_assurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_activate_assurance.Interfaces
{
    public interface ICommerceEndpoint: IEndpointTemplate
    {
        public const string RESOURCE = "commerces";
        public const string COMMERCE_ENDPOINT_BASE = ENDPOINT_BASE + "/" + RESOURCE;
        public const string COMMERCE_PARAM_ID = "{commerceId}";

        Task<ActionResult<List<Commerce>>> findAllCommerces();
        Task<ActionResult<Commerce>> findCommerceById(int commerceId);
        Task<ActionResult<Commerce>> addCommerce(Commerce commerce);
        Task<ActionResult<Commerce>> updateCommerce(int commerceId, Commerce commerce);
        //ActionResult<P>

    }
}

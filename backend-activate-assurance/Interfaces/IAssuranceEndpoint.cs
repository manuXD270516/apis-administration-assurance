using activate_assurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_activate_assurance.Interfaces
{
    public interface IAssuranceEndpoint : IEndpointTemplate
    {
        public const string RESOURCE = "assurances";
        public const string ASSURANCE_ENDPOINT_BASE = ENDPOINT_BASE + "/" + RESOURCE;
        public const string ASSURANCE_PARAM_ID = "{assuranceId}";

        Task<ActionResult<List<Assurance>>> findAllAssurances();
        Task<ActionResult<Assurance>> findAssuranceById(int assuranceId);
        Task<ActionResult<Assurance>> addAssurance(Assurance assurance);
        Task<ActionResult<Assurance>> updateAssurance(int assuranceId, Assurance Assurance);
        //ActionResult<P>

    }
}

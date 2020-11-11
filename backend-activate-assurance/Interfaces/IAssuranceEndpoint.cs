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
    public interface IAssuranceEndpoint : IEndpointTemplate
    {
        public const string RESOURCE = "assurances";
        public const string ASSURANCE_ENDPOINT_BASE = ENDPOINT_BASE + "/" + RESOURCE;
        
        public const string SEARCH_BY_CLIENT = "search"+"/"+"client"+"/"+CLIENT_PARAM_ID ;
        public const string GET_ALL_ASSURANCES = "all";
        public const string CLAIM_ASSURANCE = "claim";
        
        public const string ASSURANCE_PARAM_ID = "{assuranceId}";
        public const string CLIENT_PARAM_ID = "{clientId}";

        Task<ActionResult<List<Assurance>>> findAllAssurances();
        
        Task<ActionResult<List<AssuranceDTO>>> findAllAssurancesCustom();
        Task<ActionResult<List<AssuranceDTO>>> findAllAssurancesByClientId(int clientId);
        Task<ActionResult<Assurance>> findAssuranceById(int assuranceId);
        Task<ActionResult<Assurance>> addAssurance(Assurance assurance);
        Task<ActionResult<Assurance>> updateAssurance(int assuranceId, Assurance Assurance);

        Task<ActionResult<Assurance>> claimAssurance(ClaimAssuranceDTO claimAssurance);

        
        //ActionResult<P>

    }
}

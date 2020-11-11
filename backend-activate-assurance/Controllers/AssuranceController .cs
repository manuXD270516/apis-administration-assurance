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
    [Route(IAssuranceEndpoint.ASSURANCE_ENDPOINT_BASE)]
    public class AssuranceController : ControllerBase, IAssuranceEndpoint
    {

        private readonly IAssuranceServices assuranceServices;

        public AssuranceController(IAssuranceServices assuranceServices)
        {
            this.assuranceServices = assuranceServices;
        }

        [HttpPost]
        public async Task<ActionResult<Assurance>> addAssurance(Assurance assurance)
        {
            return await assuranceServices.addAsync(assurance);
        }

        [HttpPost]
        [Route(IAssuranceEndpoint.CLAIM_ASSURANCE)]
        public async Task<ActionResult<Assurance>> claimAssurance(ClaimAssuranceDTO claimAssurance)
        {
            return await assuranceServices.claimAssurance(claimAssurance);
        }

        [HttpGet]
        public async Task<ActionResult<List<Assurance>>> findAllAssurances()
        {
            return await assuranceServices.findAllAsync();
        }

        [HttpGet]
        [Route(IAssuranceEndpoint.SEARCH_BY_CLIENT)]
        public async Task<ActionResult<List<AssuranceDTO>>> findAllAssurancesByClientId(int clientId)
        {
            return await assuranceServices.findAllAssurancesByClientId(clientId);
        }

        [HttpGet]
        [Route(IAssuranceEndpoint.GET_ALL_ASSURANCES)]
        public async Task<ActionResult<List<AssuranceDTO>>> findAllAssurancesCustom()
        {
            return await assuranceServices.findAllAssurancesCustom();
        }

        [HttpGet]
        [Route(IAssuranceEndpoint.ASSURANCE_PARAM_ID)]
        public async Task<ActionResult<Assurance>> findAssuranceById(int assuranceId)
        {
            return await assuranceServices.findByIdAsync(assuranceId);
        }

        [HttpPut]
        [Route(IAssuranceEndpoint.ASSURANCE_PARAM_ID)]
        public async Task<ActionResult<Assurance>> updateAssurance(int assuranceId, Assurance assurance)
        {
            return await assuranceServices.updateAsync(assuranceId, assurance);
        }

        //[HttpPost]
        //public Ac
    }
}
using activate_assurance.Models;
using activate_assurance.Models.DTOs;
using activate_assurance.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace activate_assurance.Services
{
    public interface IAssuranceServices : IServicesTemplate<Assurance>
    {
        Task<ActionResult<Assurance>> claimAssurance(ClaimAssuranceDTO claimAssurance);
        Task<ActionResult<List<AssuranceDTO>>> findAllAssurancesCustom();
        Task<ActionResult<List<AssuranceDTO>>> findAllAssurancesByClientId(int clientId);
    }
}

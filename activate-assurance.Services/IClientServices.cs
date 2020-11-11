using activate_assurance.Models;
using activate_assurance.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace activate_assurance.Services
{
    public interface IClientServices : IServicesTemplate<Client>
    {
        Task<ActionResult<Client>> findClientByDni(string clientDni);
    }
}

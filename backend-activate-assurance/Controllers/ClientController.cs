using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using activate_assurance.Models;
using activate_assurance.Services;
using backend_activate_assurance.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_activate_assurance.Controllers
{
    [ApiController]
    [Route(IClientEndpoint.CLIENT_ENDPOINT_BASE)]
    public class ClientController : ControllerBase, IClientEndpoint
    {

        private readonly IClientServices clientServices;

        public ClientController(IClientServices clientServices)
        {
            this.clientServices = clientServices;
        }

        [HttpPost]
        public async Task<ActionResult<Client>> addClient(Client client)
        {
            return await clientServices.addAsync(client);
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> findAllClients()
        {
            return await clientServices.findAllAsync();
        }

        [HttpGet]
        [Route(IClientEndpoint.CLIENT_PARAM_ID)]
        public async Task<ActionResult<Client>> findClientById(int clientId)
        {
            return await clientServices.findByIdAsync(clientId);
        }

        [HttpPut]
        [Route(IClientEndpoint.CLIENT_PARAM_ID)]
        public async Task<ActionResult<Client>> updateClient(int clientId, Client client)
        {
            return await clientServices.updateAsync(clientId, client);
        }

        //[HttpPost]
        //public Ac
    }
}
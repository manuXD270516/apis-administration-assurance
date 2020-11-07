﻿using activate_assurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_activate_assurance.Interfaces
{
    public interface IClientEndpoint: IEndpointTemplate
    {
        public const string RESOURCE = "clients";
        public const string CLIENT_ENDPOINT_BASE = ENDPOINT_BASE + "/" + RESOURCE;
        public const string CLIENT_PARAM_ID = "{clientId}";

        Task<ActionResult<List<Client>>> findAllClients();
        Task<ActionResult<Client>> findClientById(int clientId);
        Task<ActionResult<Client>> addClient(Client product);
        Task<ActionResult<Client>> updateClient(int clientId, Client client);
        //ActionResult<P>

    }
}

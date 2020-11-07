using activate_assurance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace activate_assurance.DataAccess.Data.Repository.Impl
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly ApplicationDbContext context;
        
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context; 
        }
    }
}

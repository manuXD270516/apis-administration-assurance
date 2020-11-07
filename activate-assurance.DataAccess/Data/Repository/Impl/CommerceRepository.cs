using activate_assurance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace activate_assurance.DataAccess.Data.Repository.Impl
{
    public class CommerceRepository : Repository<Commerce>, ICommerceRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CommerceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

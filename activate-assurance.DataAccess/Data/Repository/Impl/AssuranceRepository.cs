using activate_assurance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace activate_assurance.DataAccess.Data.Repository.Impl
{
    public class AssuranceRepository : Repository<Assurance>, IAssuranceRepository
    {
        private readonly ApplicationDbContext context;

        public AssuranceRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}

using activate_assurance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace activate_assurance.DataAccess.Data.Repository.Impl
{
    public class UsersCommerceRepository : Repository<UsersCommerce>, IUsersCommerceRepository
    {
        private readonly ApplicationDbContext context;

        public UsersCommerceRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}

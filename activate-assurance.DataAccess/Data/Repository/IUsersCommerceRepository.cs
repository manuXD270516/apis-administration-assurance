using activate_assurance.Models;
using activate_assurance.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace activate_assurance.DataAccess.Data.Repository
{
    public interface IUsersCommerceRepository : IRepository<UsersCommerce>
    {
        Task<ActionResult<AuthenticationDTO>> authenticate(UsersCommerce userLogin);
    }
}

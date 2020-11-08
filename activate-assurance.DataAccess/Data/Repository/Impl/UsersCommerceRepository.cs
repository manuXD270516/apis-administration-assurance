using activate_assurance.Models;
using activate_assurance.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static activate_assurance.Utils.UtilsModel;

namespace activate_assurance.DataAccess.Data.Repository.Impl
{
    public class UsersCommerceRepository : Repository<UsersCommerce>, IUsersCommerceRepository
    {
        private readonly ApplicationDbContext context;

        public UsersCommerceRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        // Refactorizar la logica (mover al layer services)
        public async Task<ActionResult<AuthenticationDTO>> authenticate(UsersCommerce userLogin)
        {
            AuthenticationDTO authentication = new AuthenticationDTO { userType = "USER_COMMERCE" };
            var loginSucces = await getFirstOrDefaultAsync(user => 
                                        user.username.Equals(userLogin.username) && user.password.Equals(userLogin.password));
            if (!isNull(loginSucces))
            {
                authentication.userId = loginSucces.usersCommerceId;
                authentication.authenticate = true;
                authentication.message = "login exitoso";
            } else
            {
                authentication.authenticate = false;
                authentication.message = "credenciales invalidas, intente nuevamente";
            }
            return authentication;
        }
    }
}

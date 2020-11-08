using System;
using System.Collections.Generic;
using System.Text;
using static activate_assurance.Utils.UtilsModel;

namespace activate_assurance.Models.DTOs
{
    public class UserLoginDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string userType { get; set; }

        public static explicit operator UsersCommerce(UserLoginDTO userLogin)
        {
            UsersCommerce usersCommerce = default;
            if (!isNull(userLogin))
            {
                usersCommerce = new UsersCommerce
                {
                    username = userLogin.username,
                    password = userLogin.password
                };
            }
            return usersCommerce;
        }

    }
}

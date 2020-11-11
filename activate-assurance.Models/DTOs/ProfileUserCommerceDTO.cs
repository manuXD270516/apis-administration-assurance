using System;
using System.Collections.Generic;
using System.Text;
using static activate_assurance.Utils.UtilsModel;


namespace activate_assurance.Models.DTOs
{
    public class ProfileUserCommerceDTO
    {

        public int profileUserCommerceId { get; set; }
        public string username { get; set; }
        public string commmerceWork { get; set; }
        public string commerceAddress { get; set; }

        public int countAssurancesActivated { get; set; }
        public int countAssurancesClaim { get; set; }
        public int countClientsRegister { get; set; }

        public static explicit operator ProfileUserCommerceDTO(UsersCommerce usersCommerce)
        {
            ProfileUserCommerceDTO profile = default;
            if (!isNull(usersCommerce))
            {
                profile = new ProfileUserCommerceDTO
                {
                    profileUserCommerceId = usersCommerce.usersCommerceId,
                    username = usersCommerce.username
                };
                if (!isNull(usersCommerce.commerce))
                {
                    profile.commmerceWork = usersCommerce.commerce.name;
                    profile.commerceAddress = usersCommerce.commerce.address;
                }
            }
            return profile;
        }
    }
}

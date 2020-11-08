using System;
using System.Collections.Generic;
using System.Text;

namespace activate_assurance.Models.DTOs
{
    public class AuthenticationDTO
    {

        public int userId { get; set; }
        public string userType { get; set; }

        public bool authenticate { get; set; }

        public string message { get; set; }
    }
}

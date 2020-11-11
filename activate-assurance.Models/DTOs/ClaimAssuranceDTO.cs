using System;
using System.Collections.Generic;
using System.Text;

namespace activate_assurance.Models.DTOs
{
    public class ClaimAssuranceDTO
    {
        public int assuranceId { get; set; }
        public int usersCommerceClaimId{ get; set; }
        public string reason { get; set; }
    }
}

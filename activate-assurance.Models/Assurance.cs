using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace activate_assurance.Models
{
    public class Assurance : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int assuranceId { get; set; }

        [Column(Order = 1)]
        public int productId { get; set; }
        [ForeignKey(name: "productId")]
        public Product product { get; set; }

        [Column(Order = 2)]
        public int clientId { get; set; }
        [ForeignKey(name: "clientId")]
        public Client client { get; set; }

        [Column(Order = 3)]
        public int? usersCommerceActivateId { get; set; }
        [ForeignKey(name: "usersCommerceActivateId")]
        public UsersCommerce usersCommerceActivate { get; set; }

        [Column(Order = 4)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime activationDate { get; set; }

        [Column(Order = 5)]
        [Required]
        public int expirationDays { get; set; }


        [Column(Order = 6)]
        public int? usersCommerceClaimId { get; set; }
        [ForeignKey(name: "usersCommerceClaimId")]
        public UsersCommerce usersCommerceClaim { get; set; }

        [Column(Order = 7)]
        [StringLength(maximumLength: 300)]
        public string? reason { get; set; }

        [Column(Order = 8)]
        public DateTime? claimDate { get; set; }


        // ExpirationDate pending



    }
}

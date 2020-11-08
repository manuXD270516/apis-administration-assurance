using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace activate_assurance.Models
{
    public class Commerce: BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int commerceId { get; set; }

        [Column(Order = 1)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 100)]
        public string name { get; set; }

        [Column(Order = 2)]
        [StringLength(maximumLength: 200)]
        public string address { get; set; }

       

        // Type pending
        [InverseProperty(property: "commerce")]
        public UsersCommerce usersCommerce { get; set; }


        public Commerce()
        {
            
        }

    }
}

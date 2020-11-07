using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace activate_assurance.Models
{
    public class Client: BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int clientId { get; set; }

        [Column(Order = 1)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 15)]
        public string dni { get; set; }

        [Column(Order = 2)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength:50)]
        public string names { get; set; }

        [Column(Order = 3)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 50)]
        public string lastnames { get; set; }

        [InverseProperty(property: "client")]
        public virtual List<Assurance> activateAssurances { get; set; }



        public Client()
        {
            activateAssurances = new List<Assurance>();
        }


    }
}

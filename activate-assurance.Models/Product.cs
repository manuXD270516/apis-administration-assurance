using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace activate_assurance.Models
{
    public class Product : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }

        [Column(Order = 1)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string serialCode { get; set; } // Codigo de barras

        [Column(Order = 2)]

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 20)]
        public string codeArticle { get; set; } // Codigo de barras

        [Column(Order = 3)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 100)]
        public string name { get; set; } // producto

        [Column(Order = 4)]
        [StringLength(maximumLength: 50)]
        public string mark { get; set; } // Codigo de barras

        [Column(Order = 5)]
        [Required]
        public int expirationDays { get; set; }

        [InverseProperty(property: "product")]
        public List<Assurance> activateAssurances { get; set; }


        public Product()
        {
            activateAssurances = new List<Assurance>();
        }

    }
}

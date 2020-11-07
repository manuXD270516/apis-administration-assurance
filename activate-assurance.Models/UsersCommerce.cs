using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace activate_assurance.Models
{
    public class UsersCommerce : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userCommerceId { get; set; }

        [Column(Order = 1)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 30)]
        public string username { get; set; }

        [Column(Order = 2)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 30, MinimumLength = 8)]
        public string password { get; set; }

        [Column(Order = 3)]
        public int commerceId { get; set; }
        [ForeignKey(name: "commerceId")]
        public Commerce commerce { get; set; }




    }
}

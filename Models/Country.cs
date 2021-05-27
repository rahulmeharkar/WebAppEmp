using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppEmp.Models
{
    public class Country
    {
        [Column("countryid")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int countryid { get; set; }

        [Column("countryname")]
        [Required]
        [StringLength(50)]
        public string cname { get; set; }
    }
}

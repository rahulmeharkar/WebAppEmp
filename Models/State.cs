using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppEmp.Models
{
    public class State
    {
        [Column("stateid")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int stateid { get; set; }

        [Column("statename")]
        [Required]
        [StringLength(50)]
        public string statename { get; set; }

        public int countryid { get; set; }

        [ForeignKey("countryid")]
        public Country Country;
    }
}

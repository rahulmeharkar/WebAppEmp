using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppEmp.Models
{
    public class City
    {
        [Column("cityid")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int cityid { get; set; }

        [Column("cityname")]
        [Required]
        [StringLength(50)]
        public string cityname { get; set; }

        public int stateid { get; set; }

        [ForeignKey("stateid")]
        public State State;
    }
}

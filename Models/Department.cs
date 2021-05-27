using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppEmp.Models
{
    public class Department
    {
        [Column("deptartmentid")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int departmentid { get; set; }

        [Column("departmentname")]
        [Required]
        [StringLength(50)]
        public string departmentname { get; set; }
    }
}

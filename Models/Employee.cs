using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppEmp.Models
{
    public class Employee
    {
        [Column("employeeid")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int employeeid { get; set; }

        [Column("firstname")]
        [Required]
        [StringLength(50)]
        public string firstname { get; set; }

        [Column("lastname")]
        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Column("gender")]
        [Required]
        [StringLength(50)]
        public string gender { get; set; }

        [Column("dob")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.Date)]
        public string dob { get; set; }

        [Column("email")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Column("phone")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Column("pincode")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.PostalCode)]
        public string pincode { get; set; }

        [Column("hobbies")]
        [Required]
        [StringLength(50)]
        public string hobbies { get; set; }

        public int countryid { get; set; }
        public int stateid { get; set; }
        public int cityid { get; set; }
        public int departmentid { get; set; }

        [ForeignKey("countryid")]
        public Country Country;

        [ForeignKey("stateid")]
        public State State;

        [ForeignKey("cityid")]
        public City City;

        [ForeignKey("departmentid")]
        public Department Department;

    }
}

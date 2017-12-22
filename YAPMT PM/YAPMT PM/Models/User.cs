using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YAPMT_PM.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Organization cannot be longer than 30 characters.")]
        [Column("Organization")]
        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "UserName cannot be longer than 10 characters.")]
        [Column("UserName")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }
}
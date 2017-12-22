using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YAPMT_PM.Models
{
    public class Project
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name of Project")]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
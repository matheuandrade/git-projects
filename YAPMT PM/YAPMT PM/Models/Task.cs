using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YAPMT_PM.Models
{
    public class Task
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        public StatusOfTask Status { get; set; }

        public virtual User User { get; set; }

    }

    public enum StatusOfTask
    {
        Ok,
        Late,
        Concluded,
        LateConcluded
    }
}
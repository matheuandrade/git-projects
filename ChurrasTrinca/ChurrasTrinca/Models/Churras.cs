using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurrasTrinca.Models
{
    public class Churras
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Quando?")]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "porque?")]
        public string porque { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Obs")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Com bebida")]
        public decimal ValorComBebida { get; set; }

        [Required]
        [Display(Name = "Sem bebida")]
        public decimal ValorSemBebida { get; set; }

        public decimal ValorJaPago { get; set; }

        public decimal ValorArrecadado { get; set; }

        public virtual ICollection<Participante> Participantes { get; set; }
    }
}
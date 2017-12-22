using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurrasTrinca.Models
{
    public class Participante
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Bebida")]
        public bool Bebida { get; set; }

        [Required]
        [Display(Name = "Pago?")]
        public bool Pago { get; set; }

        [Required]
        [Display(Name = "Valor Contribuição")]
        public decimal contribuicao { get; set; }

        [StringLength(40)]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

    }
}
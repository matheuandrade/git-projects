using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAdmin.Business.Dto
{
    public class SystemResource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Name { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<int> Order { get; set; }
        public string Visibility { get; set; }

        public virtual SystemResource SystemResourceParent { get; set; }

        [NotMapped]
        public string VisibilityDescription
        {
            get
            {
                foreach (VisibilityEnum vis in VisibilityEnum.GetValues(typeof(VisibilityEnum)))
                    if (this.Visibility.Equals(vis.GetValue()))
                        return vis.GetDescription();
                return string.Empty;
            }
            set { }
        }
    }
}

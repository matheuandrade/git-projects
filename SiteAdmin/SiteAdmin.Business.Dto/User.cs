using SiteAdmin.Business.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAdmin.Business.Dto
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public bool Active { get; set; }
        public string Registration { get; set; }
        public string Office { get; set; }
        public string Job { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public string Language { get; set; }
        public Nullable<DateTime> LastActivityDate { get; set; }
        public Nullable<DateTime> LastLoginDate { get; set; }

        //public virtual Company Company { get; set; }
        //public virtual Contract Contract { get; set; }
        //public virtual Allocation Allocation { get; set; }

        [NotMapped]
        public string NewPassword { get; set; }

        //[NotMapped]
        //public List<Profile> Profiles { get; set; }

        [NotMapped]
        public string ActiveDescription
        {
            get
            {
                foreach (ActiveEnum act in ActiveEnum.GetValues(typeof(ActiveEnum)))
                    if (this.Active.Equals(act.GetValue()))
                        return act.GetDescription();
                return string.Empty;
            }
            set { }
        }

        [NotMapped]
        public string LanguageDescription
        {
            get
            {
                foreach (LanguageEnum le in LanguageEnum.GetValues(typeof(LanguageEnum)))
                    if (this.Language.Equals(le.GetValue()))
                        return le.GetDescription();
                return string.Empty;
            }
            set { }
        }

        //[NotMapped]
        //public List<Profile> AvailableProfiles { get; set; }

        //[NotMapped]
        //public List<Profile> RequestedProfiles { get; set; }

        [NotMapped]
        public List<int> AvailableSelected { get; set; }

        [NotMapped]
        public List<int> RequestedSelected { get; set; }
    }
}

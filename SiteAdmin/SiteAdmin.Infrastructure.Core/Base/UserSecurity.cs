using SiteAdmin.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAdmin.Infrastructure.Core.Base
{
    class UserSecurity
    {
        public User User { get; set; }
        public List<SystemResource> SystemResources { get; set; }
        public string Menu { get; set; }
        public string Language { get; set; }
    }
}

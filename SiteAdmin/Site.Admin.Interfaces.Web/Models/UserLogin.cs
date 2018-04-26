using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Admin.Interfaces.Web.Models
{
    public class UserLogin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
        public string Identity { get; set; }
    }
}
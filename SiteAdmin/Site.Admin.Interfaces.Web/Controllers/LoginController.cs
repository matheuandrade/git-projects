using SiteAdmin.Infrastructure.Core.Base;
using SiteAdmin.Interfaces.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Admin.Interfaces.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin userLogin)
        {
            //Return<UserSecurity> retUserSecurity = facade.Login(userLogin.Login, userLogin.Password);

            //if (!this.CheckReturn<UserSecurity>(retUserSecurity))
            //{
            //    return View(userLogin);
            //}
            //else
            //{
            //    Session.Add("UserData", retUserSecurity.Data);
            //}

            return RedirectToAction("Home", "Index");
        }





    }
}
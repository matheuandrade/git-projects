using SiteAdmin.Infrastructure.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SiteAdmin.Interfaces.Web.Controllers
{
    public class HomeController : BaseMvc
    {
        public ActionResult Index()
        {
            return View();
        }

        


    }
}
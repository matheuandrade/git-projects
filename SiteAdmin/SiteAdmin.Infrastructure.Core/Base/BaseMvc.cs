using SiteAdmin.Infrastructure.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using SiteAdmin.Business.Dto.Messages;
using System.Web.Routing;

namespace SiteAdmin.Infrastructure.Core.Base
{
   public class BaseMvc : Controller
    {
        private SecurityService _security;

        public SecurityService Security
        {
            get
            {
                if (_security == null)
                {
                    _security = new SecurityService();
                }

                if (Session["UserData"] != null)
                {
                    _security.UserData = (UserSecurity)Session["UserData"];
                }

                return _security;
            }
            set
            {
                if (Session["UserData"] != null)
                {
                    Session.Remove("UserData");
                }

                Session.Add("UserData", value);
            }
        }

        public bool CheckReturn<T>(Return<T> _return) where T : class
        {
            if (!_return.Success)
            {
                if (Request.HttpMethod == "POST")
                {
                    //Limpo o Model State e adiciono as mensagens
                    ModelState.Clear();

                    if (_return.Messages.Count() > 0)
                    {
                        foreach (var t in _return.Messages)
                            ModelState.AddModelError((string.IsNullOrEmpty(t.ObjectName) ? t.Id : t.ObjectName), t.Msg);
                    }
                }
                return false;
            }
            else
                return true;
        }

        public void SetViewMessage(string message)
        {
            TempData["MensagemTela"] = message;
        }

        public string GetViewMessage()
        {
            return TempData["MensagemTela"].ToString();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            bool validarUsuario = false;

            Util.BaseUrl = HttpContext.Request.ApplicationPath.ToString().Equals("/") ? string.Empty : HttpContext.Request.ApplicationPath.ToString();

            string action = filterContext.ActionDescriptor.ActionName.ToLower();
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();

            if (this.Security.UserData != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(this.Security.UserData.Language);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }

            ////Verifica se é necessário o usuário estar logado para acessar a página
            if (!controller.Equals("home"))
            {
                validarUsuario = true;
            }
            else if ((!action.Equals("index")) && (!action.Equals("login"))
                  && (!action.Equals("forgotpassword")) && (!action.Equals("sendpassword"))
                  && (!action.Equals("changelanguagelogin")))
            {
                validarUsuario = true;
            }

            if (validarUsuario)
            {
                if (Security.UserData == null)
                {
                    SetViewMessage(DtoMessage.GetMessage("DtoMessages", "MsgSistema001").Msg);

                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                         {
                                                                             {"controller", "Home"},
                                                                             {"action", "Index"}
                                                                         });
                }
                else if (!controller.Equals("home"))
                {
                    if (!VerificaAcessoTransacao(controller, action))
                    {
                        SetViewMessage(DtoMessage.GetMessage("DtoMessages", "MsgSistema002").Msg);

                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                                 {
                                                                                     {"controller", "Home"},
                                                                                     {"action", "Index"}
                                                                                 });
                    }
                }
            }
        }

        private bool VerificaAcessoTransacao(string controller, string action)
        {
            if (Security.UserData.SystemResources.Count() > 0)
            {
                if (Security.UserData.SystemResources.Find(c => !string.IsNullOrEmpty(c.Controller) && c.Controller.ToLower().Equals(controller)
                                                         && !string.IsNullOrEmpty(c.Action) && c.Action.ToLower().Equals(action)) != null)
                    return true;
            }

            return false;
        }
    }
}

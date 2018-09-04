﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaInformatica.BLL
{
    public class AutorizarLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuarioLogado = filterContext.HttpContext.Session["usuarioLogado"];
            if (usuarioLogado == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                          new RouteValueDictionary(
                              new { controller = "Login", action = "Index" }));
            }
        }
    }
}
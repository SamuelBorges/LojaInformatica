using LojaInformatica.BLL;
using LojaInformatica.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaInformatica.Controllers
{
    public class HomeController : Controller
    {
        [AutorizarLogin]
        public ActionResult Index(/*Usuario usuario*/)
        {


            //bool EhAdministrador = new HashGenerator().ProcurarUsuario(usuario);
            //ViewBag.temNivel = EhAdministrador;
            return View(ViewBag);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using LojaInformatica.BLL;
using LojaInformatica.DAO;
using System.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaInformatica.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        [AutorizarLogin]
        public ActionResult PreencherCadastroLogin()
        {
            return View(new Usuario());
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        
        public ActionResult VerificarLogin(Usuario usuario)
        {
            bool EmailSucesso = new Email().emailExiste(usuario);
            bool SenhaSucesso = new HashGenerator().VerificarSenha(usuario);

            if (EmailSucesso && SenhaSucesso)
            {
                Session["usuarioLogado"] = usuario;

                bool novoAcesso = new HashGenerator().RegistrarAcesso(usuario);
                bool PrimeiraVez = new HashGenerator().EhPrimeiroAcesso(usuario);
                bool EhAtivo = new HashGenerator().EhAtivo(usuario);
                
                if (!EhAtivo)
                {
                    ViewBag.Message = "O usuário não tem acesso pois está inativo.";
                    return View("Index", ViewBag);

                }
                if (!PrimeiraVez)
                {
                    
                    return RedirectToAction("Index", "Home"/*, new RouteValueDictionary(usuario.Email)*/);
                }
               
                return RedirectToAction("AlterarSenha", "Usuario");
            }
            else
            {
                ViewBag.Message = "Credenciais inválidas, tente novamente.";



                return View("Index");

            }
        }


    }
}
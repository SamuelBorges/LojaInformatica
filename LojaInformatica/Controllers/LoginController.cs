using LojaDeInformatica.BLL;
using LojaDeInformatica.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaDeInformatica.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult VerificarLogin(Usuario usuario)
        {
            bool sucesso = new HashGenerator().Verificar(usuario);

            if (sucesso)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult CadastrarLogin(Usuario usuario)
        {
            bool sucesso = new UsuarioBLL().VerificarInformacoesUsuario(usuario);
            bool cadastrado = new HashGenerator().Cadastrar(usuario);
            
            return View();
        }
    }
}
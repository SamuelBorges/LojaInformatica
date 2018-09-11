using LojaInformatica.BLL;
using LojaInformatica.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [AutorizarLogin]
        public ActionResult VisualizarLogin()
        {
            IList<Usuario> usuarios = new List<Usuario>();
            ViewBag.Usuario = usuarios;
            return View();
        }

        
        public ActionResult VerificarLogin(Usuario usuario)
        {
            //deixar em um só
            bool EmailSucesso = new HashGenerator().VerificarEmail(usuario);
            bool SenhaSucesso = new HashGenerator().VerificarSenha(usuario);

            if (EmailSucesso && SenhaSucesso)
            {
                Session["usuarioLogado"] = usuario;
                
                //Contar número de acessos
                object NumDaSession = Session["contador"];
                int NumAcessos = Convert.ToInt32(NumDaSession);

                NumAcessos++;
                Session["contador"] = NumAcessos;
                //Ir para o Index

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }



        [AutorizarLogin]
        public ActionResult CadastrarLogin(Usuario usuario)
            {
            bool sucesso = new UsuarioBLL().VerificarInformacoesUsuario(usuario);
            bool cadastrado = new HashGenerator().Cadastrar(usuario);

            return View();
        }
    }
}
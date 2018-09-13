using LojaInformatica.BLL;
using LojaInformatica.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaInformatica.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [AutorizarLogin]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            bool sucesso = new UsuarioBLL().VerificarInformacoesUsuario(usuario);
            bool cadastrado = new HashGenerator().RegistrarUsuario(usuario);

            return View();
        }

        [AutorizarLogin]
        public ActionResult VisualizarUsuarios()
        {
            IList<Usuario> usuarios = new List<Usuario>();
            ViewBag.Usuario = usuarios;
            return View();
        }
    }
}
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

        [AutorizarLogin, HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            object user = new { sucesso= false };
            bool valid = new UsuarioBLL().VerificarInformacoesUsuario(usuario);
            bool cadastrado = new HashGenerator().RegistrarUsuario(usuario);
            if (cadastrado)
            {
                user = new { sucesso = true, id = usuario.Id, nome = usuario.Nome, email = usuario.Email, nivel = usuario.NivelAcesso, ativo = usuario.Ativo };
            }
            return Json(user);
        }

        [AutorizarLogin]
        public ActionResult VisualizarUsuarios()
        {
            HashGenerator dao = new HashGenerator();
            IList<Usuario> usuarios = dao.ListarUsuarios();
            ViewBag.Usuarios = usuarios;
            return View();
            
        }

        [AutorizarLogin]
        public ActionResult AlterarDadosUsuario(Usuario usuario)
        {
            bool Foiatualizado = new HashGenerator().AtualizarUsuario(usuario);
            return Json(usuario);
        }

    }
}
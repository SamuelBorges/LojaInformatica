using LojaInformatica.BLL;
using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
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
            IList<Usuario> usuarios = ListarUsuarios();
            ViewBag.Usuarios = usuarios;
            return View();
            
        }

        [AutorizarLogin]
        public ActionResult AlterarDadosUsuario(Usuario usuario)
        {
            bool Foiatualizado = AtualizarUsuario(usuario);
            return Json(usuario);
        }

        public IList<Usuario> ListarUsuarios()
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                var lista = entity.Usuarios.ToList();
                var OrderById = lista.OrderByDescending(u => u.Id).ToList();
                var MostrarElementos = OrderById.Take(10).ToList();

                return MostrarElementos;

            }
        }

        public bool AtualizarUsuario(Usuario usuario)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                entity.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                entity.SaveChanges();
            }
            return true;
        }

    }
}
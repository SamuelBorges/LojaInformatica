using LojaInformatica.BLL;
using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using LojaInformatica.DAO.Enum;
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
           
            object user = new { sucesso = false };
            string validMessage = new UsuarioBLL().EhUserValido(usuario);
            if (validMessage=="")
            {
                bool cadastrado = new HashGenerator().RegistrarUsuario(usuario);
                if (!cadastrado)
                {
                    user = new { sucesso = false, message = "Erro inesperado, tente novemente." };
                    return Json(user);

                }
                    user = new { sucesso = true, id = usuario.Id, nome = usuario.Nome, email = usuario.Email, nivel = usuario.NivelAcesso, ativo = usuario.Ativo, message = validMessage };
                return Json(user);

            }
            else
            {
                user = new { sucesso = false, message = validMessage };
                return Json(user);
            }


           
        }

        public ActionResult VerMais(Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                var lista = entity.Usuarios.ToList();
                var OrderById = lista.OrderByDescending(u => u.Id).ToList();
                var MostrarElementos = OrderById.Take(10).ToList();

                return Json(MostrarElementos);
            }
        }




        [AutorizarLogin]
        public ActionResult GerenciarUsuarios()
        {
            IList<Usuario> usuarios = ListarUsuarios();
            ViewBag.Usuarios = usuarios;
            return View();

        }

        [AutorizarLogin, HttpPost]
        public ActionResult AlterarDadosUsuario(int id)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                object user = new { sucesso = false };


                var usuario = entity.Usuarios.FirstOrDefault(p => p.Id == id);

                if (usuario!=null)
                {
                    user = new { sucesso = true, id = usuario.Id, nome = usuario.Nome, email = usuario.Email, nivel = usuario.NivelAcesso, ativo = usuario.Ativo };
                }
                return Json(usuario, JsonRequestBehavior.AllowGet);
            }

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
        //continuar
        //public JsonResult VerMais()
        //{
        //    using (LojaInformaticaContext entity = new LojaInformaticaContext())
        //    {
        //        var lista = entity.Usuarios.ToList();
        //        var OrderById = lista.OrderByDescending(u => u.Id).ToList();
        //        var MostrarElementos = OrderById.Take(10).ToList();
                
        //        return Json(ListaJSon);

        //    }
        //}

            [AutorizarLogin, HttpPost]
        public ActionResult AtualizarUsuario(Usuario usuarioedit)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                object user = new { sucesso = false };
                string validMessage = new UsuarioBLL().EhUserValido(usuarioedit);

                if (validMessage=="")
                {
                    Usuario editDoUser = new Usuario();
                    editDoUser = entity.Usuarios.Find(usuarioedit.Id);
                    editDoUser.Nome = usuarioedit.Nome;

                    entity.SaveChanges();
                    user = new { sucesso = true, id = usuarioedit.Id, nome = usuarioedit.Nome, email = usuarioedit.Email, nivel = usuarioedit.NivelAcesso, ativo = usuarioedit.Ativo };

                }
                return Json(user);
                
            }
            
        }

    }
}
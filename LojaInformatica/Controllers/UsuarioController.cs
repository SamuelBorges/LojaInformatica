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


        [AutorizarLogin, HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {

            object user = new { sucesso = false };
            string validMessage = new UsuarioBLL().EhUserValido(usuario);

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                var userDB = entity.Usuarios.FirstOrDefault(p => p.Email == usuario.Email);
                if (userDB != null)
                {
                    user = new { sucesso = false, message = "Email já existe." };
                    return Json(user);
                }
            }

            if (validMessage == "")
            {
                bool cadastrado = new UsuarioBLL().RegistrarUsuario(usuario);
                if (!cadastrado)
                {
                    user = new { sucesso = false, message = "Erro inesperado, tente novemente." };
                    return Json(user);

                }
                using (LojaInformaticaContext entity = new LojaInformaticaContext())
                {
                    var userDB = entity.Usuarios.FirstOrDefault(p => p.Email == usuario.Email);
                    user = new { sucesso = true, id = userDB.Id, nome = usuario.Nome, email = usuario.Email, nivel = usuario.NivelAcesso, ativo = usuario.Ativo, message = validMessage };
                return Json(user);
                }


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
                var MostrarElementos = OrderById.Skip(10).Take(10).ToList();
                
                return Json(MostrarElementos, JsonRequestBehavior.AllowGet);
            }
        }




        [AutorizarLogin]
        public ActionResult GerenciarUsuarios()
        {
            IList<Usuario> usuarios = ListarUsuarios();
            ViewBag.Usuarios = usuarios;
            
            return View(ViewBag);

        }

        [AutorizarLogin, HttpPost]
        public ActionResult AlterarDadosUsuario(int id)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                object user = new { sucesso = false };


                var usuario = entity.Usuarios.FirstOrDefault(p => p.Id == id);

                if (usuario != null)
                {
                    user = new { sucesso = true, id = usuario.Id, nome = usuario.Nome,
                                email = usuario.Email, nivel = usuario.NivelAcesso, ativo = usuario.Ativo };
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
        public ActionResult AtualizarUsuario(Usuario usuarioedit, int Id)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                object user = new { sucesso = false };
                string validMessage = new UsuarioBLL().EhUserValido(usuarioedit);

                if (validMessage == "")
                {
                    Usuario editDoUser = new Usuario();
                    try
                    {
                        editDoUser = entity.Usuarios.Find(Id);

                    }
                    catch (Exception)
                    {
                        user = new { sucesso = false, message = "O usuário que você tenta editar não existe." };
                        return Json(user);
                    }


                    editDoUser.Nome = usuarioedit.Nome;
                    editDoUser.Email = usuarioedit.Email;
                    editDoUser.NivelAcesso = usuarioedit.NivelAcesso;
                    editDoUser.Senha = usuarioedit.Senha;
                    editDoUser.Ativo = usuarioedit.Ativo;
                   
                    entity.SaveChanges();
                    user = new { sucesso = true, id = editDoUser.Id, nome = editDoUser.Nome, email = editDoUser.Email, nivel = editDoUser.NivelAcesso, ativo = editDoUser.Ativo, message ="Usuário atualizado com sucesso." };
                    return Json(user);

                }
                user = new { sucesso = false, message = validMessage };
                return Json(user);

            }

        }

    }
}
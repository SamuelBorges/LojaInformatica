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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult GerenciarClientes()
        {
            IList<Cliente> clientes = ListarClientes();
            ViewBag.Clientes = clientes;
            return View();
        }
        public IList<Cliente> ListarClientes()
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                var lista = entity.Clientes.ToList();
                var OrderById = lista.OrderByDescending(u => u.Id).ToList();
                var MostrarElementos = OrderById.Take(10).ToList();



                return MostrarElementos;

            }
        }


        [AutorizarLogin, HttpPost]
        public ActionResult CadastrarCliente(Cliente cliente)
        {

            object user = new { sucesso = false };
            string validMessage = ""; //validações
            if (validMessage == "")
            {
                bool cadastrado = new HashGenerator().RegistrarCliente(cliente);
                if (!cadastrado)
                {
                    user = new { sucesso = false, message = "Erro inesperado, tente novemente." };
                    return Json(user);

                }
                user = new { sucesso = true, id = cliente.Id, nome = cliente.Nome, sobrenome = cliente.Sobrenome, pessoa = cliente.Pessoa, sexo = cliente.Sexo, message = validMessage };
                return Json(user);

            }
            else
            {
                user = new { sucesso = false, message = validMessage };
                return Json(user);
            }



        }

        [AutorizarLogin, HttpPost]
        public ActionResult AlterarDadosCliente(int id)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                object client = new { sucesso = false };


                var cliente = entity.Clientes.FirstOrDefault(p => p.Id == id);

                if (cliente != null)
                {
                    client = new { sucesso = true, id = cliente.Id, nome = cliente.Nome, sobrenome = cliente.Sobrenome , pessoa = cliente.Pessoa, sexo = cliente.Sexo };
                }
                return Json(client, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult AtualizarCliente(Cliente clienteEdit, int Id)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                object user = new { sucesso = false };
                string validMessage = "";

                if (validMessage == "")
                {
                    Cliente editDoClient = new Cliente();
                    try
                    {
                        editDoClient = entity.Clientes.Find(Id);

                    }
                    catch (Exception)
                    {
                        user = new { sucesso = false, message = "O usuário que você tenta editar não existe." };
                        return Json(user);
                    }


                    editDoClient.Nome = clienteEdit.Nome;
                    editDoClient.Sobrenome = clienteEdit.Sobrenome;
                    editDoClient.Pessoa = clienteEdit.Pessoa;
                    editDoClient.Sexo = clienteEdit.Sexo;

                    entity.SaveChanges();
                    user = new { sucesso = true, id = editDoClient.Id, nome = editDoClient.Nome, sobrenome = editDoClient.Sobrenome, pessoa = editDoClient.Pessoa, sexo = editDoClient.Sexo, message = "Cliente atualizado com sucesso." };
                    return Json(user);

                }
                user = new { sucesso = false, message = validMessage };
                return Json(user);

            }

        }

        [AutorizarLogin, HttpPost]
        public ActionResult RemoverCliente(Cliente cliente)
        {

            object user = new { sucesso = false };
            string validMessage = ""; //validações
            if (validMessage == "")
            {
                bool cadastrado = new HashGenerator().DeletarCliente(cliente);
                if (!cadastrado)
                {
                    user = new { sucesso = false, message = "Erro inesperado, tente novemente." };
                    return Json(user);

                }
                user = new { sucesso = true, id = cliente.Id, nome = cliente.Nome, sobrenome = cliente.Sobrenome, pessoa = cliente.Pessoa, sexo = cliente.Sexo, message = validMessage };
                return Json(user);

            }
            else
            {
                user = new { sucesso = false, message = validMessage };
                return Json(user);
            }



        }

    }



}
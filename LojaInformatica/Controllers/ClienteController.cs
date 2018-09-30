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

        [AutorizarLogin]
        public ActionResult AlterarDadosCliente(int id)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {

                var usuario = entity.Usuarios.FirstOrDefault(p => p.Id == id);
                ViewBag.usuario = usuario;

                return View(usuario);
            }

        }


    }
}
using LojaInformatica.BLL;
using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace LojaInformatica.Controllers
{
    public class OrdemServicoController : Controller
    {
        // GET: OrdemServico
        public ActionResult GerenciarServicos()
        {
            IList<Pedido> pedidos = ListarPedidos();
            ViewBag.Servicos = pedidos;
            IList<Produto> produtos = ListarProdutos();
            ViewBag.Produtos = produtos;
            IList<Cliente> clientes = ListarClientes();
            ViewBag.Clientes = clientes;
            return View();
        }

        public IList<Pedido> ListarPedidos()
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                var lista = entity.Pedidos.ToList();
                var OrderById = lista.OrderByDescending(u => u.Id).ToList();
                var MostrarElementos = OrderById.Take(10).ToList();

                return MostrarElementos;
            }
        }


        public IList<Produto> ListarProdutos()
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                var lista = entity.Produtos.ToList();
                var OrderById = lista.OrderByDescending(u => u.Id).ToList();
                var MostrarElementos = OrderById.ToList();

                return MostrarElementos;
            }
        }

        public IList<Cliente> ListarClientes()
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                var lista = entity.Clientes.ToList();
                var OrderById = lista.OrderByDescending(u => u.Id).ToList();
                var MostrarElementos = OrderById.ToList();

                return MostrarElementos;
            }
        }

        [AutorizarLogin, HttpPost]
        public ActionResult CadastrarPedido(Pedido pedido, int Quantidade, int produtoId, int clienteId)
        {

            object user = new { sucesso = false };
            string validMessage = ""; //validações
            if (validMessage == "")
            {

                using (LojaInformaticaContext entity = new LojaInformaticaContext())
                {
                    Produto searchedProduto = entity.Produtos.FirstOrDefault(p => p.Id == produtoId);
                    Cliente searchedClient = entity.Clientes.FirstOrDefault(c => c.Id == clienteId);
                    if (searchedProduto == null)
                    {
                        user = new { sucesso = false, message = "Não foi possível encontrar o produto selecionado." };
                        return Json(user);
                    }
                    if (searchedClient == null)
                    {
                        user = new { sucesso = false, message = "Não foi possível localizar o cliente selecionado." };
                        return Json(user);
                    }
                    if (searchedProduto.Quantidade < Quantidade)
                    {
                        user = new { sucesso = false, message = "Estoque excedido, você ainda possui " + searchedProduto.Quantidade + " produtos disponíveis" };
                        return Json(user);
                    }
                    searchedProduto.Quantidade -= Quantidade;
                    entity.SaveChanges();
                    pedido.Cliente = searchedClient.Id;
                    pedido.Produto = searchedProduto.Id;
                    pedido.ValorTotal = searchedProduto.PrecoUnitario * Quantidade;

                    bool cadastrado = new PedidoBLL().RegistrarPedido(pedido);
                    if (!cadastrado)
                    {
                        user = new { sucesso = false, message = "Erro inesperado, tente novemente." };
                        return Json(user);

                    }
                    user = new { sucesso = true };
                    return Json(user);


                }
            }
            else
            {
                user =  new { sucesso = false };
                return Json(user);
                    }

        }

        public bool DeletarPedido(int id)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Pedido searched = entity.Pedidos.FirstOrDefault(c => id == c.Id);
                entity.Pedidos.Remove(searched);
                entity.SaveChanges();
                return true;
            }
        }



    }
   

}

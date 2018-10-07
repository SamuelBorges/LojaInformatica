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
    public class ProdutoController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            IList<Produto> produtos = ListarProdutos();
            ViewBag.Produtos = produtos;
            return View();
        }


        public IList<Produto> ListarProdutos()
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                var lista = entity.Produtos.ToList();
                var OrderById = lista.OrderByDescending(u => u.Id).ToList();
                var MostrarElementos = OrderById.Take(10).ToList();

                return MostrarElementos;

            }
        }

        [AutorizarLogin, HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {

            object product = new { sucesso = false };
            string validMessage = ""; //validações
            if (validMessage == "")
            {
                bool cadastrado = new HashGenerator().RegistrarProduto(produto);
                if (!cadastrado)
                {
                    product = new { sucesso = false, message = "Erro inesperado, tente novemente." };
                    return Json(product);

                }
                product = new { sucesso = true, id = produto.Id, nome = produto.Nome, descricao = produto.Descricao, precoUnitario = produto.PrecoUnitario, quantidade = produto.Quantidade, message = validMessage };
                return Json(product);

            }
            else
            {
                product = new { sucesso = false, message = validMessage };
                return Json(product);
            }



        }
    }
}
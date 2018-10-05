using LojaInformatica.BLL;
using LojaInformatica.DAO;
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
            return View();
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
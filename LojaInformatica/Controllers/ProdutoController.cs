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
                bool cadastrado = new ProdutoBLL().RegistrarProduto(produto);
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


        [AutorizarLogin, HttpPost]
        public ActionResult AlterarDadosProduto(int id)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                object product = new { sucesso = false };


                var produto = entity.Produtos.FirstOrDefault(p => p.Id == id);

                if (produto != null)
                {
                    product = new
                    {
                        sucesso = true,
                        id = produto.Id,
                        nome = produto.Nome,
                        descricao = produto.Descricao,
                        quantidade = produto.Quantidade,
                        precoUnitario = produto.PrecoUnitario
                    };
                }
                return Json(product, JsonRequestBehavior.AllowGet);
            }
        }



        [AutorizarLogin, HttpPost]
        public ActionResult AtualizarProduto(Produto produtoEdit, int Id)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                object user = new { sucesso = false };
                string validMessage = "";

                if (validMessage == "")
                {
                    Produto editDoProduct = new Produto();
                    try
                    {
                        editDoProduct = entity.Produtos.Find(Id);

                    }
                    catch (Exception)
                    {
                        user = new { sucesso = false, message = "O produto que você tenta editar não existe." };
                        return Json(user);
                    }


                    editDoProduct.Nome = produtoEdit.Nome;
                    editDoProduct.Descricao = produtoEdit.Descricao;
                    editDoProduct.Quantidade = produtoEdit.Quantidade;
                    editDoProduct.PrecoUnitario = produtoEdit.PrecoUnitario;

                    entity.SaveChanges();
                    user = new { sucesso = true, id = editDoProduct.Id, nome = editDoProduct.Nome, descricao = editDoProduct.Descricao, quantidade = editDoProduct.Quantidade, precoUnitario = editDoProduct.PrecoUnitario, message = "Produto atualizado com sucesso." };
                    return Json(user);

                }
                user = new { sucesso = false, message = validMessage };
                return Json(user);

            }

        }




        [AutorizarLogin, HttpPost]
        public ActionResult RemoverProduto(int id)
        {

            object product= new { sucesso = false };
            string validMessage = "";
            if (validMessage == "")
            {
                bool removido = new ProdutoBLL().DeletarProduto(id);
                if (!removido)
                {
                    product = new { sucesso = false, message = "Erro inesperado, tente novamente." };
                    return Json(product);

                }
                product = new { sucesso = true, message = validMessage };
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
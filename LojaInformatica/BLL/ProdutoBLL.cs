using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.BLL
{
    public class ProdutoBLL
    {
        public bool RegistrarProduto(Produto produto)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                entity.Produtos.Add(produto);
                entity.SaveChanges();
                return true;
            }
        }

        public bool DeletarProduto(int id)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Produto searched = entity.Produtos.FirstOrDefault(c => id == c.Id);
                entity.Produtos.Remove(searched);
                entity.SaveChanges();
                return true;
            }
        }
    }
}
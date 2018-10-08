using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.BLL
{
    public class PedidoBLL
    {
        public bool RegistrarPedido(Pedido pedido)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                entity.Pedidos.Add(pedido);
                entity.SaveChanges();
                return true;
            }
        }
    }
}
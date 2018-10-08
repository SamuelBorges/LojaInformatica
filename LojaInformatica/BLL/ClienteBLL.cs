using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.BLL
{
    public class ClienteBLL
    {
        public bool RegistrarCliente(Cliente cliente)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                entity.Clientes.Add(cliente);
                entity.SaveChanges();
                return true;
            }
        }

        public bool DeletarCliente(int id)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Cliente searched = entity.Clientes.FirstOrDefault(c => id == c.Id);
                entity.Clientes.Remove(searched);
                entity.SaveChanges();
                return true;
            }
        }
    }
}
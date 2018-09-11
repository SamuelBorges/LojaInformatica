using LojaInformatica.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LojaInformatica.DAO.DataBase
{

    public class LojaInformaticaContext : DbContext
    {

        public LojaInformaticaContext() : base("LojaInformaticaContxt")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<RegistroAcao> Acoes { get; set; }







    }
}
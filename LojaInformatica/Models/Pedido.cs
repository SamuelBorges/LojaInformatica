using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.DAO
{
    public class Pedido
    {
        public int Id { get; private set; }

        public IList<Produto> produto { get; set; }
    }
}
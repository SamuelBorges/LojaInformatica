using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.DAO
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime DataDoPedido { get; set; }

        public int Cliente { get; set; }

        public int Produto { get; set; }

        public int Usuario { get; set; }

        public double ValorTotal { get; set; }

        public string Observacao { get; set; }
    }
}
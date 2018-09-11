using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.DAO
{
    public class OrdemServico
    {
        public int Id { get; set; }

        public DateTime DataDoPedido { get; set; }

        public Cliente Cliente { get; set; }

        public Produto Equipamento { get; set; }

        public Usuario Funcionario { get; set; }

        public double ValorTotal { get; set; }

        public string Observacao { get; set; }
    }
}
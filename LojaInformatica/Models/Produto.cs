using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.DAO
{
    public class Produto
    {
        public int Id { get; private set; }

        public string Codigo { get; private set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public double PrecoUnitario { get; set; }

        public double PrecoTotal { get; set; }

        public Marca Marca { get; set; }
    }
}
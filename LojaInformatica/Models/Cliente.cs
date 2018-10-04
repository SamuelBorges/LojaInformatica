using LojaInformatica.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.DAO
{
    public class Cliente
    {
        public int Id { get; private set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public TipoPessoa Pessoa { get; set; }

        public Sexo Sexo { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Rua { get; set; }

        public int NumeroCasa { get; set; }

        public string Complemento { get; set; }


    }
}
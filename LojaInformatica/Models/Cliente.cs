using LojaDeInformatica.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDeInformatica.DAO
{
    public class Cliente
    {
        public int Id { get; private set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public TipoPessoa Pessoa { get; set; }

        public Sexo Sexo { get; set; }

        public Endereco Endereco { get; set; }


    }
}
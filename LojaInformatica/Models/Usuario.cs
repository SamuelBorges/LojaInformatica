using LojaInformatica.DAO.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaInformatica.DAO
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string Senha { get; set; }

        public string Hash { get; set; }

        public string Salt { get; set; }

        public NivelAcesso NivelAcesso { get; set; }

        public bool Ativo { get; set; }

        public int NumeroAcessos { get; set; }
    }
    
}
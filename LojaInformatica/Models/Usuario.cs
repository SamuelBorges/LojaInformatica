﻿using LojaDeInformatica.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDeInformatica.DAO
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Hash { get; set; }

        public string Salt { get; set; }

        public NivelAcesso NivelAcesso { get; set; }

        public bool Ativo { get; set; }
    }
    
}
using LojaInformatica.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.DAO
{
    public class RegistroAcao
    {
        public int Id { get; set; }

        public Usuario usuario { get; set; }

        public Acoes acaoTomada { get; set; }
    }
}
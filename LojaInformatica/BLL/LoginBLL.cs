using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.BLL
{
    public class LoginBLL
    {
        public bool EhPrimeiroAcesso(Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Usuario searchedEmail = entity.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                if (searchedEmail.NumeroAcessos == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public bool EhAtivo(Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Usuario UserId = entity.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                if (UserId.Ativo)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
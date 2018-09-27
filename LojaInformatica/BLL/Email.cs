using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.BLL
{
    public class Email
    {

        public bool emailExiste(Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Usuario searchedEmail = entity.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                if (searchedEmail == null)
                {
                    return false;
                }
                return true;

            }
        }
        public bool emailValido(Usuario usuario)
        {
            var email = new System.Net.Mail.MailAddress(usuario.Email);

            if (email.Address!=usuario.Email)
            {
                return false;
            }
            return true;
        }



    }
}
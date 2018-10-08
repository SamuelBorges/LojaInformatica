using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.BLL
{

    public class HashGenerator
    {


        public bool VerificarSenha(Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {

                if (usuario.Senha == null)
                {
                    return false;
                }
                else 
                {
                    string passwordToHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    Usuario searchedPassword = entity.Usuarios.FirstOrDefault(u => u.Hash == usuario.Hash);
                    return BCrypt.Net.BCrypt.Verify(usuario.Senha, passwordToHash);

                }

            }
        }

        public bool RegistrarAcesso(Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Usuario searchedEmail = entity.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                searchedEmail.NumeroAcessos += 1;
                entity.SaveChanges();
            }
            return true;
        }

       



    }
}
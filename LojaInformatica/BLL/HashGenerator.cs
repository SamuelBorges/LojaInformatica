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
        public bool VerificarEmail(Usuario usuario)
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

        public bool Cadastrar(Usuario usuario)
        {

            usuario.Hash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.Salt = BCrypt.Net.BCrypt.GenerateSalt();

            using (LojaInformaticaContext context = new LojaInformaticaContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
            return true;
        }





    }

}
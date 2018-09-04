using LojaDeInformatica.DAO;
using LojaDeInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDeInformatica.BLL
{

    public class HashGenerator
    {
        public bool Verificar(Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Usuario searched = entity.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                if (searched == null)
                {
                    return false;
                }
                string passwordToHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

                return BCrypt.Net.BCrypt.Verify(usuario.Senha, passwordToHash);
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
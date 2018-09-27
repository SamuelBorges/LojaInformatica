using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDInformatica.BLL
{
    public class AutentificarUsuario
    {
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

        
        public bool VerificarLogin(Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {

                //procura no banco
                Usuario searched = entity.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                if (searched == null)
                {
                    return false;
                }
                //verifica se a senha confere verificação de senha
                bool SenhaConfere = BCrypt.Net.BCrypt.Verify(usuario.Senha, usuario.Hash);

                return SenhaConfere;

            }
        }
    }
}
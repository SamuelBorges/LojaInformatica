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

        public bool RegistrarUsuario(Usuario usuario)
        {

            usuario.Hash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.Salt = BCrypt.Net.BCrypt.GenerateSalt();
            usuario.Ativo = true;

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                    entity.Usuarios.Add(usuario);
                    entity.SaveChanges();
                    return true;
            }
        }

        public bool RegistrarCliente(Cliente cliente)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                entity.Clientes.Add(cliente);
                entity.SaveChanges();
                return true;
            }
        }


        public bool RegistrarProduto(Produto produto)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                entity.Produtos.Add(produto);
                entity.SaveChanges();
                return true;
            }
        }
        public bool DeletarCliente(int id)
        {

            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Cliente searched = entity.Clientes.FirstOrDefault(c => id == c.Id);
                entity.Clientes.Remove(searched);
                entity.SaveChanges();
                return true;
            }
        }

        public bool ProcurarUsuario (Usuario usuario)
        {
            using (LojaInformaticaContext entity = new LojaInformaticaContext())
            {
                Usuario searchedEmail = entity.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                try
                {
                    if (searchedEmail.NivelAcesso == LojaInformatica.DAO.Enum.NivelAcesso.Administrador)
                    {
                        return true;
                    }
                    return false;

                }
                catch (Exception)
                {

                    return false;
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
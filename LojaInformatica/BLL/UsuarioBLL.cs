using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using LojaInformatica.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LojaInformatica.BLL
{
    public class UsuarioBLL
    {

        public string EhUserValido(Usuario usuario)
        {
            //campos nulos
            if (usuario.Senha == null || usuario.Nome == null || usuario.Email == null)
            {
                return "Todos os campos devem ser informados.";
            }
            //nome
            String patterns = @"[a-zA-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+";
            if (Regex.IsMatch(usuario.Nome, patterns))
            {
                usuario.Nome = Regex.Match(usuario.Nome, patterns).ToString();
            }
            else
            {
                return "Nome inválido!";
            }
            if (usuario.Nome.Length < 3 || usuario.Nome.Length > 45)
            {
                return "O tamanho do nome é inválido!";
            }
            //senha
            if (usuario.Senha.Length < 8)
            {
                return "Senha muito fraca!";
            }
            if (usuario.Senha.Length > 45)
            {
                return "Senha muito longa! Informe no máximo 45 caracteres.";
            }
            //email


            Regex pattern = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!pattern.IsMatch(usuario.Email))
            {
                return "Endereço de email inválido!";
            }
            return "";
            
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

        public bool ProcurarUsuario(Usuario usuario)
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

    }
}
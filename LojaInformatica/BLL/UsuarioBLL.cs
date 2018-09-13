    using LojaInformatica.DAO;
using LojaInformatica.DAO.DataBase;
using LojaInformatica.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.BLL
{
    public class UsuarioBLL
    {

        public bool VerificarInformacoesUsuario(Usuario usuario)
        {

            if (usuario.Nome.Length < 3 || usuario.Nome.Length>45)
            {
                return false;
            }

            //Chamar método de validação de email

            if (usuario.Senha.Length<8)
            {
                return false;
            }
            if (usuario.Senha.Length > 45)
            {
                return false;
            }
            return true;


        }
    }
}
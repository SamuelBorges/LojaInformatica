﻿using LojaInformatica.BLL;
using LojaInformatica.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaInformatica.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }
        [AutorizarLogin]
        public ActionResult PreencherCadastroLogin()
        {

            return View(new Usuario());
        }




        public ActionResult VerificarLogin(Usuario usuario)
        {
            bool EmailSucesso = new HashGenerator().VerificarEmail(usuario);
            bool SenhaSucesso = new HashGenerator().VerificarSenha(usuario);

            if (EmailSucesso && SenhaSucesso)
            {
                Session["usuarioLogado"] = usuario;

                bool novoAcesso = new HashGenerator().RegistrarAcesso(usuario);
                bool PrimeiraVez = new HashGenerator().EhPrimeiroAcesso(usuario);

                if (!PrimeiraVez)
                {
                    return RedirectToAction("Index", "Home");
                }
                    return RedirectToAction("AlterarSenha", "Usuario");
            }
                
                return RedirectToAction("Index", "Login");
        }


    }
}
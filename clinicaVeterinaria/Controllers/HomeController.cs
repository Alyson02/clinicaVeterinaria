using clinicaVeterinaria.Dados;
using clinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace clinicaVeterinaria.Controllers
{
    public class HomeController : Controller
    {
        LoginAcoes acoesLogin = new LoginAcoes();

        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["usu"]?.ToString())) RedirectToAction("Menu");
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel login) //Realiza o teste de login, direcionando para o About ou novamente para o login com a mensagem de erro
        {
            acoesLogin.TestarUsuario(login);

            if (login.Usuario != null)
            {
                FormsAuthentication.SetAuthCookie(login.Usuario, false);
                Session["usu"] = login.Usuario;
                Session["tipo"] = login.IdTipoUsuario;

                return RedirectToAction("Menu", "Home");
            }
            else
            {
                ViewBag.msgLogar = "Usuário e/ou senha incorreto(s)";
                return View();
            }
        }

        public ActionResult Menu()
        {
            if(string.IsNullOrEmpty(Session["usu"]?.ToString()))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Sair()
        {
            if (string.IsNullOrEmpty(Session["usu"]?.ToString()))
            {
                Session["usu"] = null;
                Session["tipo"] = null;
            }
            return RedirectToAction("Index");
        }

    }
}
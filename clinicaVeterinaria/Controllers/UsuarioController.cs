using clinicaVeterinaria.Dados;
using clinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaVeterinaria.Controllers
{
    public class UsuarioController : Controller
    {
        LoginAcoes acoesLogin = new LoginAcoes();

        public void CarregaUsuario()
        {
            List<SelectListItem> usu = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_veterinaria;User=root;pwd=root"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tipoUsuario;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    usu.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.tipo = new SelectList(usu, "Value", "Text");
        }

        public ActionResult CadLogin() //Carrega a página de cadastro do Login
        {
            if (Session["usu"] != null && Session["tipo"].ToString() == "1")
            {
                CarregaUsuario();
                return View();
            }
            else
            {
                return RedirectToAction("Menu", "Home");
            }
        }
        [HttpPost]
        public ActionResult CadLogin(LoginModel cmLogin) //Efetua o cadastro do Login
        {
            CarregaUsuario();
            if (cmLogin.Senha == cmLogin.ConfirmarSenha)
            {
                var tipo = Request["tipo"];
                cmLogin.IdTipoUsuario = int.Parse(tipo);
                acoesLogin.inserirLogin(cmLogin);
                Response.Write("<script>alert('Cadastro realizado com sucesso')</script>");
            }
            else
            {
                Response.Write("<script>alert('Senhas nao conferem')</script>");
            }
            return View();

        }

        public ActionResult GetUsuarios()
        {
            if (string.IsNullOrEmpty(Session["usu"]?.ToString()))
            {
                return RedirectToAction("Index", "Home");
            }
            GridView dgv = new GridView();
            dgv.DataSource = acoesLogin.ConsultaUsuarios();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
    }
}
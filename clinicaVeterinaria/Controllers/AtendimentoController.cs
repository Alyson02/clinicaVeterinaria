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
    public class AtendimentoController : Controller
    {
        AtendimentoAcoes atendimentoAcoes = new AtendimentoAcoes();

        public void CarregaVeterinarios()
        {
            List<SelectListItem> ag = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_veterinaria;User=root;pwd=root"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from veterinario;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ag.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.veterinario = new SelectList(ag, "Value", "Text");
        }

        public void CarregaAnimais()
        {
            List<SelectListItem> ag = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_veterinaria;User=root;pwd=root"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from animal;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ag.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.animal = new SelectList(ag, "Value", "Text");
        }

        public ActionResult CreateAtendimento() //Carrega a página de cadastro do Tipo
        {
            if (string.IsNullOrEmpty(Session["usu"]?.ToString()) || Session["tipo"]?.ToString() != "1")
            {
                return RedirectToAction("Index", "Home");
            }
            CarregaAnimais();
            CarregaVeterinarios();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAtendimento(AtendimentoModel atendimento) //Efetua o cadastro
        {
            CarregaAnimais();
            CarregaVeterinarios();

            atendimentoAcoes.TestarAtendimento(atendimento);

            if (atendimento.confAtendimento == "0")
            {
                ViewBag.Msg = "Data/Hora indisponivel";
            }
            else
            {
                atendimento.IdAnimal = int.Parse(Request["animal"]);
                atendimento.IdVeterinario = int.Parse(Request["veterinario"]);

                atendimentoAcoes.inserirAtendimento(atendimento);
                Response.Write("<script>alert('Cadastro realizado com sucesso')</script>");
            }
            return View();
        }

        public ActionResult GetAtendimentos()
        {
            if (string.IsNullOrEmpty(Session["usu"]?.ToString()))
            {
                return RedirectToAction("Index", "Home");
            }
            GridView dgv = new GridView();
            dgv.DataSource = atendimentoAcoes.ConsultaAtendimento();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
    }
}
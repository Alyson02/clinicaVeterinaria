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
    public class AnimalController : Controller
    {
        AnimalAcoes animalAcoes = new AnimalAcoes();

        public void CarregaTipoAnimais()
        {
            List<SelectListItem> ag = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_veterinaria;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tipoAnimal;", con);
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


            ViewBag.tipoAnimal = new SelectList(ag, "Value", "Text");
        }

        public void CarregaClientes()
        {
            List<SelectListItem> ag = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_veterinaria;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from cliente;", con);
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


            ViewBag.cliente = new SelectList(ag, "Value", "Text");
        }

        public ActionResult CreateAnimal() //Carrega a página de cadastro do Tipo
        {
            CarregaClientes();
            CarregaTipoAnimais();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAnimal(AnimalModel animal) //Efetua o cadastro
        {
            CarregaClientes();
            CarregaTipoAnimais();

            animal.IdCliente =  int.Parse(Request["cliente"]);
            animal.IdTipo =  int.Parse(Request["tipoAnimal"]);

            animalAcoes.inserirAnimal(animal);
            ViewBag.msgCad = "Cadastro Efetuado";
            return View();
        }

        public ActionResult GetAnimals()
        {
            GridView dgv = new GridView();
            dgv.DataSource = animalAcoes.ConsultaAnimal();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
    }
}
using clinicaVeterinaria.Dados;
using clinicaVeterinaria.Models;
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
    public class TipoAnimalController : Controller
    {
        TipoAnimalAcoes tipoAnimalAcoes = new TipoAnimalAcoes();

        public ActionResult CreateTipoAnimal() //Carrega a página de cadastro do Tipo
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTipoAnimal(TipoAnimalModel tipoAnimal) //Efetua o cadastro
        {
            tipoAnimalAcoes.inserirTipoAnimal(tipoAnimal);
            ViewBag.msgCad = "Cadastro Efetuado";
            return View();
        }

        public ActionResult GetTipoAnimais()
        {
            GridView dgv = new GridView();
            dgv.DataSource = tipoAnimalAcoes.ConsultaTipoAnimal();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
    }
}
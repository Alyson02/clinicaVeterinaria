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
    public class VeterinarioController : Controller
    {
        VeterinarioAcoes veterinarioAcoes = new VeterinarioAcoes();

        public ActionResult CreateVeterinario() //Carrega a página de cadastro do Tipo
        {
            if (string.IsNullOrEmpty(Session["usu"]?.ToString()) || Session["tipo"]?.ToString() != "1")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateVeterinario(VeterinarioModel veterinario) //Efetua o cadastro
        {
            veterinarioAcoes.inserirVeterinario(veterinario);
            Response.Write("<script>alert('Cadastro realizado com sucesso')</script>");
            return View();
        }

        public ActionResult GetVeterinarios()
        {
            if (string.IsNullOrEmpty(Session["usu"]?.ToString()))
            {
                return RedirectToAction("Index", "Home");
            }
            GridView dgv = new GridView();
            dgv.DataSource = veterinarioAcoes.ConsultaVeterinario();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
    }
}
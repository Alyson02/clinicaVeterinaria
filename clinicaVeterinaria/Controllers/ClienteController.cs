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
    public class ClienteController : Controller
    {
        ClienteAcoes clienteAcoes = new ClienteAcoes();

        public ActionResult CreateCliente() //Carrega a página de cadastro do Tipo
        {
            if (string.IsNullOrEmpty(Session["usu"]?.ToString()) || Session["tipo"]?.ToString() != "1")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateCliente(ClienteModel cliente) //Efetua o cadastro
        {
            clienteAcoes.inserirCliente(cliente);
            Response.Write("<script>alert('Cadastro realizado com sucesso')</script>");
            return View();
        }

        public ActionResult GetClientes()
        {
            if (string.IsNullOrEmpty(Session["usu"]?.ToString()))
            {
                return RedirectToAction("Index", "Home");
            }
            GridView dgv = new GridView();
            dgv.DataSource = clienteAcoes.ConsultaCliente();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
    }
}
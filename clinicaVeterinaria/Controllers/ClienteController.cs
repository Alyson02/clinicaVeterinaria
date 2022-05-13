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
            return View();
        }

        [HttpPost]
        public ActionResult CreateCliente(ClienteModel cliente) //Efetua o cadastro
        {
            clienteAcoes.inserirCliente(cliente);
            ViewBag.msgCad = "Cadastro Efetuado";
            return View();
        }

        public ActionResult GetClientes()
        {
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
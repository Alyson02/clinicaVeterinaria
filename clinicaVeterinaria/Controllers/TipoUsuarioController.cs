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
    public class TipoUsuarioController : Controller
    {
        TipoUsuarioAcoes tipoUsuarioAcoes = new TipoUsuarioAcoes();

        public ActionResult CreateTipoUsuario() //Carrega a página de cadastro do Tipo
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTipoUsuario(TipoUsuarioModel tipoUsuario) //Efetua o cadastro
        {
            tipoUsuarioAcoes.inserirTipoUsu(tipoUsuario);
            ViewBag.msgCad = "Cadastro Efetuado";
            return View();
        }

        public ActionResult GetTipoUsuarios()
        {
            GridView dgv = new GridView();
            dgv.DataSource = tipoUsuarioAcoes.ConsultaTipo();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
    }
}
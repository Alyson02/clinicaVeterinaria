using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome do cliente")]
        public string Nome { get; set; }
        [Display(Name = "Telefone do cliente")]
        public string Telefone { get; set; }
        [Display(Name = "Email do cliente")]
        public string Email { get; set; }
    }
}
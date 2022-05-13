using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Models
{
    public class TipoUsuarioModel
    {
        public int Id { get; set; }
        [Display(Name = "Tipo do Usuário")]
        public string Usuario { get; set; }

    }
}
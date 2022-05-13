using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Models
{
    public class TipoAnimalModel
    {
        [Key()]
        public int id { get; set; }
        [Display(Name = "Nome do tipo do animal")]
        public string Tipo { get; set; }
    }
}
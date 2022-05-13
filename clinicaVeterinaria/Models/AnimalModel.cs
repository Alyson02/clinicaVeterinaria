using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Models
{
    public class AnimalModel
    {
        [Key()]
        public int id { get; set; }
        [Display(Name = "Nome do animal")]
        public string Nome { get; set; }
        public int IdCliente { get; set; }
        public int IdTipo { get; set; }
}
}
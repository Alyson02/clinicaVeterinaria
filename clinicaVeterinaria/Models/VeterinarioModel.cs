using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Models
{
    public class VeterinarioModel
    {
        [Key()]
        public int Id { get; set; }
        [Display(Name = "Nome do veterinario")]
        public string Nome { get; set; }
    }
}
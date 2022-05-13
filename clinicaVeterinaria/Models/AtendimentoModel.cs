using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Models
{
    public class AtendimentoModel
    {
        [Key()]
        public int Id { get; set; }
        [Display(Name = "Data do atendimento")]
        public string Data { get; set; }
        [Display(Name = "Horario do atendimento")]
        public string Hora { get; set; }
        public int IdVeterinario { get; set; }
        public int IdAnimal { get; set; }
        public string confAtendimento { get; set; }
    }
}
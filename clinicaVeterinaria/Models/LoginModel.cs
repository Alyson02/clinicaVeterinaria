using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Models
{
    public class LoginModel
    {
        [Display(Name = "Login")]
        public string Usuario { get; set; }
        public string Senha { get; set; }
        [Display(Name = "Tipo do usuário")]
        public int IdTipoUsuario { get; set; }

        public string ConfirmarSenha { get; set; }
    }
}
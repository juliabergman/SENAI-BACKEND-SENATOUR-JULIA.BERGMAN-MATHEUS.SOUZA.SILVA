using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage ="NAO")]
        public string Email { get; set; }

        [Required(ErrorMessage = "NAO")]
        public string Senha { get; set; }
    }
}

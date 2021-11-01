using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CalledWebMVC.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
       
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }

        
        
    }
}

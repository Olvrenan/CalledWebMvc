using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CalledWebMVC.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        [Remote(action: "UsuarioExiste", controller: "Usuario")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }


        public ICollection<InformacaoLogin> InformacoesLogin { get; set; }
    }
}

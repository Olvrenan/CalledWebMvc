using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;


namespace CalledWebMVC.Models
{
    public class Functionary
    {

        //****Informações pessoais****
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} O tamanho deve ser entre {2} and {1}")]
        public string Name { get; set; }

        [StringLength(13, MinimumLength = 3,  ErrorMessage = "{0} O tamanho deve ser entre {2} and {1}")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [EmailAddress(ErrorMessage = "Entre com um E-mail valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contato")]
        public string Phone { get; set; }


        //*****Informações Corporativas****
        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public Occupations Occupation { get; set; }
       

        [Display(Name = "Contrato")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public ContractTypes TypeContract { get; set; }

        //Lista de tarefas atribuidas 
       
        public ICollection<FuncionaryTask> FuncionaryTasks { get; set; }

        public Functionary()
        {
        }
        public Functionary(int id, string name, string rg, DateTime birthDay, string email, string phone, Occupations occupation, ContractTypes typeContract)
        {
            Id = id;
            Name = name;
            Rg = rg;
            BirthDay = birthDay;
            Email = email;
            Phone = phone;
            Occupation = occupation;
            TypeContract = typeContract;
        }
        public Functionary(int id, string name, string rg, DateTime birthDay, string email, string phone, Occupations occupation, ContractTypes typeContract, string task)
        {
            Id = id;
            Name = name;
            Rg = rg;
            BirthDay = birthDay;
            Email = email;
            Phone = phone;
            Occupation = occupation;
            TypeContract = typeContract;
           
        }
    }
}

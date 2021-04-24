using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;


namespace CalledWebMVC.Models
{
    public class Funcionary
    {

        //****Informações pessoais****
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }
        public string Rg { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }

        //*****Informações Corporativas****
        public string Occupation { get; set; }
       
        [Display(Name = "Type Contract")]
        public ContractTypes TypeContract { get; set; }

        //Lista de tarefas atribuidas 
        public string Task { get; set; }

        public Funcionary()
        {
        }
        public Funcionary(int id, string name, string rg, DateTime birthDay, string email, string phone, string occupation, ContractTypes typeContract)
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
        public Funcionary(int id, string name, string rg, DateTime birthDay, string email, string phone, string occupation, ContractTypes typeContract, string task)
        {
            Id = id;
            Name = name;
            Rg = rg;
            BirthDay = birthDay;
            Email = email;
            Phone = phone;
            Occupation = occupation;
            TypeContract = typeContract;
            Task = task;
        }
    }
}

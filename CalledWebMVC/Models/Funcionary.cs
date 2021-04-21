using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Models.Enums;

namespace CalledWebMVC.Models
{
    public class Funcionary
    {   
        //****Informações pessoais****
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rg { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //*****Informações Corporativas****
        public string Occupation { get; set; }
        public ContractTypes TypeContract { get; set; }

        //Lista de tarefas atribuidas 
        public string Task { get; set; }
    }
}

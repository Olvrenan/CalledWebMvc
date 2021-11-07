using CalledWebMVC.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalledWebMVC.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime Datecreated { get; set; }

        [Display(Name = "Data de Entrega")]
        public DateTime DateDone { get; set; }

        public Sprint Sprint { get; set; }

        [Display(Name = "Sprint")]
        
        public int SprintId { get; set; }


        [Display(Name = "Funcionário")]
        public Functionary Functionary { get; set; }


        [Display(Name = "Funcionário")]
        public int FunctionaryId { get; set; }

        public string Categoria { get; set; }

        [Display(Name = "Status")]
        public Status TaskStatus { get; set; }

        public ICollection<FuncionaryTask> FuncionaryTasks { get; set; }
        public Task()
        {
        }
        public Task(string title, DateTime dateCreated, DateTime dateDone)
        {
            Title = title;
            Datecreated = dateCreated;
            DateDone = dateDone;
        }

        
       


    }

    
}

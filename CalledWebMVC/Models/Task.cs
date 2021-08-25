using CalledWebMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Funcionário")]
        public Functionary Functionary { get; set; }
        public int FunctionaryId { get; set; }
        public String Categoria { get; set; }
        public String Sprint { get; set; }

        [Display(Name = "Status")]
        public TaskStatus TaskStatus { get;  }


        //public virtual IList<Task> Tasks { get; set; }

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

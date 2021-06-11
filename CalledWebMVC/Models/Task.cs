using CalledWebMVC.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CalledWebMVC.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime DateDone { get; set; }
        public Functionary Functionary { get; set; }
        public int FunctionaryId { get; set; }
        public String Categoria { get; set; }
        public String Sprint { get; set; }
        public TaskStatus TaskStatus { get; set; }

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

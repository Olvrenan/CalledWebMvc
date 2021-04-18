using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Models
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime DateDone { get; set; }
        public string Assingn { get; set; }

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

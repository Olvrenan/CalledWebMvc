using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginSprint { get; set; }
        public DateTime EndSprint { get; set; }
        public string MetaSprint { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
       
        //[NotMapped]
        //public bool status { get; set; }


        public Sprint() {}
        public Sprint(int id, string name, DateTime beginSprint, DateTime endSprint, string metaSprint)
        {
            Id = id;
            Name = name;
            BeginSprint = beginSprint;
            EndSprint = endSprint;
            MetaSprint = metaSprint;
           
        }

        //public bool StatusSprint(bool statusSprint)
        //{
        //    if (DateTime.Today >= EndSprint)
        //    {
        //        return statusSprint = false;
        //    }
        //    else return statusSprint = true;
        //}
    }
}

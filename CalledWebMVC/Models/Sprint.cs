using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CalledWebMVC.Models
{
    public class Sprint
    {
        public int Id { get; set; }

        [Display(Name= "Nome")]
        public string Name { get; set; }
        [Display(Name = "Data Inicial")]
        public DateTime BeginSprint { get; set; }
        [Display(Name = "Data Final")]
        public DateTime EndSprint { get; set; }
        [Display(Name = "Sprint Goal")]
        public string MetaSprint { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
       
       


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

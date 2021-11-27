using CalledWebMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalledWebMVC.Models.ViewModels
{
    public class TaskFormViewModel
    {
        public Task Task { get; set; }
        public ICollection<Functionary> Functionaries { get; set; }
        public ICollection<Sprint> Sprints { get; set; }

        [Display(Name = "Titulo")]
        public string Title { get; internal set; }

        [Display(Name = "Status")]
        public Status TaskStatus { get; internal set; }
        public int Id { get; internal set; }
        public string Categoria { get; internal set; }

        [Display(Name = "Funcionário")] 
        public string FunctionaryName { get; internal set; }
        public int SprintId { get; internal set; }
        public string Name { get; internal set; }
        public DateTime BeginSprint { get; internal set; }
        public string MetaSprint { get; internal set; }
        public DateTime EndSprint { get; internal set; }
        public DateTime DateDone { get;  set; }
    }
}

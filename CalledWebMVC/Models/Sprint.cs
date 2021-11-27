using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CalledWebMVC.Models
{
    public class Sprint
    {
        public int Id { get; set; }


        [Display(Name= "Nome")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Data Inicio")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public DateTime BeginSprint { get; set; }

        [Display(Name = "Data Final")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public DateTime EndSprint { get; set; }

        [Display(Name = "Sprint Goal")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string MetaSprint { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();

        public ICollection<Projeto> Projetos { get; set; }

        public Projeto Projeto { get; set; }

        [Display(Name = "Projeto")]
        public int ProjetoId { get; set; }


        public Sprint() {}
        public Sprint(int id, string name, DateTime beginSprint, DateTime endSprint, string metaSprint, int projeto)
        {
            Id = id;
            Name = name;
            BeginSprint = beginSprint;
            EndSprint = endSprint;
            MetaSprint = metaSprint;
            ProjetoId = projeto;
           
        }

    }
}

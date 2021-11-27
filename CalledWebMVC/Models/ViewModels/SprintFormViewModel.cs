using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Models.ViewModels
{
    public class SprintFormViewModel
    {
        public Sprint Sprint { get; set; }
        public ICollection<Projeto> Projetos { get; set; }
        public string Name { get; internal set; }
        public int Id { get; internal set; }

        [Display(Name = "Data Final")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndSprint { get; internal set; }
        public int ProjetoId { get; internal set; }

        [Display(Name = "Data Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BeginSprint { get; internal set; }

        [Display(Name = "Meta da Sprint")]
        public string MetaSprint { get; internal set; }
        public string Identificadores { get; set; }
    }
}

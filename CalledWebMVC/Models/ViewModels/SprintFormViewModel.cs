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

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndSprint { get; internal set; }
        public int ProjetoId { get; internal set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BeginSprint { get; internal set; }
        public string MetaSprint { get; internal set; }
        public string Identificadores { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Models.ViewModels
{
    public class SprintsProjetoViewModels
    {
        public Projeto Projeto { get; set; }

        public ICollection<Sprint> Sprints { get; set; }


    }
}

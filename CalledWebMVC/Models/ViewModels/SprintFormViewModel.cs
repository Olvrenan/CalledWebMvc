using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Models.ViewModels
{
    public class SprintFormViewModel
    {
        public Sprint Sprint { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}

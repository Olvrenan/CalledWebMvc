using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Models.Enums
{
    public class TaskFormViewModel
    {
        public Task Task { get; set; }
        public ICollection<Functionary> Functionarys { get; set; }
    }
}

using System.Collections.Generic;

namespace CalledWebMVC.Models.ViewModels
{
    public class TaskFormViewModel
    {
        public Task Task { get; set; }
        public ICollection<Functionary> Functionaries { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CalledWebMVC.Models.Enums
{
    public enum Status : int
    {
        [Display(Name = "A fazer")]
        Todo = 0,

        [Display(Name = "Em andamento")]
        InProgress = 1,
        Block = 2,
        Concluido = 3
    }
}

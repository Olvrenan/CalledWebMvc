using System.ComponentModel.DataAnnotations;

namespace CalledWebMVC.Models.Enums
{
    public enum TaskStatus : int
    {
        Backlog = 0,

        [Display(Name = "In Progress")]
        InProgress = 1,
        Block = 2,
        Done = 3
    }
}

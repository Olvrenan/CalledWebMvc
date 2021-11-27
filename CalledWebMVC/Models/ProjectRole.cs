using System.ComponentModel.DataAnnotations;

namespace CalledWebMVC.Models
{
    public class ProjectRole
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get;  set; }
    }
}
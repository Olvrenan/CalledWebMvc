using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginSprint { get; set; }
        public DateTime EndSprint { get; set; }
        public string MetaSprint { get; set; }
        public int Task { get; set; }

    }
}

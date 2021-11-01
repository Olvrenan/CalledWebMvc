using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CalledWebMVC.Models
{
    public class FuncionaryTask
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int FunctionaryId { get; set; }
        public Functionary Functionary { get; set; }
       
    }
}

using CalledWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Services
{
    public class SprintService
    {
        public readonly CalledWebMvcContext _context;

        public SprintService(CalledWebMvcContext context)
        {
            _context = context;
        }

    }
}

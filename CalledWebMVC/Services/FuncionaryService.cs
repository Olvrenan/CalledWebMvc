using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Models;

namespace CalledWebMVC.Services
{
    public class FuncionaryService
    {
        public readonly CalledWebMvcContext _context;

        public FuncionaryService(CalledWebMvcContext context)
        {
            _context = context;
        }

        public List<Funcionary> FindAll()
        {
            return _context.Funcionary.ToList();
        }
    }
}

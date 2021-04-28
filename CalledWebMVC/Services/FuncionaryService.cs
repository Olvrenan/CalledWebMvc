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
        public void Insert (Funcionary obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Funcionary FindById(int Id)
        {
            return _context.Funcionary.FirstOrDefault(obj => obj.Id == Id);
        }

        public void Remove (int id)
        {
            var obj = _context.Funcionary.Find(id);
            _context.Funcionary.Remove(obj);
            _context.SaveChanges();
        }
    }
}

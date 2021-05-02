using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Models;
using CalledWebMVC.Services.Exceptions;

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

        public void Update(Funcionary obj)
        {
            bool hasAny = _context.Funcionary.Any(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}

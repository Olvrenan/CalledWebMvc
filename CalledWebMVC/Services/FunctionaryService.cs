using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Models;
using CalledWebMVC.Services.Exceptions;

namespace CalledWebMVC.Services
{
    public class FunctionaryService
    {
        public readonly CalledWebMvcContext _context;

        public FunctionaryService(CalledWebMvcContext context)
        {
            _context = context;
        }

        public List<Functionary> FindAll()
        {
            return _context.Functionary.OrderBy(x => x.Name)
                .ToList();
        }
        public void Insert (Functionary obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Functionary FindById(int Id)
        {
            return _context.Functionary.FirstOrDefault(obj => obj.Id == Id);
        }

        public void Remove (int id)
        {
            var obj = _context.Functionary.Find(id);
            _context.Functionary.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Functionary obj)
        {
            bool hasAny = _context.Functionary.Any(x => x.Id == obj.Id);
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

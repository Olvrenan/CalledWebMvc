using System;
using System.Collections.Generic;
using System.Linq;
using CalledWebMVC.Models;
using CalledWebMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;



namespace CalledWebMVC.Services
{
    public class TaskService
    {
        public readonly CalledWebMvcContext _context;

        public TaskService(CalledWebMvcContext context)
        {
            _context = context;
        }

        public List<Task> FindAll()
        {
            return _context.Task.ToList();
        }

        public Task FindById(int id)
        {
            return _context.Task.Include(obj => obj.Functionary).FirstOrDefault(obj => obj.Id == id);
        }
        public void Insert (Task obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public void Update (Task obj)
        {
            bool hasAny = _context.Task.Any(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFiniteNumberException("id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CalledWebMVC.Models;

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
        public void Insert (Task obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CalledWebMVC.Models;
using CalledWebMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace CalledWebMVC.Services
{
    public class TaskService
    {
        public readonly CalledWebMvcContext _context;

        public TaskService(CalledWebMvcContext context)
        {
            _context = context;
        }

        public List<CalledWebMVC.Models.Task> FindAll()
        {

            return _context.Task.ToList();

        }

        public CalledWebMVC.Models.Task FindById(int id)
        {
            return _context.Task
                .Include(obj => obj.Functionary)
                .Include(obj => obj.Sprint)
                .FirstOrDefault(obj => obj.Id == id);
        }

        public async Task<IEnumerable<CalledWebMVC.Models.ViewModels.TaskFormViewModel>> FindBySprint(int id)
        {


            var data = await (from t1 in _context.Functionary
                              join t2 in _context.Task on t1.Id equals t2.FunctionaryId
                              join t3 in _context.Sprint on t2.SprintId equals t3.Id
                              orderby t2.Id
                              select new CalledWebMVC.Models.ViewModels.TaskFormViewModel
                              {
                                  Title = t2.Title,
                                  Id = t2.Id,
                                  TaskStatus = t2.TaskStatus,
                                  Categoria = t2.Categoria,
                                  FunctionaryName = t1.Name,
                                  SprintId = t2.SprintId,
                                  Name = t3.Name,
                                  MetaSprint = t3.MetaSprint,
                                  BeginSprint = t3.BeginSprint,
                                  EndSprint = t3.EndSprint

                              }).Where(x => x.SprintId == id).ToListAsync();


            return data;

            //return await _context.Task.Include(x => x.Sprint).Where(x => x.SprintId == id).ToListAsync();
        }


        public async Task<IEnumerable<CalledWebMVC.Models.ViewModels.TaskFormViewModel>> FindByTask(int id)
        {


            var data = await (from t1 in _context.Functionary
                              join t2 in _context.Task on t1.Id equals t2.FunctionaryId
                              join t3 in _context.Sprint on t2.SprintId equals t3.Id
                              orderby t2.Id
                              select new CalledWebMVC.Models.ViewModels.TaskFormViewModel
                              {
                                  Title = t2.Title,
                                  Id = t2.Id,
                                  TaskStatus = t2.TaskStatus,
                                  Categoria = t2.Categoria,
                                  FunctionaryName = t1.Name,
                                  SprintId = t2.SprintId,
                                  Name = t3.Name,
                                  MetaSprint = t3.MetaSprint,
                                  BeginSprint = t3.BeginSprint,
                                  EndSprint = t3.EndSprint,
                                  DateDone = t2.DateDone

                              }).Where(x => x.SprintId == id).ToListAsync();


            return data;

            //return await _context.Task.Include(x => x.Sprint).Where(x => x.SprintId == id).ToListAsync();
        }

        public void Insert(CalledWebMVC.Models.Task obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public void Update(CalledWebMVC.Models.Task obj)
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
        public void Remove(int id)
        {
            var obj = _context.Task.Find(id);
            _context.Task.Remove(obj);
            _context.SaveChanges();
        }

        public async Task<List<CalledWebMVC.Models.Task>> FindSprint()
        {
            var result = from obj in _context.Task select obj;

            return await result.ToListAsync();
        }

    }
}

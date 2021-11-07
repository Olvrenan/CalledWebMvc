using CalledWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Services.Exceptions;


namespace CalledWebMVC.Services
{
    public class SprintService
    {
        public readonly CalledWebMvcContext _context;

        public SprintService(CalledWebMvcContext context)
        {
            _context = context;
        }

        public Sprint FindById(int Id)
        {
            return _context.Sprint.FirstOrDefault(obj => obj.Id == Id); 
        }

        public  List<Sprint> FindAll()
        {
            return _context.Sprint.OrderBy(x=> x.Name).ToList();
        }

        public async Task<List<Sprint>> FindActiveSprints()
        {
            return await _context.Sprint.Where(x => x.EndSprint >= DateTime.Today).ToListAsync();
        } 

        public async Task<List<Sprint>> FindDoneSprints()
        {
            return await _context.Sprint.Where(x => x.EndSprint < DateTime.Today)
                .ToListAsync();
        }


        public void Insert(Sprint obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
        public void Update(Sprint obj)
        {
            bool hasAny = _context.Sprint.Any(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("id not found");
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

        public async Task<IEnumerable<CalledWebMVC.Models.ViewModels.SprintFormViewModel>> FindByProjetoSprintsActive(int id)
        {


            var data = await (from t1 in _context.Projeto
                              join t2 in _context.Sprint on t1.ProjetoId equals t2.ProjetoId
                              orderby t2.BeginSprint
                              select new CalledWebMVC.Models.ViewModels.SprintFormViewModel
                              {
                                  Name = t2.Name,
                                  Id = t2.Id,
                                  BeginSprint = t2.BeginSprint,
                                  EndSprint = t2.EndSprint,
                                  MetaSprint = t2.MetaSprint,
                                  ProjetoId = t1.ProjetoId,


                              }).Where(x => x.ProjetoId == id && x.EndSprint >= DateTime.Today)
                              
                              .ToListAsync();


            return data;

            //return await _context.Task.Include(x => x.Sprint).Where(x => x.SprintId == id).ToListAsync();
        }
        public async Task<IEnumerable<CalledWebMVC.Models.ViewModels.SprintFormViewModel>> FindByProjetoSprintsDone(int id)
        {


            var data = await (from t1 in _context.Projeto
                              join t2 in _context.Sprint on t1.ProjetoId equals t2.ProjetoId
                              orderby t2.BeginSprint
                              select new CalledWebMVC.Models.ViewModels.SprintFormViewModel
                              {
                                  Name = t2.Name,
                                  Id = t2.Id,
                                  BeginSprint = t2.BeginSprint,
                                  EndSprint = t2.EndSprint,
                                  MetaSprint = t2.MetaSprint,
                                  ProjetoId = t1.ProjetoId,


                              }).Where(x => x.ProjetoId == id && x.EndSprint < DateTime.Today)

                              .ToListAsync();


            return data;

            //return await _context.Task.Include(x => x.Sprint).Where(x => x.SprintId == id).ToListAsync();
        }

    }
}

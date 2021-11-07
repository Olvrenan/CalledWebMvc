using CalledWebMVC.Models;
using CalledWebMVC.Models.Enums;
using CalledWebMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Services
{
    public class ProjetoService
    {
        public readonly CalledWebMvcContext _context;

        public ProjetoService(CalledWebMvcContext context)
        {
            _context = context;
        }

        public Projeto FindById(int Id)
        {
            return _context.Projeto.FirstOrDefault(obj => obj.ProjetoId == Id);
        }

        public List<Projeto> FindAll()
        {
            return _context.Projeto.OrderBy(x => x.Nome).ToList();
        }

        public async Task<List<Projeto>> FindActiveProjetos()
        {
           
           var data =  await _context.Projeto.Where(x => x.Status == Status.InProgress || 
            x.Status == Status.Todo || 
            x.Status ==  Status.Block)
            .ToListAsync();




            return data;

        }

        public async Task<List<Projeto>> FindDoneProjetos()
        {
            
            var data = await _context.Projeto.Where(x => x.Status == Status.Concluido).ToListAsync();

            return data;
        }


        public void Insert(Projeto obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
        public void Update(Projeto obj)
        {
            bool hasAny = _context.Projeto.Any(x => x.ProjetoId == obj.ProjetoId);
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

        //public async Task<IEnumerable<CalledWebMVC.Models.Sprint>> FindBySprint(int id)
        //{


        //    var data = await (from t1 in _context.Projeto
        //                      join t2 in _context.Sprint on t1.ProjetoId equals t2.Id
        //                      orderby t2.BeginSprint
        //                      select new CalledWebMVC.Models.Sprint
        //                      {
        //                          Name = t2.Name,
        //                          Id = t2.Id,
        //                          BeginSprint = t2.BeginSprint,
        //                          EndSprint = t2.EndSprint,
        //                          MetaSprint = t2.MetaSprint,
        //                          ProjetoId = t1.ProjetoId,
                               

        //                      }).Where(x => x.ProjetoId == id).ToListAsync();


        //    return data;

        //    //return await _context.Task.Include(x => x.Sprint).Where(x => x.SprintId == id).ToListAsync();
        //}

    }
}

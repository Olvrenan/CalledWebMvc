using CalledWebMVC.Models;
using Microsoft.EntityFrameworkCore;
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
        public  List<Sprint> FindAll()
        {

            return _context.Sprint.OrderBy(x=> x.Name).ToList();
        }
        public async Task<List<Sprint>> FindActiveSprints()
        {

            //var data = await (from t1 in _context.Sprint
            //                  select new Models.Sprint { }
            //                 ).Where(x => x.EndSprint < DateTime.Today).ToListAsync();
            //return data;
            return await _context.Sprint.Where(x => x.EndSprint >= DateTime.Today).ToListAsync();
        }
        public void Insert(Sprint obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        //public List<IGrouping<Sprint,CalledWebMVC.Models.Task>> FindBySprint(int id)
        //{
        //    var result = from obj in _context.Task select obj; // construindo objeto do tipo IQueryable

        //    return result.Include(x => x.Sprint).Where(x => x.Id == id).Select(obj => new CalledWebMVC.Models.Task()).ToList();
            
        //}


    }
}

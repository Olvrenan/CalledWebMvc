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
            return await _context.Sprint.Where(x => x.EndSprint < DateTime.Today).ToListAsync();
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


    }
}

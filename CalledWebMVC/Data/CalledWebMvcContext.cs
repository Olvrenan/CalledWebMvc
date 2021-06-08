using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CalledWebMVC.Models
{
    public class CalledWebMvcContext : DbContext
    {
        public CalledWebMvcContext(DbContextOptions<CalledWebMvcContext> options)
            : base(options)
        { 
        }
        public DbSet<Functionary> Functionary { get; set; }
        public DbSet<Task> Task { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalledWebMVC.Models;

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
        public DbSet<Sprint> Sprint { get; set; }
        public DbSet<FuncionaryTask> FuncionaryTasks { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<InformacaoLogin> InformacaoLogin { get; set; }
        public DbSet<Projeto> Projeto { get; set; }


        //taskfuncionario relacionamento n para n 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuncionaryTask>().HasKey(sc => new { sc.FunctionaryId, sc.TaskId });
        }


        //taskfuncionario relacionamento n para n 
        public DbSet<CalledWebMVC.Models.ProjectRole> ProjectRole { get; set; }




        

    }
}

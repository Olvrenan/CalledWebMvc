using CalledWebMVC.Models;
using CalledWebMVC.Models.Enums;
using System;
using System.Linq;

namespace CalledWebMVC.Data
{
    public class SeedingService
    {
       readonly private CalledWebMvcContext _context;

        public SeedingService(CalledWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Functionary.Any() ||
                _context.Task.Any() ||
                _context.Sprint.Any())
            {
                return; //verifica se o DB esta populado
            }

            Functionary f1 = new Functionary(1, "Jesse Pinkman", "123.456.789-3", new DateTime(1990, 05, 02), "Jesse@hotmail.com", "9999-8888", Occupations.Armador, ContractTypes.Funcionario);
            Functionary f2 = new Functionary(2, "Alex Pink", "123.456.789-3", new DateTime(1998, 4, 21), "bob@gmail.com", "9777-8888", Occupations.Carpinteiro, ContractTypes.Funcionario);
            Functionary f3 = new Functionary(3, "Bob Brown", "123.456.789-3", new DateTime(1979, 12, 31), "bob@gmail.com", "9345-8888", Occupations.Eletricista, ContractTypes.Funcionario);
            Functionary f4 = new Functionary(4, "Maria Green", "123.456.789-3", new DateTime(1988, 1, 15), "maria@gmail.com", "9333-8888", Occupations.Encanador, ContractTypes.Colaborador);
            Functionary f5 = new Functionary(5, "Alex Grey", "123.456.789-3", new DateTime(1997, 3, 4), "alex@gmail.com", "9999-8888", Occupations.Pedreiro, ContractTypes.Funcionario);
            Functionary f6 = new Functionary(6, "Martha Red", "123.456.789-3", new DateTime(2000, 1, 9), "martha@gmail.com", "9444-8888", Occupations.Armador, ContractTypes.Funcionario);
            Functionary f7 = new Functionary(7, "Donald Blue", "123.456.789-3", new DateTime(1988, 1, 15), "donald@gmail.com", "9666-8888", Occupations.Carpinteiro, ContractTypes.Colaborador);

            Sprint s1 = new Sprint(1, "Sprint 1", new DateTime(2021, 03, 01), new DateTime(2021, 03, 15), "Concluir todas as atividades");
            Sprint s2 = new Sprint(2, "Sprint 2", new DateTime(2021, 03, 18), new DateTime(2021, 03, 30), "Concluir todas as atividades");
            //Sprint s3 = new Sprint(3, "Sprint 3", new DateTime(2021, 04, 01), new DateTime(2021, 03, 15), "Concluir todas as atividades");
            //Sprint s4 = new Sprint(4, "Sprint 4", new DateTime(2021, 04, 18), new DateTime(2021, 03, 30), "Concluir todas as atividades");
            //Sprint s5 = new Sprint(5, "Sprint 5", new DateTime(2021, 05, 01), new DateTime(2021, 03, 15), "Concluir todas as atividades");
            //Sprint s6 = new Sprint(6, "Sprint 6", new DateTime(2021, 05, 18), new DateTime(2021, 03, 30), "Concluir todas as atividades");
            //Sprint s7 = new Sprint(7, "Sprint 7", new DateTime(2021, 06, 01), new DateTime(2021, 03, 15), "Concluir todas as atividades");


            _context.Functionary.AddRange(f1, f2, f3, f4, f5, f6, f7);
            _context.Sprint.AddRange(s1, s2/* s3, s4, s5, s6, s7*/);

            _context.SaveChanges();
        }

    }
}

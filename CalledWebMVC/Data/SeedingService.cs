using CalledWebMVC.Models;
using CalledWebMVC.Models.Enums;
using System;
using System.Linq;

namespace CalledWebMVC.Data
{
    public class SeedingService
    {
        private CalledWebMvcContext _context;

        public SeedingService(CalledWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Funcionary.Any())
            {
                return; //verifica se o DB esta populado
            }

            Funcionary f1 = new Funcionary(1, "Jesse Pinkman", "123.456.789-3", new DateTime(1990, 05, 02), "Jesse@hotmail.com", "9999-8888", Occupations.Armador, ContractTypes.Funcionario);
            Funcionary f2 = new Funcionary(2, "Alex Pink", "123.456.789-3", new DateTime(1998, 4, 21), "bob@gmail.com", "9777-8888", Occupations.Carpinteiro, ContractTypes.Funcionario);
            Funcionary f3 = new Funcionary(3, "Bob Brown", "123.456.789-3", new DateTime(1979, 12, 31), "bob@gmail.com", "9345-8888", Occupations.Eletricista, ContractTypes.Funcionario);
            Funcionary f4 = new Funcionary(4, "Maria Green", "123.456.789-3", new DateTime(1988, 1, 15), "maria@gmail.com", "9333-8888", Occupations.Encanador, ContractTypes.Colaborador);
            Funcionary f5 = new Funcionary(5, "Alex Grey", "123.456.789-3", new DateTime(1997, 3, 4), "alex@gmail.com", "9999-8888", Occupations.Pedreiro, ContractTypes.Funcionario);
            Funcionary f6 = new Funcionary(6, "Martha Red", "123.456.789-3", new DateTime(2000, 1, 9), "martha@gmail.com", "9444-8888", Occupations.Armador, ContractTypes.Funcionario);
            Funcionary f7 = new Funcionary(7, "Donald Blue", "123.456.789-3", new DateTime(1988, 1, 15), "donald@gmail.com", "9666-8888", Occupations.Carpinteiro, ContractTypes.Colaborador);

            _context.Funcionary.AddRange(f1, f2, f3, f4, f5, f6, f7);

            _context.SaveChanges();
        }

    }
}

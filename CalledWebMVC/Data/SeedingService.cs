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
                _context.Sprint.Any() ||
                    _context.Projeto.Any())
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

            Sprint s1 = new Sprint(1, "Pj Casa Amarela SP-1", new DateTime(2022, 01, 10), new DateTime(2022, 02, 11), "Começar fundação da casa", 1);
           
            Task t1 = new Task(1, "Realizar gabarito",
                "realizar um gabarito, na qual usa-se madeira (sarrafos e pontaletes pregados) para cercar a área que ficará a fundação, as paredes e toda a estrutura da casa em si.",
                new DateTime(2022, 01, 10), new DateTime(2022, 01, 13), 1, 1, "Construção", Status.InProgress);

            Task t2 = new Task(2, "Desenhar Planta e marcação",
              "realizar um gabarito, na qual usa-se madeira (sarrafos e pontaletes pregados) para cercar a área que ficará a fundação, as paredes e toda a estrutura da casa em si.",
              new DateTime(2022, 01, 14), new DateTime(2022, 01, 17), 1, 2, "Construção", Status.Todo);

            Task t3 = new Task(3, "Alicerces e Vigas",
            "Em seguida, é feita a escavação para fazer as valas na qual será apoiado o baldrame e as sapatas.",
            new DateTime(2022, 01, 18), new DateTime(2022, 01, 22), 1, 3, "Construção", Status.Todo);


            Task t4 = new Task(4, "Aumentar resistência do solo",
               "Jogar uma camada de brita nas valas para aumentar a resistência do solo. Esse processo é fundamental para formar o alicerce da residência.",
               new DateTime(2022, 01, 23), new DateTime(2022, 01, 29), 1, 4, "Construção", Status.Todo);


            Task t5 = new Task(5, "Concretagem do baldrame (vigas de fundação)",
              "colocar concreto nas vigas para sustento da estrutura",
              new DateTime(2022, 02, 03), new DateTime(2022, 02, 08), 1, 5, "Construção", Status.Todo);

           


            Sprint s2 = new Sprint(2, "Pj Casa Amarela SP-2", new DateTime(2022, 02, 14), new DateTime(2022, 03, 18), "Finalizar a fundação da casa e iniciar a Estrutura", 1);

            Task t6 = new Task(6, "Alvenaria de Embasamento",
            "com o propósito de regular a estrutura, realizar a alvenaria de embasamento para nivelar horizontalmente o solo para que seja colocada a alvenaria de elevação e possibilita a passagem de tubulações sem danificar a viga baldrame ",
            new DateTime(2022, 01, 14), new DateTime(2022, 01, 16), 2, 3, "Construção", Status.Todo);


            Task t7 = new Task(7, "Impermeabilização do alicerce",
             "Para evitar patologias provocadas pela ascensão da umidade do solo, passar nos alicerces argamassa impermeabilizante combinada com tinta asfáltica",
             new DateTime(2022, 02, 17), new DateTime(2022, 02, 20), 2, 4, "Construção", Status.Todo);

            Task t8 = new Task(8, "Preparo do piso e concretagem do contrapiso.",
             "nivelar e regularizar com concreto antes da aplicação do acabamento. Contrapiso ",
             new DateTime(2022, 02, 21), new DateTime(2022, 02, 23), 2, 4, "Construção", Status.Todo);

            //Sprint s3 = new Sprint(3, "Pj Casa Amarela SP-3", new DateTime(2022, 03, 21), new DateTime(2021, 04, 22), "Concluir todas as atividades", 1);
            //Sprint s4 = new Sprint(4, "Pj Casa Amarela SP-4", new DateTime(2022, 04, 18), new DateTime(2021, 05, 25), "Concluir todas as atividades", 1);
            //Sprint s5 = new Sprint(5, "Pj Casa Amarela SP-5", new DateTime(2022, 05, 27), new DateTime(2021, 07, 01), "Concluir todas as atividades", 1);
            //Sprint s6 = new Sprint(6, "Pj Casa Amarela SP-6", new DateTime(2022, 07, 04), new DateTime(2021, 08, 05), "Concluir todas as atividades", 1);
            //Sprint s7 = new Sprint(7, "Pj Casa Amarela SP-7", new DateTime(2022, 08, 08), new DateTime(2021, 09, 09), "Concluir todas as atividades", 1);

            Projeto p1 = new Projeto(1, "Projeto Casa Amarela", "Projeto referente a construção de uma casa simples", new DateTime(2022 , 01 , 10), Status.Todo);
            Projeto p2 = new Projeto(2, "Predio 44", "Projeto referente a construção de um predio de 4 andares", new DateTime(2021 , 01 , 01), Status.Concluido);

            _context.Functionary.AddRange(f1, f2, f3, f4, f5, f6, f7);
            _context.Sprint.AddRange(s1, s2);
            _context.Task.AddRange(t1, t2,t3,t4,t5,t6,t7,t8);
            _context.Projeto.AddRange(p1, p2);



            _context.SaveChanges();
        }

    }
}

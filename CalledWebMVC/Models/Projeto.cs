using CalledWebMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Models
{
    public class Projeto
    {
        [Key]
        public int ProjetoId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} O tamanho deve ser entre {2} and {1}")]
        public string Nome { get; set; }

        [Display(Name = "Descrição do Projeto")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name = "Data de Criação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCriacao { get; set; }
        public Status Status { get; set; }

        [NotMapped]
        public ICollection<Sprint> Sprints { get; set; }


        public Projeto()
        {
        }

        public Projeto(int projetoId, string nome, string descricao, DateTime dataCriacao, Status status)
        {
            ProjetoId = projetoId;
            Nome = nome;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            Status = status;


        }

    }
}

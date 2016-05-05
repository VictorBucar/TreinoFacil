using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinoFacil.Models
{
    public class Atividade
    {
        [Display(Name = "Código da Atividade")]
        public int AtividadeID { get; set; }
        [Display(Name ="Nome da Atividade")]
        public string NomeAtividade { get; set; }
        public string Categoria { get; set; }
        [Display(Name ="Frequência Semanal")]
        public string FrequenciaSemanal { get; set; }
        [Display(Name ="Tempo Total da Atividade")]
        public string TempoTotal { get; set; }

        public virtual ICollection<Treino> Treinos { get; set; }
        public virtual ICollection<Exercicio> Exercicios { get; set; }
    }
}
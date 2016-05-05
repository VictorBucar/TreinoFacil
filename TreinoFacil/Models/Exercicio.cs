using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TreinoFacil.Models
{
    public class Exercicio
    {
        [Display(Name ="Código do Exercício")]
        public int ExercicioID { get; set; }
        [Display(Name = "Nome do Exercício")]
        public string NomeExercicio { get; set; }
        public string Categoria { get; set; }
        public string Intensidade { get; set; }
        public Int32 Carga { get; set; }
        [Display(Name = "Quantidade de Repetições")]
        public Int32 QntdRepeticao { get; set; }
        [Display(Name = "Tempo de Exercício")]
        public string Tempo { get; set; }
        [Display(Name = "Código da Atividade")]
        public int AtividadeID { get; set; }

        public virtual Atividade Atividade { get; set; }

        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
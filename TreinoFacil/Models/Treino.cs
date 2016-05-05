using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinoFacil.Models
{
    public enum Status
    {
        Ativo, Inativo, Aguardando
    }
    public class Treino
    {
        [Display(Name = "Código do Treino")]
        public int TreinoID { get; set; }
        [Display(Name = "Nome do Treino")]

        public string NomeTreino { get; set; }
        [Display(Name = "Tipo do Treino")]
        public string TipoTreino { get; set; }
        public Status? Status { get; set; }
        [Display(Name = "Frequência Semanal")]

        public string FrequenciaSemanal { get; set; }
        [Display(Name = "Código do Aluno")]

        public int AlunoID { get; set; }
        [Display(Name = "Código do Professor")]
        public int ProfessorID { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
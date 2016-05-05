using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinoFacil.Models
{
    public class Professor
    {
        [Display(Name = "Código do Professor")]
        public int ProfessorID { get; set; }
        [Display(Name = "Nome")]

        public string PrimeiroNome { get; set; }
        [Display(Name = "Sobrenome")]

        public string UltimoNome { get; set; }
        [Display(Name = "Nome Completo")]

        public string NomeCompleto
        {
            get
            {
                return PrimeiroNome + " " + UltimoNome;
            }
        }
        [Display(Name = "E-mail")]

        public string Email { get; set; }
        public string Login { get; set; }

        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string CREF { get; set; }
        [Display(Name = "Formação")]
        public string Formacao { get; set; }


        public virtual ICollection<Treino> Treinos { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinoFacil.Models
{
    public class Aluno
    {

        [Display(Name = "Código do Aluno")]
        public int AlunoID { get; set; }

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
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Início do Treino")]
        public DateTime DataInicioTreino { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Término do Treino")]
        public DateTime DataFimTreino { get; set; }
        public virtual ICollection<Treino> Treinos { get; set; }
    }
}
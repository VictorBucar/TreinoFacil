using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TreinoFacil.Models
{
    public class Equipamento
    {
        [Display(Name ="Código do Equipamento")]
        public int EquipamentoID { get; set; }
        [Display(Name ="Nome do Equipamento")]
        public string NomeEquipamento { get; set; }
        [Display(Name ="Músculo Alvo do Equipamento")]
        public string MusculoAlvo { get; set; }

        public virtual ICollection<Exercicio> Exercicios { get; set; }
    }
}
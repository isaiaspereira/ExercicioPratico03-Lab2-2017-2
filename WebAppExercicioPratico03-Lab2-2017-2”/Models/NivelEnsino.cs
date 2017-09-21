using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppExercicioPratico03_Lab2_2017_2_.Models
{
    public class NivelEnsino
    {
        public int NivelEnsinoId { get; set; }
        public string Descricao { get; set; }
        public virtual List<Estudante> Estudates { get; set; }
        public virtual List<Professor> Professores { get; set; }
    }
}
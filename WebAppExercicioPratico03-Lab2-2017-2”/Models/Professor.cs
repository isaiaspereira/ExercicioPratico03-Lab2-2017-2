using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppExercicioPratico03_Lab2_2017_2_.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string ProfessorNome { get; set; }
        public TipoProfessor TipoProfessor { get; set; }
        public int NivelEnsinoId { get; set; }
        public virtual NivelEnsino NivelEnsino { get; set; }
        public virtual List<Curso> Cursos { get; set; }

    }
}
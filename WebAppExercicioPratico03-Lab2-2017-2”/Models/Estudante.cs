using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppExercicioPratico03_Lab2_2017_2_.Models
{
    public class Estudante
    {
        [Key]
        public int EstudanteId { get; set; }
        public string NomeEstudante { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Foto { get; set; }
        public int Altura { get; set; }
        public decimal Peso { get; set; }
        public int NivelEnsinoId { get; set; }
        public NivelEnsino NivelEnsino { get; set; }
        public Endereco Endereco { get; set; }
        public virtual List<Curso> Cursos { get; set; }
    }
}
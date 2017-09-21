using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebAppExercicioPratico03_Lab2_2017_2_.Models
{
    public class SistemaAcademicoContext:DbContext
    {
        public SistemaAcademicoContext():base("SistemaAcademicoContext")
        {

        }
        public DbSet<Estudante> Estudante { get; set; }
        public DbSet<Endereco> Endereco{ get; set; }
        public DbSet<Curso> Curso{ get; set; }
        public DbSet<NivelEnsino> NivelEnsino{ get; set; }
        public DbSet<Professor> Professor{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
using BibliotecaBDweb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.DAL
{
    class FicheroBDContext: DbContext
    {
        public FicheroBDContext()
         /*  :base("name=DefaultConnection")//*/ :base("FicheroBD")
        {
        }

        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Edificios> Edificios { get; set; }
        public DbSet<Hora> Hora { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<Salas> Salas { get; set; }
        public DbSet<UsuarioAsignatura> UsuariosAsignatura { get; set; }
        public DbSet<UsuarioCarrera> UsuariosCarrera { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TutorialEF.Entidades;

namespace TutorialEF.DAL
{
    public class SchoolContext : DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = SchoolDB; Trusted_Connection = True; ");
        }

        //Ejemplo del modelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Con estas configuraciones, fuerzo a colocar la clave primaria manualmente "Solo para la entidad de la Persona"
            modelBuilder.Entity<Person>().Property(p => p.pesonId).HasColumnName("Id").HasDefaultValue(0).IsRequired();

            //Propiedad sombra
            modelBuilder.Entity<Person>().Property<String>("Ocupacion");
            modelBuilder.Entity<Person>().Property<int>("Edad");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}

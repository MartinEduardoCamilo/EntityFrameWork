using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TutorialEF.Entidades;
using TutorialEntityFrameWork.Entidades;

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


            //Relacion de uno a Varios
            /*modelBuilder.Entity<Estudiante>()
                .HasOne<Grado>(e => e.Grade)
                .WithMany(g => g.Estudiantes) //WithOne si se quiere relacion de 1 a 1
                .HasForeignKey(e => e.GradoId);

            //Para eliminar en Cascada
            modelBuilder.Entity<Grade>()
                .HasMany<Estudiante>(g => g.Student)
                .WithOne(e => e.Grade)
                .HasForeignKey(e => e.GradeId)
                .OnDelete(DeleteBehavior.Cascade);//ClientNull si lo que se quiere es que en la otra tabla se ponga valor nulo*/

            //Para Relacion varios a varios
            //modelBuilder.Entity<Studentcourse>().HasKey(ec => new { ec.Studentid, ec.Courseid });


            modelBuilder.Entity<Student>()
               .HasOne<StudentAddress>(e => e.Address)
               .WithOne(ad => ad.Student)
               .HasForeignKey<StudentAddress>(ad => ad.StudentAddressId);

            //Propiedad sombra
            modelBuilder.Entity<Person>().Property<String>("Ocupacion");
            modelBuilder.Entity<Person>().Property<int>("Edad");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}

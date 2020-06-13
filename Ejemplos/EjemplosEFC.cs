using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TutorialEF.DAL;
using TutorialEF.Entidades;

namespace TutorialEF.Ejemplos
{
    public class EjemplosEFC
    {

        public static void GuardarStudent()
        {
            //Ejemplo de guardar en la base de datos
            SchoolContext context = new SchoolContext();
            try
            {
                var auxStudent = new Student()
                {
                    StudentId = 0,
                    FirstName = "Michael",
                    LastName = "Madison"

                };
                context.Students.Add(auxStudent);
                bool save = context.SaveChanges() > 0;

                if (save)
                    Console.WriteLine("La estudiante se guardo con éxito !!");
                else
                    Console.WriteLine("no se pudo guardar");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void GuardarCourse()
        {
            //Otro ejemplo de guardar
            SchoolContext context = new SchoolContext();
            try
            {
                var auxCourse = new Course()
                {
                    CourseId = 0,
                    studentId = 1,
                    CourseName = "Math"

                };
                context.Courses.Add(auxCourse);
                bool save = context.SaveChanges() > 0;

                if (save)
                    Console.WriteLine("El curso se guardo con éxito!");
                else
                    Console.WriteLine("no se pudo guardar");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void SimpleQuery()
        {
            //Ejemplo del Query
            const string NAME = "Michael";
            SchoolContext context = new SchoolContext();
            try
            {
                var list = context.Students.Where(s => s.FirstName == NAME).ToList();
                if (list != null)
                    Console.WriteLine(list.Find(s => s.FirstName == NAME).FirstName);
                else
                    Console.WriteLine("no se pudo encontrar al estudiante");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void DoubleQuery()
        {
            //Ejemplo del Query con el Inclue
            const string NAME = "Michael";
            SchoolContext context = new SchoolContext();
            try
            {
                var resultado = context.Courses.Where(c => c.CourseName == "Math")
                .Include(c => c.Student.FirstName == NAME).FirstOrDefault();

                if (resultado != null)
                    Console.WriteLine(resultado.CourseName.ToString());
                else
                    Console.WriteLine("no se pudo encontrar al estudiante!");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void QuerryUsingSql()
        {
            //Ejemplo de query usando un FromSqlRaw
            SchoolContext context = new SchoolContext();
            List<Student> studentList = new List<Student>();
            try
            {

                studentList = context.Students.FromSqlRaw("Select *from dbo.Students").ToList();
                if (studentList != null)
                    Console.WriteLine(studentList.Find(s => s.FirstName == "Bill").FirstName);
                else
                    Console.WriteLine("no se pudo encontrar al estudiante");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void UpdatingData()
        {
            //Ejemplo modificacion del nombre del primer estudiante
            SchoolContext context = new SchoolContext();

            try
            {
                var std = context.Students.First<Student>();
                std.FirstName = "Steve";
                bool modified = context.SaveChanges() > 0;

                if (modified)
                    Console.WriteLine("Estudiante modificado");
                else
                    Console.WriteLine("No se pudo modificar");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void DeletingData()
        {
            SchoolContext context = new SchoolContext();
            //Ejemplo modificacion del nombre del primer estudiante
            try
            {
                var std = context.Students.First<Student>();
                context.Students.Remove(std);
                bool deleted = context.SaveChanges() > 0;

                if (deleted)
                    Console.WriteLine("Estudiante eliminado");
                else
                    Console.WriteLine("No se pudo eliminar");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void ConsultaStudents()
        {
            //Ejemplo para la consulta de estudiate

            var context = new SchoolContext();

            try
            {
                var studentsWithSameName = context.Students.ToList();

                if (studentsWithSameName != null)
                    foreach (var auxiliar in studentsWithSameName)
                    {
                        Console.WriteLine(auxiliar.FirstName);
                    }
                else
                    Console.WriteLine("No se encontro ningun estudiante");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void WorkingStore()
        {
            //Las entidades en el resultado serán rastreadas DbContextpor defecto. 
            //Si ejecuta el mismo procedimiento almacenado con los mismos parámetros varias veces

            try
            {
                //var context = new SchoolContext();

                //var list1 = context.Students.FromSql("GetStudents 'Bill'").ToList();
                //var list2 = context.Students.FromSql("GetStudents 'Bill'").ToList();
                //var list3 = context.Students.FromSql("GetStudents 'Bill'").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        public static void UpdatingOnDisconnectedScenario()
        {
            SchoolContext context = new SchoolContext();
            try
            {
                var modifiedStudent1 = new Student()
                {
                    StudentId = 1,
                    FirstName = "Bill",
                    LastName = "Madison"
                };

                var modifiedStudent2 = new Student()
                {
                    StudentId = 2,
                    FirstName = "Steve",
                    LastName = "Perez"
                };

                List<Student> modifiedStudents = new List<Student>()
                {
                    modifiedStudent1,
                    modifiedStudent2,
                };

                context.UpdateRange(modifiedStudents);
                bool modified = context.SaveChanges() > 0;
                if (modified)
                    Console.WriteLine("Modificado");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void DeletingOnDisconnectedScenario()
        {
            SchoolContext context = new SchoolContext();

            try
            {
                List<Student> StudentList = new List<Student>()
                {
                   new Student()
                   {
                       StudentId = 1
                   },
                   new Student()
                   {
                       StudentId = 2
                   }
                };

                context.RemoveRange(StudentList);
                bool removed = context.SaveChanges() > 0;

                if (removed)
                    Console.WriteLine("Lista eliminada");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void ChangeTracker()
        {
            //Ejemplo del tracking a los metodos que se invocan en el Contexto
            //De igual forma se puede hacer para borrar, añadir entre otros
            SchoolContext contexto = new SchoolContext();
            try
            {
                var student = contexto.Students.First();
                student.LastName = "Apellido cambiado";
                MostrarEstado(contexto.ChangeTracker.Entries());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

        }

        private static void MostrarEstado(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: { entry.State.ToString()}");
            }
        }

        public static void DetachedContext()
        {
            //Este ejemplo sirve para dividir un registro de la tabla de manera conectada
            SchoolContext contexto = new SchoolContext();
            try
            {
                var disconnectedEntity = new Student() { StudentId = 1, FirstName = "Bill" };
                Console.Write(contexto.Entry(disconnectedEntity).State);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
        }

        public static void EntityGraphDisconnected()
        {
            //Ejemplo de hacer un graph en un escenario desconectado y actualizando data
            SchoolContext contexto = new SchoolContext();
            try
            {
                var course = new Course()
                {
                    CourseId = 1,
                    CourseName = "Math",
                    Student = new Student()
                    {
                        StudentId = 1,
                        FirstName = "Bill",
                        LastName = "Ben"
                    }
                };

                contexto.Update(course);
                MostrarEstado(contexto.ChangeTracker.Entries());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
        }



        public static void QuerryParametrizado()
        {
            //Ejemplo de querying parametrizado
            SchoolContext context = new SchoolContext();
            List<Student> studentList = new List<Student>();
            string name = "Michael";
            try
            {

                studentList = context.Students.FromSqlRaw($"Select * from dbo.Students where FirstName = '{name}'").ToList();


                if (studentList != null)
                    Console.WriteLine(studentList.Find(s => s.FirstName == name).FirstName);
                else
                    Console.WriteLine("no se pudo encontrar al estudiante");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

    }
}

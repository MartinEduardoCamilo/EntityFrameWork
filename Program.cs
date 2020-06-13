using System;
using TutorialEF.Ejemplos;

namespace TutorialEntityFrameWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        private static void Menu()
        {
            int opcion = 0;
            string auxiliar = string.Empty;
            do
            {
                Console.Clear();

                Console.WriteLine("Ejemplos del Tutorial de EntityFrameWork");
                Console.WriteLine("1. Guardar un estudiante en la BD.");
                Console.WriteLine("2. Hacer un simple Query.");
                Console.WriteLine("3. Hacer un doble Query.");
                Console.WriteLine("4. Hacer un query usando SQL.");
                Console.WriteLine("5. Actualizar data de una entidad.");
                Console.WriteLine("6. Borrar data de una entidad.");
                Console.WriteLine("7. Actualizar data de una entidad usando Range en un escenario desconectado.");
                Console.WriteLine("8. Borrar data de una entidad usando en Range en un escenario desconectado.");
                Console.WriteLine("9. Hacer ChangeTracker a varias entidades.");
                Console.WriteLine("10. Hacer DetachedContext a propiedades de una entidad.");
                Console.WriteLine("11. Hacer un Graph en un escenario desconectado.");
                Console.WriteLine("12. Hacer Querry Parametrizado.");
                Console.WriteLine("13. Consulta de los estudiante");
                Console.WriteLine("14. Almacenamineto de varios estudiante con el mismo nombre");
                Console.WriteLine("15. Salir.");

                Console.WriteLine("OPCION:");

                auxiliar = Console.ReadLine();
                opcion = Validar(auxiliar);
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        {
                            EjemplosEFC.GuardarStudent();
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        {
                            EjemplosEFC.SimpleQuery();
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        {
                            EjemplosEFC.DoubleQuery();
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        {
                            EjemplosEFC.QuerryUsingSql();
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        {
                            EjemplosEFC.UpdatingData();
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        {
                            EjemplosEFC.DeletingData();
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        {
                            EjemplosEFC.UpdatingOnDisconnectedScenario();
                            Console.ReadKey();
                        }
                        break;
                    case 8:
                        {
                            EjemplosEFC.DeletingOnDisconnectedScenario();
                            Console.ReadKey();
                        }
                        break;
                    case 9:
                        {
                            EjemplosEFC.ChangeTracker();
                            Console.ReadKey();
                        }
                        break;
                    case 10:
                        {
                            EjemplosEFC.DetachedContext();
                            Console.ReadKey();
                        }
                        break;
                    case 11:
                        {
                            EjemplosEFC.EntityGraphDisconnected();
                            Console.ReadKey();
                        }
                        break;
                    case 12:
                        {
                            EjemplosEFC.QuerryParametrizado();
                            Console.ReadKey();
                        }
                        break;
                    case 13:
                        {
                            EjemplosEFC.ConsultaStudents();
                            Console.ReadKey();
                        }
                        break;
                    case 14:
                        {
                            EjemplosEFC.WorkingStore();
                            Console.ReadKey();
                        }
                        break;
                    case 15:
                        break;
                }
            }
            while (opcion != 15);
        }

        private static int Validar(string error)
        {
            int opcion = 0;
            try
            {
                opcion = Convert.ToInt32(error);
                return opcion;
            }
            catch (Exception)
            {

                Console.WriteLine("Deber ser un número entero");
            }
            return opcion;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using extras;

namespace Practica9
{
    class ejercicio2
    {
        public struct alumno
        {
            public string carnet;
            public string nombre;
            public string carrera;
            private double cum;
            public void SetCum(double cum)
            {
                if (cum > 0 || cum < 10)
                {
                    this.cum = cum;
                }              
            }
            public double Getcum()
            {
                return cum;
            }
        }

        public static Dictionary<string, alumno> alumnos = new Dictionary<string, alumno>();
        public static alumno alum = new alumno();
        public static string carnet="";
        static void Main(string[] args)
        {
            menuPrincipal();
        }
        static void menuPrincipal()
        {
            int menu;
            Console.WriteLine("1. Agregar alumno");
            Console.WriteLine("2. Mostrar alumnos");
            Console.WriteLine("3. Eliminar alumno");
            Console.WriteLine("4. Buscar alumno");
            Console.WriteLine("5. Vaciar diccionario");
            Console.WriteLine("6. Salir");
            Validacion.ValidarMayor("Escoja la opción que desee: ", out menu, 6);
            switch (menu)
            {
                case 1:
                    Console.Clear();
                    Agregar();
                    break;
                case 2:
                    Console.Clear();
                    Mostrar();
                    break;
                case 3:
                    Console.Clear();
                    Eliminar();
                    break;
                case 4:
                    Console.Clear();
                    Buscar();
                    break;
                case 5:
                    Console.Clear();
                    Vaciar();
                    break;
                case 6:
                    Environment.Exit(6);
                    break;       
            }
        }
            static void Agregar()
        {
            do
            {
                Console.WriteLine("Carnet:");
                alum.carnet = Console.ReadLine();
                if (alumnos.ContainsKey(alum.carnet.ToUpper()))
                {
                    Console.WriteLine($"El carnet {alum.carnet.ToUpper()} ya existe");
                    Console.Clear();    
                    Agregar();
                }
            } while (alumnos.ContainsKey(alum.carnet.ToUpper()));
            Console.WriteLine("Nombre del alumno:");
            alum.nombre = Console.ReadLine();
            Console.WriteLine("Carrera:");
            alum.carrera = Console.ReadLine();
            Validacion.ValidarMayor("Ingrese el cum del alumno: ", out double cum, 10);
            alum.SetCum(cum);
            alumnos.Add(alum.carnet.ToUpper(), alum);            
            Console.WriteLine("Regresando al menú principal...");
            Thread.Sleep(2500);
            Console.Clear();
            menuPrincipal();
        }

    
        static void Mostrar(string carnet = "")
        {           
            foreach (KeyValuePair<string, alumno> item in alumnos)
            {
                alumno alum = item.Value;
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Carnet: {alum.carnet.ToUpper()}");
                Console.WriteLine($"Nombre: {alum.nombre}");
                Console.WriteLine($"Carrera: {alum.carrera}");
                Console.WriteLine($"Cum: {alum.Getcum()}");
                Console.WriteLine("--------------------------");
            }
            Console.WriteLine("Presione <Enter> para regresar al menú principal");
            Console.ReadKey();
            Console.Clear();
            menuPrincipal();
        }
        
        static void Eliminar()
        {
            int condicion;
            Console.WriteLine("Ingrese carnet del alumno que desea eliminar:");
            alum.carnet = Console.ReadLine();
            if (alumnos.ContainsKey(alum.carnet.ToUpper()))          
            {
                Validacion.ValidarMayor($"Desea borar los datos correspondientes al carnet: {alum.carnet.ToUpper()}\n1. Si\n2. No", out condicion, 2);
                if (condicion == 1)
                {
                    alumnos.Remove(alum.carnet.ToUpper());
                }
                else
                {
                    Console.WriteLine("Presione <Enter> para regresar al menú principal");
                    Console.ReadKey();
                    Console.Clear();
                    menuPrincipal();
                }
            }
            else
            {
                Console.WriteLine($"El carnet: {alum.carnet.ToUpper()} no existe en la base de datos.");
                Console.WriteLine("Presione <Enter> para regresar al menú principal");
                Console.ReadKey();
                Console.Clear();
                menuPrincipal();
            }           
        } 

        static void Buscar()
        {
            Console.WriteLine("Ingrese el carnet del alumno al que desea buscar:");
            alum.carnet = Console.ReadLine();
            if (alumnos.ContainsKey(alum.carnet.ToUpper()))
            {
                Mostrar(alum.carnet.ToUpper());
                Console.WriteLine("Presione <Enter> para regresar al menú principal");
                Console.ReadKey();
                Console.Clear();
                menuPrincipal();
            }
            else
            {
                Console.WriteLine($"El carnet: {alum.carnet.ToUpper()} no existe en la base de datos.");
                Console.WriteLine("Presione <Enter> para regresar al menú principal");
                Console.ReadKey();
                Console.Clear();
                menuPrincipal();
            }
        }
        static void Vaciar()
        {
            Validacion.ValidarMayor($"Desea borar los datos correspondientes al diccionario\n1. Si\n2. No", out int condicion, 2);
            if (condicion == 1)
            {
                alumnos.Clear();
                Console.WriteLine("La base de datos del diccionario eliminada con exito");
                Console.WriteLine("Presione <Enter> para regresar al menú principal");
                Console.ReadKey();
                Console.Clear();
                menuPrincipal();
            }
            if (condicion == 2)
            {
                Console.WriteLine("Presione <Enter> para regresar al menú principal");
                Console.ReadKey();
                Console.Clear();
                menuPrincipal();
            }
        }
    }
}

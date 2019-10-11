using System;
using System.Collections.Generic;
using System.Text;
namespace extras
{
    public class Validacion
    {
        #region SobreCargasdeValidacion
        public static void Validar(string mensaje, out int num)
        {
            bool condicion;
            do
            {               
                Console.WriteLine(mensaje);
                condicion = int.TryParse(Console.ReadLine(), out num);              
            } while (condicion == false || num < 0);
        }

        public static void Validar(string mensaje, out double num)
        {
            bool condicion;
            do
            {
                Console.WriteLine(mensaje);
                condicion = double.TryParse(Console.ReadLine(), out num);           
            } while (condicion == false || num < 0);
        }

        
        #endregion

        #region ValidarSignoMayor
        public static void ValidarMayor(string mensaje, out int num, int validacion)
        {
            bool condicion;
            do
            {                
                Console.WriteLine(mensaje);
                condicion = int.TryParse(Console.ReadLine(), out num);
            } while (condicion == false || num <= 0 || num > validacion);
        }

        public static void ValidarMayor(string mensaje, out double num, int validacion)
        {
            bool condicion;
            do
            {                
                Console.WriteLine(mensaje);
                condicion = double.TryParse(Console.ReadLine(), out num);
            } while (condicion == false || num <= 0 || num > validacion);
        }
        #endregion


    }
}


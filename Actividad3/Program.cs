using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejecutar();            
        }

        private static void Ejecutar()
        {
            
             Console.WriteLine("Ingrese la opcion deseada:\n" +
                    "C)Consultar\n" +
                    "A)Actualizar\n" +
                    "S)Salir");
            while (true)
            {
                var tecla = Console.ReadKey();
                if (tecla.Key == ConsoleKey.C)
                {
                    Consultar();
                    continue;

                }
                else if (tecla.Key == ConsoleKey.A)
                {
                    Actualizar();
                    continue;
                }
                else if (tecla.Key == ConsoleKey.S)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Debe ingresar un valor valido");
                    continue;
                }

            }                   
            
        }

        private static void Actualizar()
        {
            Console.WriteLine("\nGenerando Actualizacion..");
        }

        private static void Consultar()
        {
            
            LibroDiario.Leer();
        }
    }
}

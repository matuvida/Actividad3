using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3
{
    internal class LibroDiario
    {

        private List<Cuenta> cuentas = new List<Cuenta> { };
        private List<LineaLD> lineas = new List<LineaLD>();
        private int nroAsiento;
        private DateTime fecha;
        private decimal debe;
        private decimal haber;

        private List<Cuenta> Cuentas => cuentas;
        public List<LineaLD> Lineas
        {
            get => this.lineas;
        }
        public int NroAsiento { get; set; }
        public DateTime Fecha { get; set; }

        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public LibroDiario(int nroAsiento, DateTime fecha, Cuenta cuenta, decimal debe, decimal haber)
        {
            this.nroAsiento = nroAsiento;
            this.fecha = fecha;
            _ = cuenta.Codigo;
            this.debe = debe;
            this.haber = haber;
        }

        public LibroDiario()
        {
        }
        public void generarMayor()
        {
            Console.WriteLine(
                "Cuenta - "
                + "Fecha - "
                + "Debe - "
                + "Haber"
            );

            foreach (Cuenta cuenta in this.cuentas)
            {
                Console.WriteLine(
                    cuenta.Codigo + " - "
                    + DateTime.Now.ToString("dd/MM/yyyy") + " - "
                    + cuenta.calcularDebe() + " - "
                    + cuenta.calcularHaber()
                );
            }
        }
        public void agregarLinea(LineaLD linea)
        {
            this.lineas.Add(linea);
        }
        public decimal totalDebe()
        {
            return lineas.Sum(linea =>
            {
                return (linea.TipoMov == TipoMovimiento.Debe) ? linea.Monto : 0;
            });
        }

        public decimal totalHaber()
        {
            return lineas.Sum(linea =>
            {
                return linea.TipoMov == TipoMovimiento.Haber ? linea.Monto : 0;
            });
        }


        public decimal balance()
        {
            return this.totalDebe() - this.totalHaber();
        }
        internal static void Leer()
        {
                       
                string[] lines = File.ReadAllLines("LIBRO.txt");
                Console.WriteLine("Detalle de nuestro Libro Mayor actualizado.");
                foreach (string line in lines)
                {
                    string[] datos = line.Split('|');
                    Console.WriteLine("NroAsiento: " + datos[0]);
                    Console.WriteLine("Fecha: " + datos[1]);
                    Console.WriteLine("Codigo: " + datos[2]);
                    Console.WriteLine("Debe: " + datos[3]);
                    Console.WriteLine("Haber: " + datos[4]);
                    Console.WriteLine("------------------------ ");

                }
                Console.WriteLine("\t");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadLine();
            
        }
    }
}
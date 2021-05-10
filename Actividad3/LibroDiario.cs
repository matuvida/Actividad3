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
                    + DateTime.Now.ToString("yyyy/mm/dd") + " - "
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
                return (linea.TipoMov == "Debe") ? linea.Monto : 0;
            });
        }

        public decimal totalHaber()
        {
            return lineas.Sum(linea =>
            {
                return linea.TipoMov == "Haber" ? linea.Monto : 0;
            });
        }


        public decimal balance()
        {
            return this.totalDebe() - this.totalHaber();
        }
        internal static void Leer()
        {
                string archivo = "LIBRO.txt";
                string[] lines = File.ReadAllLines(archivo);
                Console.WriteLine("\nDetalle de nuestro Libro Diario Actualizado.");
                foreach (string line in lines)
                {
                    string[] datos = line.Split('|');
                    Console.WriteLine("NroAsiento:" + datos[0] + "|Fecha:" + datos[1] + "|Codigo:" + datos[2] +"|Debe:" + datos[3] +"|Haber:" + datos[4]);
                }

                Console.WriteLine("Presione una tecla para salir");
                Console.ReadLine();
            
        }
    }
}
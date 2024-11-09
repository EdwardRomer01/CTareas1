using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    public  class Producto
    {
        public Producto(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public string Nombre { get; set; }
        public double Precio { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto : {Nombre}, Precio : {Precio}");
        }
    }
}

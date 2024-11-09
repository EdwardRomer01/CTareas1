using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    public  class Inventario
    {
        private List<Producto> productos;
        public Inventario()
        {
            productos = new List<Producto>();
        }
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }
        public IEnumerable<Producto> FiltrarYOrdenarProductos(double precioMinimo)
        {
            // Filtra y ordena productos con LINQ y expresiones lambda
            return productos
                .Where(p => p.Precio > precioMinimo) // filtra productos con precio  mayor al minimo espesificado 
                .OrderBy(p => p.Precio); // ordena los productos de menor a mayor precio 
        }
        // Metodo para encontrar producto y actualizar su precio.
        public void ActualizarPrecio(string nombre, double newprecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.ToLower() == nombre.ToLower());
            if (producto != null)
            {
                producto.Precio = newprecio;
                Console.WriteLine($"Producto : {nombre}, Precio actualizado {newprecio}");


            }
            else
            {
                Console.WriteLine($"Producto {nombre} no fue encontrado en el inventario");
            }

        }
        // Metodo para eliminar productos 
        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.ToLower() == nombre.ToLower());
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($" Producto : {nombre} ha sido eliminado del inventario !!");
            }
            else
            {
                Console.WriteLine($"Producto : {nombre} no fue encontrado en el inventario");
            }
        }
        // Metodo para agrupar y contar productos
        public void AgruparYCompararProductosXPrecio()
        {
            var agrupacionPrecio = productos
                .GroupBy(p =>
                {
                    if (p.Precio < 100) return "Menores que $100";
                    else if (p.Precio >= 100 && p.Precio <= 500) return "Entre $100 y $ 500 ";
                    else return "Mayores que $500";
                });
            foreach (var agrupar in agrupacionPrecio)
            {
                Console.WriteLine($"Rango de precio : {agrupar.Key} , Cantidad en stock : {agrupar.Count()} productos");
            }
        }
        public void GenerarReporte()
        {
            int TotalProductos = productos.Count(); // Todos los productos
            double PromedioPrecio = productos.Average(p => p.Precio);// el promedio del precio 

            var ProductoCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault(); // El producto mas car
            var ProductoBarato = productos.OrderBy(p => p.Precio).FirstOrDefault(); // El producto mas barato

            // Reporte
            Console.WriteLine($"El total de productos es : {TotalProductos}");
            Console.WriteLine($"El promedio de los precios es : {PromedioPrecio}");
            Console.WriteLine($"Producto mas caro : {ProductoCaro?.Nombre} - Precio : {ProductoCaro?.Precio}");
            Console.WriteLine($"El producto mas barato : {ProductoBarato?.Nombre} -  Valor: {ProductoBarato?.Precio}");




        }
        public int ContarProductosDeInventario()
        {
            return productos.Count;
        }
    }
}

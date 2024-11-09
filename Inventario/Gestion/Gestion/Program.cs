using System;
using System.Text.RegularExpressions;
namespace Gestion
{
    class Program 
    {
        static void Main(string[] args)
        {

            Inventario inventario = new Inventario();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Bienvenido al sistema de inventario ");
                Console.WriteLine("Ingrese una opcion del menu");
                Console.WriteLine("1.Ingresar porducto ");
                Console.WriteLine("Las siguientes funciones solo sirven si ya agrego productos.");
                Console.WriteLine("2.Filtrar porduntos por precio minimo ");
                Console.WriteLine("3.Actualizar precio de productos");
                Console.WriteLine("4.Eliminar producto ");
                Console.WriteLine("5.Contar y agrupar productos");
                Console.WriteLine("6.Generar reportes");
                Console.WriteLine("7.Salir ");


                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // Ingreso de producto por usuario 
                        int cantidad;
                        do
                        {
                            Console.WriteLine("Cuantos productos desea ingresar ?");
                            cantidad = int.Parse(Console.ReadLine());
                            if (cantidad < 0 || cantidad > 50)
                            {
                                Console.WriteLine("Cantidad negativa o superios a 50");
                            }
                        } while (cantidad < 0 || cantidad > 50);


                        //Se ocupa el ciclo for para  pedir exactamente la cantidad de poroductos que desea ingresar el usuario 
                        for (int i = 0; i < cantidad; i++)
                        {
                            Console.WriteLine($"Producto {i + 1}:");
                            Console.WriteLine("Nombre : ");

                            string Nombre;
                            do
                            {
                                Nombre = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(Nombre))
                                {
                                    Console.WriteLine("El nombre no puede ir vacio ");

                                }
                                else if (Nombre.Contains('-'))
                                {
                                    Console.WriteLine("No pueden ir caracteres");
                                }
                                else if (!Regex.IsMatch(Nombre, @"^[a-zA-Z]+$"))
                                {
                                    Console.WriteLine("El nombre no puede tener simbolos");
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);


                            Console.WriteLine("Precio : ");

                            double Precio;
                            do
                            {
                                Precio = double.Parse(Console.ReadLine());
                                if (Precio < 0 || Precio > 1000)
                                {
                                    Console.WriteLine("El precio es negativo o mayor a $1000");
                                    Console.WriteLine("Ingrese correctamente el precio ");
                                }
                            } while (Precio < 0 || Precio > 1000);



                            Producto producto = new Producto(Nombre, Precio);
                            inventario.AgregarProducto(producto);





                        }
                        break;

                    case 2:
                        // Ingresar el precio minimo para el filtro 
                        if (inventario.ContarProductosDeInventario() == 0)
                        {
                            Console.WriteLine("El inventario esta vacio");
                            break;
                        }
                        Console.WriteLine();
                        double precioMinimo;
                        do
                        {
                            Console.WriteLine("Ingrese el precio minimo para filtrar los productos");
                            precioMinimo = double.Parse(Console.ReadLine());
                            if (precioMinimo < 0 || precioMinimo >= 1000)
                            {
                                Console.WriteLine("No puede ser negativo o mayor de 999");
                            }
                        } while (precioMinimo < 0 || precioMinimo >= 1000);


                        // Filtrar y mostrar
                        var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);
                        Console.WriteLine("Productos filtrados y ordenados");
                        foreach (var producto in productosFiltrados)
                        {
                            producto.MostrarInformacion();
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        // Actualizar precio de productos
                        if (inventario.ContarProductosDeInventario() == 0)
                        {
                            Console.WriteLine("El inventario esta vacio");
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Ingrese el nombre del producto que desea actualizar su precio");
                        string productonombre;
                        do
                        {
                            productonombre = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(productonombre))
                            {
                                Console.WriteLine("El nombre no puede ir vacio ");

                            }
                            else if (productonombre.Contains('-'))
                            {
                                Console.WriteLine("No pueden ir caracteres");
                            }
                            else if (!Regex.IsMatch(productonombre, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("El nombre no puede tener simbolos");
                            }
                            else
                            {
                                break;
                            }
                        } while (true);
                        double newprecio;
                        do
                        {
                            Console.WriteLine("Ingrese el nuevo precio del producto");
                            newprecio = double.Parse(Console.ReadLine());
                            if (newprecio < 0 || newprecio >= 1000)
                            {
                                Console.WriteLine("No puede ser negativo o mayor de 999");
                            }

                        } while (newprecio < 0 || newprecio >= 1000);


                        inventario.ActualizarPrecio(productonombre, newprecio);
                        Console.WriteLine();
                        break;
                    case 4:
                        if (inventario.ContarProductosDeInventario() == 0)
                        {
                            Console.WriteLine("El inventario esta vacio");
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Estas seguro de querer eliminar un peoducto ? si / no");
                        if (Console.ReadLine().ToLower() == "si")
                        {
                            Console.WriteLine("Ingrese el nombre del producto que desea eliminar ");
                            string productonombreelimna = Console.ReadLine();
                            inventario.EliminarProducto(productonombreelimna);
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        if (inventario.ContarProductosDeInventario() == 0)
                        {
                            Console.WriteLine("El inventario esta vacio");
                            break;
                        }
                        Console.WriteLine();
                        // Agrupar y contar los producos 
                        Console.WriteLine("Productos agrupados y contados por precio ");
                        inventario.AgruparYCompararProductosXPrecio();
                        Console.WriteLine();
                        break;
                    case 6:
                        if (inventario.ContarProductosDeInventario() == 0)
                        {
                            Console.WriteLine("El inventario esta vacio");
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Reporte sobre los productos ");
                        inventario.GenerarReporte();
                        break;
                    case 7:
                        Console.WriteLine("Ha salido del programa ");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida ");
                        break;

                }
            }




        }
    }

}



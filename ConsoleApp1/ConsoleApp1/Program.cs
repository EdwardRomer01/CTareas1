using System;
namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Universidad universidad = new Universidad();
            Console.WriteLine("Ingrese el nombre de la Universidad");
            universidad.NombreUni = Console.ReadLine();
            Console.WriteLine("Ingrese  la direccion de la Universidad");
            universidad.Direccion = Console.ReadLine();
            universidad.MostrarInfoUni();

            Universidad.Estudiante[] estudiantes = new Universidad.Estudiante[10];

            int CantidadEtd;
            do
            {
                Console.WriteLine("Ingrese la cantidad de estudiantes (No puede ser mayor de 10)");
                CantidadEtd = Convert.ToInt32(Console.ReadLine());
                if (CantidadEtd < 1 || CantidadEtd > 10)
                {
                    Console.WriteLine("Cantidad inferior o superior del parametro ");
                    Console.WriteLine("Ingrese un numero del a al 10 ");
                }


            } while (CantidadEtd < 1 || CantidadEtd > 10);

            for (int i = 0; i < CantidadEtd; i++)
            {
                estudiantes[i] = new Universidad.Estudiante();
                Console.WriteLine($"Ingrese el nombre del estudiante {i + 1}");
                estudiantes[i].NombreEtd = Console.ReadLine();

                do
                {
                    Console.WriteLine("Ingrese el numero de sesiones de clase ");
                    estudiantes[i].SesionesTotales = Convert.ToInt32(Console.ReadLine());

                    if (estudiantes[i].SesionesTotales <= 0)
                    {
                        Console.WriteLine("Porlomenos tiene que haber 1 sesion de clase");
                    }
                } while (estudiantes[i].SesionesTotales <= 0);


                do
                {
                    Console.WriteLine("Ingrese el numero de sesiones asistidas del estudiante ");
                    estudiantes[i].SesionesAsistidas = Convert.ToInt32(Console.ReadLine());

                    if (estudiantes[i].SesionesAsistidas < 0 || estudiantes[i].SesionesAsistidas > estudiantes[i].SesionesTotales)
                    {
                        Console.WriteLine($"Las sesiones asistidas no pueden ser menores que 0 y mayores que las asistencias totales {estudiantes[i].SesionesTotales}");
                    }
                } while (estudiantes[i].SesionesAsistidas < 0 || estudiantes[i].SesionesAsistidas > estudiantes[i].SesionesTotales);

            }
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine("-------------------------------------------------------------------");
                estudiantes[i].MostrarInfoEtd(); Console.WriteLine("|");
                Console.WriteLine("--------------------------------------------------------------------");
            }


        }
    }
}
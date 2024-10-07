using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Universidad // clase principal
    {
        public string NombreUni { get; set; }
        public string Direccion { get; set; }

        public class Estudiante
        {
            public string NombreEtd { get; set; }
            public int SesionesTotales { get; set; }
            public int SesionesAsistidas { get; set; }

            public class Asistencia
            {
                public static double PorcentajeAsistencia(int SesionesAsistidas, int SesionesTotales)
                {
                    return (((double)SesionesAsistidas / SesionesTotales) * 100);


                }
                public static void AsistenciasVerificadas(int SesionesAsistidas, int SesionesTotales)
                {
                    double porcentaje = PorcentajeAsistencia(SesionesAsistidas, SesionesTotales);
                    if (porcentaje >= 75)
                    {

                        Console.WriteLine("Cumple con las asistencias");

                    }
                    else
                    {

                        Console.WriteLine("No cumple con el minimo de asistencias *!Reprovado*!");
                    }
                }


            }


        }

        public void MostrarInfoUni()
        {
            Console.WriteLine($"Universidad : {NombreUni}, Direccion : {Direccion}");
        }

    }
}

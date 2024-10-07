using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Extension
    {
        public static void MostrarInfoEtd(this Universidad.Estudiante estudiante)
        {
            double porcentaje = Universidad.Estudiante.Asistencia.PorcentajeAsistencia(estudiante.SesionesAsistidas, estudiante.SesionesTotales);
            Console.WriteLine($"Nombre de estudiante :{estudiante.NombreEtd},Porcentaje de asistencias : %{porcentaje}");
            Universidad.Estudiante.Asistencia.AsistenciasVerificadas(estudiante.SesionesAsistidas, estudiante.SesionesTotales);
        }
    }
}

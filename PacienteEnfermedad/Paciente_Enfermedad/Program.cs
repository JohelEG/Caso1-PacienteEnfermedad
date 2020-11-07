using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Paciente_Enfermedad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Cls_Paciente paciente = new Cls_Paciente();
            Console.WriteLine("----------------------------------CREAR----------------------------------");
            paciente.Crear();
            paciente.Consultar();


            Console.WriteLine("----------------------------------CREAR 1 Paciente ----------------------------------");
            paciente.Identificacion = "12346";
            paciente.NombrePaciente = "Jay";
            paciente.Apellido1 = "Amadr";
            paciente.Apellido2 = "Goll";
            paciente.Edad = 24;
            paciente.Sexo = "M";
            paciente.TipoDeSangre = "B-";
            paciente.NumeroDeTelefono = "+56045789";
            paciente.DireccionDelDomicilio = "Heredia";

            Console.WriteLine("Ingrese la cantidad  de enfermedades del paciente");
            paciente.CantidadEnfermedades = Convert.ToInt32(Console.ReadLine()); ;
            paciente.Crear();
            paciente.Consultar();

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------Eliminar sintoma----------------------------------");
            paciente.IDPaciente = 1;
            paciente.IDEnfermedad = 0;
            paciente.ID = 1;
            paciente.Eliminar();
            paciente.Consultar();

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------Eliminar enfermedad----------------------------------");
            paciente.IDPaciente = 1;
            paciente.IDEnfermedad = 0;
            paciente.ID = -1;
            paciente.Eliminar();
            paciente.Consultar();

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------Eliminar paciente----------------------------------");
            paciente.IDPaciente = 0;
            paciente.IDEnfermedad = -1;
            paciente.ID = -1;
            paciente.Eliminar();
            paciente.Consultar();


            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------Actualizar paciente----------------------------------");
            paciente.Identificacion = "45668";
            paciente.DireccionDelDomicilio = "San Jose";
            paciente.NumeroDeTelefono = "+506784132465";

            paciente.IDEnfermedad = 0;
            paciente.NombreEnfermedad = "Colitis";
            paciente.TipoEnfermedad = "Estomacal";

            paciente.ID = 0;
            paciente.Nombre = "Dolor abdominal";
            paciente.Descripcion = "Fuerte dolor en el area abdominal";

            paciente.Actualizar();


            paciente.Consultar();



            Console.ReadLine();
        }
    }
}

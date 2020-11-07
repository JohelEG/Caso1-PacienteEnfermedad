using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente_Enfermedad
{
    public class Cls_Paciente : Cls_Enfermedad, InterfaceCrud
    {
        #region Variables
        public int IDPaciente { get; set; }
        public string Identificacion { get; set; }
        public string NombrePaciente { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string TipoDeSangre { get; set; }
        public string NumeroDeTelefono { get; set; }
        public string DireccionDelDomicilio { get; set; }

        public int CantidadEnfermedades { get; set; }
                
        public List<Cls_Enfermedad> cls_Enfermedads = new List<Cls_Enfermedad>();

        #endregion

        public List<Cls_Paciente> cls_Pacientes { get; set; }

        #region Metdos
        private string NombreCompleto()
        {
            return $"{NombrePaciente} {Apellido1} {Apellido2}";
        }


        public new void Actualizar()
        {
            foreach (Cls_Paciente paciente in cls_Pacientes.Where(x=>x.Identificacion == Identificacion))
            {
                if(DireccionDelDomicilio != string.Empty && DireccionDelDomicilio != null)
                {
                    paciente.DireccionDelDomicilio = DireccionDelDomicilio;
                    Console.WriteLine($"Se actualizo la direccion del paciente {Identificacion}");
                }
                if(NumeroDeTelefono != string.Empty && NumeroDeTelefono != null)
                {
                    paciente.NumeroDeTelefono = NumeroDeTelefono;
                    Console.WriteLine($"Se actualizo el numero del paciente {Identificacion}");
                }

                foreach (Cls_Enfermedad enfermedad in paciente.cls_Enfermedads.Where(x => x.IDEnfermedad == IDEnfermedad))
                {
                    if (NombreEnfermedad != string.Empty && NombreEnfermedad != null)
                    {
                        enfermedad.NombreEnfermedad = NombreEnfermedad;
                        Console.WriteLine($"Se actualizo el nombre de la enfermedad del paciente {Identificacion}");
                    }
                    if (TipoEnfermedad != string.Empty && TipoEnfermedad != null)
                    {
                        enfermedad.TipoEnfermedad = TipoEnfermedad;
                        Console.WriteLine($"Se actualizo el tipo de enfermedad del paciente {Identificacion}");
                    }
                    
                    foreach (Cls_Sintoma sintoma in enfermedad.cls_Sintomas.Where(x => x.ID == ID))
                    {
                        if (sintoma.Nombre != string.Empty && sintoma.Nombre != null)
                        {
                            sintoma.Nombre = Nombre;
                            Console.WriteLine($"Se actualizo el nombre del sintoma de la enfermeddad {NombreEnfermedad} del paciente {Identificacion}");
                        }
                        if (sintoma.Descripcion != string.Empty && sintoma.Descripcion != null)
                        {
                            sintoma.Descripcion = Descripcion;
                            Console.WriteLine($"Se actualizo el nombre de la descripcion del sintoma de la enfermeddad {NombreEnfermedad} del paciente {Identificacion}");
                        }
                    }
                }
            }
        }

        public new void Consultar()
        {

            foreach (Cls_Paciente paciente in cls_Pacientes.OrderBy(x=>x.NombreCompleto()))
            {
                Console.WriteLine($"El paciente es {paciente.NombreCompleto()}, con una edad {paciente.Edad}, con residencia en {paciente.DireccionDelDomicilio} su numero es {paciente.NumeroDeTelefono}; posee las siguientes enfermedades: ");

                foreach (Cls_Enfermedad enfermedad in paciente.cls_Enfermedads) 
                {
                    Console.WriteLine($"Enfermedad es {enfermedad.NombreEnfermedad} del tipo {enfermedad.TipoEnfermedad} con una identificacion {enfermedad.IDEnfermedad} y los sintomas que presentan son:");
                    foreach (Cls_Sintoma sintoma in enfermedad.cls_Sintomas)
                    {
                        Console.WriteLine($"El sintoma es {sintoma.Nombre} con una identificacion {sintoma.ID} y la descripcion que posee es {sintoma.Descripcion}");
                    }
                }
                Console.WriteLine("\n");
            }
        }

        public new void Crear()
        {
            if (cls_Pacientes is null)
            {
                cls_Pacientes = new List<Cls_Paciente>();
                cls_Pacientes.Add(new Cls_Paciente(0,"1234", "Jo", "ELIZ", "GUtierr", 24, "M", "A+", "+5068888", "SJ", new List<Cls_Enfermedad>()));
                cls_Pacientes[0].cls_Enfermedads.Add(new Cls_Enfermedad(0, "COVID", "Respiratoria", new List<Cls_Sintoma>()));
                cls_Pacientes[0].cls_Enfermedads[0].cls_Sintomas.Add(new Cls_Sintoma(0, "TOS SECA", "......"));
                cls_Pacientes[0].cls_Enfermedads[0].cls_Sintomas.Add(new Cls_Sintoma(1, "Fiebre Alta", "......"));
                cls_Pacientes[0].cls_Enfermedads[0].cls_Sintomas.Add(new Cls_Sintoma(2, "Diarrea", "......"));

                cls_Pacientes.Add(new Cls_Paciente(1, "1235", "KA", "ZILE", "Mar", 36, "F", "A+", "+5067777", "Alajuela", new List<Cls_Enfermedad>()));
                cls_Pacientes[1].cls_Enfermedads.Add(new Cls_Enfermedad(0, "COVID", "Respiratoria", new List<Cls_Sintoma>()));
                cls_Pacientes[1].cls_Enfermedads[0].cls_Sintomas.Add(new Cls_Sintoma(0, "TOS SECA", "......"));
                cls_Pacientes[1].cls_Enfermedads[0].cls_Sintomas.Add(new Cls_Sintoma(1, "Fiebre Alta", "......"));
                cls_Pacientes[1].cls_Enfermedads[0].cls_Sintomas.Add(new Cls_Sintoma(2, "Diarrea", "......"));

                cls_Pacientes.Add(new Cls_Paciente(2, "45668", "Arman", "SIB", "MARCHE", 15, "M", "A+", "+5067777", "Cartago", new List<Cls_Enfermedad>()));
                cls_Pacientes[2].cls_Enfermedads.Add(new Cls_Enfermedad(0, "Acne", "Cutanea", new List<Cls_Sintoma>()));
                cls_Pacientes[2].cls_Enfermedads[0].cls_Sintomas.Add(new Cls_Sintoma(0, "Espinillas", "......"));

                cls_Pacientes[2].cls_Enfermedads.Add(new Cls_Enfermedad(1, "Gastritis", "Estomacal", new List<Cls_Sintoma>()));
                cls_Pacientes[2].cls_Enfermedads[1].cls_Sintomas.Add(new Cls_Sintoma(0, "Náuseas", "......"));
                cls_Pacientes[2].cls_Enfermedads[1].cls_Sintomas.Add(new Cls_Sintoma(1, "Dolor abdominal", "......"));
                cls_Pacientes[2].cls_Enfermedads[1].cls_Sintomas.Add(new Cls_Sintoma(2, "Acidez estomacal", "......"));

            }
            else
            {
                int idenfermedad = 0;
                int idsintoma = 0;
                ID = cls_Pacientes.Count;

                cls_Pacientes.Add(new Cls_Paciente(ID, Identificacion, NombrePaciente, Apellido1, Apellido2, Edad, Sexo, TipoDeSangre, NumeroDeTelefono, DireccionDelDomicilio, new List<Cls_Enfermedad>()));

                while (CantidadEnfermedades > 0)
                {
                    Console.WriteLine("Ingrese el nombre de la enfermedead");
                    NombreEnfermedad = Console.ReadLine();
                    Console.WriteLine("Ingrese el tipo de la enfermedead");
                    TipoEnfermedad = Console.ReadLine();
                    cls_Pacientes[ID].cls_Enfermedads.Add(new Cls_Enfermedad(idenfermedad, NombreEnfermedad, TipoEnfermedad, new List<Cls_Sintoma>()));

                    Console.WriteLine("Ingrese la cantidad  de sintomas");
                    int cantidadSintomas = Convert.ToInt32(Console.ReadLine());

                    while(cantidadSintomas > 0)
                    {
                        Console.WriteLine("Ingrese el nombre del sintoma");
                        Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese la descripcion del sintoma");
                        Descripcion = Console.ReadLine();

                        cls_Pacientes[ID].cls_Enfermedads[idenfermedad].cls_Sintomas.Add(new Cls_Sintoma(idsintoma, Nombre, Descripcion));
                        idsintoma += 1;
                        cantidadSintomas -= 1;
                    }
                    idenfermedad += 1;
                    CantidadEnfermedades -= 1;
                }


            }
        }

        public new void Eliminar()
        {
            if (ID > -1 && IDEnfermedad > -1 && IDPaciente > -1) 
            {
                foreach(Cls_Paciente paciente in cls_Pacientes.Where(x=>x.IDPaciente == IDPaciente && 
                                                                        x.cls_Enfermedads[IDEnfermedad].IDEnfermedad == IDEnfermedad && 
                                                                        x.cls_Enfermedads[IDEnfermedad].cls_Sintomas[ID].ID == ID))
                {
                    paciente.cls_Enfermedads[IDEnfermedad].cls_Sintomas.Remove(paciente.cls_Enfermedads[IDEnfermedad].cls_Sintomas[ID]);
                }
            }

            if (IDEnfermedad > -1 && IDPaciente > -1 && ID ==-1)
            {
                foreach (Cls_Paciente paciente in cls_Pacientes.Where(x => x.IDPaciente == IDPaciente && x.cls_Enfermedads[IDEnfermedad].IDEnfermedad == IDEnfermedad))
                {
                    paciente.cls_Enfermedads.Remove(paciente.cls_Enfermedads[IDEnfermedad]);
                }
            }

            if(IDPaciente > -1 && IDEnfermedad == -1 && ID == -1)
            {
                cls_Pacientes.Remove(cls_Pacientes[IDPaciente]);
            }
        }

        #endregion

        #region Constructor

        public Cls_Paciente(int id, string identificacion, string nombre, string apellido1, string apellido2, int edad, string sexo, string tiposangre, string numero, string direccion, List<Cls_Enfermedad> lists)
        {
            IDPaciente = id;
            Identificacion = identificacion;
            NombrePaciente = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Edad = edad;
            Sexo = sexo;
            TipoDeSangre = tiposangre;
            NumeroDeTelefono = numero;
            DireccionDelDomicilio = direccion;
            cls_Enfermedads = lists;
        }

        public Cls_Paciente()
        {

        }
        #endregion

    }
}

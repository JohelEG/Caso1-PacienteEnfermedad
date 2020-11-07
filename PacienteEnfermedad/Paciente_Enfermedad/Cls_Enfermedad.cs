using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente_Enfermedad
{
    public class Cls_Enfermedad : Cls_Sintoma, InterfaceCrud
    {

        #region Variables
        public int IDEnfermedad { get; set; }
        public string NombreEnfermedad { get; set; }
        public string TipoEnfermedad { get; set; }

        public List<Cls_Sintoma> cls_Sintomas = new List<Cls_Sintoma>();

        #endregion

        public List<Cls_Enfermedad> cls_Enfermedad { get; set; }

        #region Metodos
        public new void Actualizar()
        {
            foreach (Cls_Enfermedad enfermedad in cls_Enfermedad.Where(x => x.IDEnfermedad == IDEnfermedad))
            {
                if (NombreEnfermedad != string.Empty && NombreEnfermedad != null)
                {
                    enfermedad.NombreEnfermedad = NombreEnfermedad;
                }
                if (TipoEnfermedad != string.Empty && TipoEnfermedad != null)
                {
                    enfermedad.TipoEnfermedad = TipoEnfermedad;
                }

                foreach (Cls_Sintoma sintoma in enfermedad.cls_Sintomas.Where(x => x.ID == ID))
                {
                    if (sintoma.Nombre != string.Empty && sintoma.Nombre != null)
                    {
                        sintoma.Nombre = Nombre;
                    }
                    if (sintoma.Descripcion != string.Empty && sintoma.Descripcion != null)
                    {
                        sintoma.Descripcion = Descripcion;
                    }
                }
            }
        }

        public new void Consultar()
        {
            foreach (Cls_Enfermedad enfermedad in cls_Enfermedad)
            {
                Console.WriteLine($"Enfermedad es {enfermedad.NombreEnfermedad} del tipo {enfermedad.TipoEnfermedad} con una identificacion {enfermedad.IDEnfermedad} y los sintomas que presentan son:");

                foreach(Cls_Sintoma sintoma in enfermedad.cls_Sintomas)
                {
                    Console.WriteLine($"El sintoma es {sintoma.Nombre} con una identificacion {sintoma.ID} y la descripcion que posee es {sintoma.Descripcion}");
                }
                Console.WriteLine("\n");

            }
        }

        public new void Crear()
        {
            if (cls_Enfermedad is null)
            {
                cls_Enfermedad = new List<Cls_Enfermedad>();
                cls_Enfermedad.Add(new Cls_Enfermedad(0, "COVID", "Respiratoria", new List<Cls_Sintoma>()));
                cls_Enfermedad[0].cls_Sintomas.Add(new Cls_Sintoma(0, "TOS SECA", "......"));
                cls_Enfermedad[0].cls_Sintomas.Add(new Cls_Sintoma(1, "Fiebre Alta", "......"));
                cls_Enfermedad[0].cls_Sintomas.Add(new Cls_Sintoma(2, "Diarrea", "......"));

                cls_Enfermedad.Add(new Cls_Enfermedad(1, "GRIPE", "Respiratoria", new List<Cls_Sintoma>()));
                cls_Enfermedad[1].cls_Sintomas.Add(new Cls_Sintoma(0, "Fiebre", "......"));
                cls_Enfermedad[1].cls_Sintomas.Add(new Cls_Sintoma(1, "Congestionamiento nasal", "......"));

            }
            else
            {
                cls_Enfermedad.Add(new Cls_Enfermedad(IDEnfermedad, NombreEnfermedad, TipoEnfermedad, new List<Cls_Sintoma>()));
                cls_Enfermedad[IDEnfermedad].cls_Sintomas.Add(new Cls_Sintoma(ID, Nombre, Descripcion));
            }
        }

        public new void Eliminar()
        {
            if (ID>-1 && IDEnfermedad > -1)
            {
                foreach (Cls_Enfermedad enfermedad in cls_Enfermedad.Where(x => x.IDEnfermedad == IDEnfermedad && x.cls_Sintomas[ID].ID == ID))
                {
                    enfermedad.cls_Sintomas.Remove(enfermedad.cls_Sintomas[ID]);
                }
            }
            else
            {
                cls_Enfermedad.Remove(cls_Enfermedad[IDEnfermedad]);
            }
        }

        #endregion

        #region Constructor
        public Cls_Enfermedad(int iDEnfermedad, string nombreEnfermedad, string tipoEnfermedad, List<Cls_Sintoma> lists)
        {
            IDEnfermedad = iDEnfermedad;
            NombreEnfermedad = nombreEnfermedad;
            TipoEnfermedad = tipoEnfermedad;
            cls_Sintomas = lists;
        }

        public Cls_Enfermedad()
        {

        }
        #endregion

    }
}

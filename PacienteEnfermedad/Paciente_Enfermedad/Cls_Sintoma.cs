using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente_Enfermedad
{
    public class Cls_Sintoma : InterfaceCrud
    {
        #region Variables

        public int ID { get; set; } 
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        #endregion

        List<Cls_Sintoma> cls_Sintomas { get; set; }

        #region MetodosInterface

        public void Actualizar()
        {
            foreach (Cls_Sintoma ls in cls_Sintomas.Where(x => x.ID == ID))
            {
                if (Nombre != string.Empty && Nombre != null)
                {
                    ls.Nombre = Nombre;
                }
                if (Descripcion != string.Empty && Descripcion != null)
                {
                    ls.Descripcion = Descripcion;
                }
            }
        }

        public void Consultar()
        {
            foreach (Cls_Sintoma ls in cls_Sintomas)
            {
                Console.WriteLine($"El sintoma es {ls.Nombre} con una identificacion {ls.ID} y la descripcion que posee es {ls.Descripcion}");
            }
        }

        public void Crear()
        {
            if (cls_Sintomas is null)
            {
                cls_Sintomas = new List<Cls_Sintoma>();
                cls_Sintomas.Add(new Cls_Sintoma(ID, Nombre, Descripcion));
            }
            else
            {
                cls_Sintomas.Add(new Cls_Sintoma(ID, Nombre, Descripcion));
            }

        }

        public void Eliminar()
        {
            cls_Sintomas.Remove(cls_Sintomas[ID]);
        }

        #endregion

        #region Constructores
        public Cls_Sintoma(int iD, string nombre, string descripcion)
        {
            ID = iD;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Cls_Sintoma()
        {

        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente_Enfermedad
{
    public interface InterfaceCrud
    {
        void Crear();
        void Actualizar();
        void Eliminar();
        void Consultar();

    }
}

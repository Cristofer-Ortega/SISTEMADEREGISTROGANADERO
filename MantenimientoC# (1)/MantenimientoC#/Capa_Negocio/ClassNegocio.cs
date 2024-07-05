using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable N_listar_registro()
        {
            return objd.D_listar_registro();
        }

        public DataTable N_buscar_registro(ClassEntidad obje)
        {
            return objd.D_buscar_registro(obje);
        }

        public String N_mantenimiento_registro(ClassEntidad obje)
        {
            return objd.D_mantenimiento_registro(obje);
        }
    }
}

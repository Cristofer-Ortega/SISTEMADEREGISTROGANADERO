using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;

namespace Capa_Datos
{
    public class ClassDatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_registro()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_registro", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_registro(ClassEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_registro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obje.medida);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_mantenimiento_registro(ClassEntidad obje)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("sp_mantenimiento_registro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", obje.codigo);
            cmd.Parameters.AddWithValue("@medida", obje.medida);
            cmd.Parameters.AddWithValue("@cantidad", obje.cantidad);
            cmd.Parameters.AddWithValue("@precio", obje.precio);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;

        }
    }
}

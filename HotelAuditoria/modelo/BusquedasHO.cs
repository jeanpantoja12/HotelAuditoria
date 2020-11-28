using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelAuditoria.modelo
{
    public class BusquedasHO
    {
        public DataTable getHoteles(string fecha_llegada, string fecha_salida, string habitaciones, string personas, string ciudad)
        {
            DataTable dt = new DataTable();
            conexion cad = new conexion();
            string StringConDB = cad.cadconexion();
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Busqueda";
            cmd.Parameters.AddWithValue("@FechaLlegada", fecha_llegada);
            cmd.Parameters.AddWithValue("@FechaSalida", fecha_salida);
            cmd.Parameters.AddWithValue("@cant", habitaciones);
            cmd.Parameters.AddWithValue("@personas", personas);
            cmd.Parameters.AddWithValue("@ciudad", ciudad);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getHabitacionesHotel(string fecha_llegada, string fecha_salida, string habitaciones, string personas, string id)
        {
            DataTable dt = new DataTable();
            conexion cad = new conexion();
            string StringConDB = cad.cadconexion();
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_BusquedaHab";
            cmd.Parameters.AddWithValue("@FechaLlegada", fecha_llegada);
            cmd.Parameters.AddWithValue("@FechaSalida", fecha_salida);
            cmd.Parameters.AddWithValue("@cant", habitaciones);
            cmd.Parameters.AddWithValue("@personas", personas);
            cmd.Parameters.AddWithValue("@Hotel", id);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
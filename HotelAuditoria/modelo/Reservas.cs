using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelAuditoria.modelo
{
    public class Reservas
    {
        public void insertCliente(string nombre, string apellido, string tipodocumento, string numerodocumento, string direccion, string telefono, string email)
        {
            conexion cad = new conexion();
            string StringConDB = cad.cadconexion();
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_InsertarCliente";
            cmd.Parameters.AddWithValue("@NombreCli", nombre);
            cmd.Parameters.AddWithValue("@ApellidoCli", apellido);
            cmd.Parameters.AddWithValue("@TipoDocumentoCli", tipodocumento);
            cmd.Parameters.AddWithValue("@NumeroDocumentoCli", numerodocumento);
            cmd.Parameters.AddWithValue("@DireccionCli", direccion);
            cmd.Parameters.AddWithValue("@TelefonoCli", telefono);
            cmd.Parameters.AddWithValue("@EmailCli", email);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getHoteles(string fecha_llegada,string fecha_salida,string cant, string personas)
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
            cmd.Parameters.AddWithValue("@cant", cant);
            cmd.Parameters.AddWithValue("@personas", personas);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
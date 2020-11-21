using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelAuditoria.modelo
{
    public class Ciudad
    {
        public DataTable getCiudades()
        {
            DataTable dt = new DataTable();
            conexion cad = new conexion();
            string StringConDB = cad.cadconexion();
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ListCiudad";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
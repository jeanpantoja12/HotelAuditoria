using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace HotelAuditoria.modelo
{
    public class Pasarela
    {
        bool ejecuto;


        



        public bool insertPasarela(string Reserva, string Pago, string Tarjeta, string CVV, string Fecha, string Titular, string Email)
        {
            DataTable dt = new DataTable();
            conexion cad = new conexion();
            string StringConDB = cad.cadconexion();
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_Insert_Venta";
            cmd.Parameters.AddWithValue("@Reserva", Reserva);
            cmd.Parameters.AddWithValue("@Pago", Pago);
            cmd.Parameters.AddWithValue("@Tarjeta", Tarjeta);
            cmd.Parameters.AddWithValue("@CVV", CVV);
            cmd.Parameters.AddWithValue("@Fecha", Fecha);
            cmd.Parameters.AddWithValue("@Titular", Titular);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Connection = con;
            con.Open();

            if (cmd.ExecuteNonQuery() > 0)
            {
                ejecuto = true;
                con.Close();
            }
            else
            {
                ejecuto = false;
                con.Close();
            }
            return ejecuto;
        }



    }
}
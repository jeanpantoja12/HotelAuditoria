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
        bool ejecuto;
     


        public int insertReserva(string Nombre, string Apellido, string Direccion, string Telefono, string Correo, DateTime FechaEntrada, DateTime FechaSalida, int CantidadPersonas, double Precio)
        {
            DataTable dt = new DataTable();
            conexion cad = new conexion();
            string StringConDB = cad.cadconexion();
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_Insert_Reserva2";
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Apellido);
            cmd.Parameters.AddWithValue("@Direccion", Direccion);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Correo", Correo);
            cmd.Parameters.AddWithValue("@FechaE", FechaEntrada);
            cmd.Parameters.AddWithValue("@FechaS", FechaSalida);
            cmd.Parameters.AddWithValue("@Cantidad", CantidadPersonas);
            cmd.Parameters.AddWithValue("@Precio", Precio);
            cmd.Parameters.Add("@retVal", System.Data.SqlDbType.Int);
            cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
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
                return 0;
            }
            return (int)cmd.Parameters["@retVal"].Value;
        }
        public bool insertTReservaHab(string reserva, string hab)
        {
            conexion cad = new conexion();
            string StringConDB = cad.cadconexion();
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_Insert_ReservaHAB";
            cmd.Parameters.AddWithValue("@Reserva", reserva);
            cmd.Parameters.AddWithValue("@Habitacion", hab);
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

        public bool insertCliente(string Nombre, string Apellido, string Direccion, string Telefono, string Correo)
        {
            conexion cad = new conexion();
            string StringConDB = cad.cadconexion();
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_Insert_Cliente";
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Apellido);
            cmd.Parameters.AddWithValue("@Direccion", Direccion);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Correo", Correo);
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
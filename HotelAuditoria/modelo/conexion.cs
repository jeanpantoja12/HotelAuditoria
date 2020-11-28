using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAuditoria.modelo
{
    public class conexion
    {
        internal string cadconexion()
        {
            //return "Data Source=.;Initial Catalog=BD_Hotel;Persist Security Info=False;User ID=sa;Password=123";
          // return "Data Source=DESKTOP-NLIC8NT\\SQLEXPRESS;Initial Catalog=BD_Hotel;Integrated Security=True";
           return "Data Source=SQL5097.site4now.net;Initial Catalog=DB_A6AE70_giancohgHotels;User Id=DB_A6AE70_giancohgHotels_admin;Password=3CCD5E01";
        }
        
    }
}
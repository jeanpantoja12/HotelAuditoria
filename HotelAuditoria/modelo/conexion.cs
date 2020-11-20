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
            return "Data Source=.;Initial Catalog=BD_Hotel;Persist Security Info=False;User ID=sa;Password=123";
        }
        
    }
}
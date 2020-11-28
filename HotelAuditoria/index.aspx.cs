using HotelAuditoria.modelo;
using HotelAuditoria.negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HotelAuditoria
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Reservas sql = new Reservas();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                drpCantidad.Items.Insert(0, new ListItem("Cantidad de Personas","0"));
                drpCantidad.Items[0].Attributes["disabled"] = "disabled";
                drpCantidad.SelectedValue = "0";
            }
            
        }

       
    }
}
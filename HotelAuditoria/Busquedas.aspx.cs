using HotelAuditoria.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelAuditoria
{
    public partial class Busquedas : System.Web.UI.Page
    {
        Reservas sql = new Reservas();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if( Request.QueryString["Destino"] != null && Request.QueryString["Personas"] != null && Request.QueryString["Habitaciones"] !=null)
            {
                drpCiudad.SelectedValue = Request.QueryString["Destino"];
                drpCantidad.SelectedValue = Request.QueryString["Personas"];
                drpHabitaciones.SelectedValue = Request.QueryString["Habitaciones"];
                txtLlegada.Text = Request.QueryString["Llegada"];
                txtSalida.Text = Request.QueryString["Salida"];
            }
            else
            {
                Response.Redirect("index.aspx");
            }
            if (!Page.IsPostBack)
            {

            }
        }
        protected void llenarCamposBusqueda()
        {
            DataTable dt = new DataTable();
            dt = sql.getHoteles(txtLlegada.Text, txtSalida.Text, drpHabitaciones.SelectedValue, drpCantidad.SelectedValue);
        }
    }
}
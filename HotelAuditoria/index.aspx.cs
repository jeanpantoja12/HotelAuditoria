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
        Ciudad ciudades = new Ciudad();
      
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                drpCantidad.Items.Insert(0, new ListItem("Cantidad de Personas","0"));
                drpCantidad.Items[0].Attributes["disabled"] = "disabled";
                drpCantidad.SelectedValue = "0";
                llenarCiudad();
            }
            
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            if(txtLlegada.Text=="" || txtSalida.Text =="" || drpCiudad.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Error, insertar todos los campos");
            }
            else
            {
                Response.Redirect("Busquedas.aspx?Llegada=" + txtLlegada.Text+"&Salida=" + txtSalida.Text +"&Destino="+drpCiudad.SelectedValue
                    + "&Personas=" + drpCantidad.SelectedValue+ "&Habitaciones=" + drpHabitaciones.SelectedValue);
                //App_code.dtBusqueda = sql.getHoteles(txtLlegada.Text, txtSalida.Text, drpHabitaciones.SelectedValue, drpCantidad.SelectedValue);
                //Server.Transfer("buscarhotel.aspx");



              //  Response.Redirect("reserva.aspx?parametro=" + txtLlegada.Text);
            }

            

        }
        private void llenarCiudad()
        {
            DataTable dt = new DataTable();
            dt = ciudades.getCiudades();
            
            drpCiudad.DataTextField = "Ci_Nombre";
            drpCiudad.DataValueField = "ID_Ciudad";
            drpCiudad.DataSource = dt;
            drpCiudad.DataBind();
        }
    }
}
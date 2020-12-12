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
            if (Session["Llegada"] != null && Session["Salida"]!=null)
            {
                txtLlegada.Text = Session["Llegada"].ToString();
                txtSalida.Text = Session["Salida"].ToString();
            }
            if (!Page.IsPostBack)
            {
                drpCantidad.Items.Insert(0, new ListItem("Cantidad de Personas","0"));
                drpCantidad.Items.FindByValue("0").Attributes.Add("Disabled","Disabled");
                drpCantidad.SelectedValue = "1";
                selectedFunction();
                llenarCiudad();

            }
            
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            
            if(txtLlegada.Text=="" || txtSalida.Text =="")
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
        void selectedFunction()
        {

            drpCantidad.Items.FindByValue("0").Attributes.Add("Disabled", "Disabled");
            if (drpCantidad.SelectedValue == "1")
            {
                drpHabitaciones.Items.FindByValue("1").Enabled = true;
                drpHabitaciones.Items.FindByValue("2").Enabled = false;
                drpHabitaciones.Items.FindByValue("3").Enabled = false;
                drpHabitaciones.Items.FindByValue("4").Enabled = false;
            }
            if (drpCantidad.SelectedValue == "2")
            {
                drpHabitaciones.Items.FindByValue("1").Enabled = true;
                drpHabitaciones.Items.FindByValue("2").Enabled = true;
                drpHabitaciones.Items.FindByValue("3").Enabled = false;
                drpHabitaciones.Items.FindByValue("4").Enabled = false;
            }
            if (drpCantidad.SelectedValue == "3")
            {
                drpHabitaciones.Items.FindByValue("1").Enabled = true;
                drpHabitaciones.Items.FindByValue("2").Enabled = true;
                drpHabitaciones.Items.FindByValue("3").Enabled = true;
                drpHabitaciones.Items.FindByValue("4").Enabled = false;
            }
            if (drpCantidad.SelectedValue == "4")
            {
                drpHabitaciones.Items.FindByValue("4").Enabled = true;
                drpHabitaciones.Items.FindByValue("2").Enabled = true;
                drpHabitaciones.Items.FindByValue("3").Enabled = true;
                drpHabitaciones.Items.FindByValue("1").Enabled = false;
            }
        }
        protected void drpCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFunction();
            Session["Llegada"] = txtLlegada.Text;
            Session["Salida"] = txtSalida.Text;
        }
    }
}
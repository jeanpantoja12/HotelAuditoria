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
    public partial class WebForm2 : System.Web.UI.Page
    {
        BusquedasHO ho = new BusquedasHO();
        Reservas reserva = new Reservas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Llegada"] != null && Request.QueryString["Personas"] != null && Request.QueryString["Habitaciones"] != null)
                {
                    llenarDatos();
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }

          
            
           // if (Request.Params["parametro"]!=null)
            //{
              //  txtFechaIngreso.Text = Request.Params["parametro"];
            //}




      
        }
        private void llenarDatos()
        {
            DataTable dt = new DataTable();
            string habitaciones;
            string personas;
            if (Convert.ToInt32(Request.QueryString["Habitaciones"]) == 1)
            {
                habitaciones = Request.QueryString["Habitaciones"];
                personas = Request.QueryString["Personas"];
            }
            else
            {
                habitaciones = (Convert.ToInt32(Request.QueryString["Habitaciones"]) / 2).ToString();
                personas = (Convert.ToInt32(Request.QueryString["Personas"]) / 2).ToString();
            }
            txtFechaIngreso.Text = Request.QueryString["Llegada"];
            txtSalida.Text = Request.QueryString["Salida"];
            dt = ho.getHabitacionesHotel(Request.QueryString["Llegada"], Request.QueryString["Salida"], habitaciones, personas, Request.QueryString["Hotel"]);
            dgHabitaciones.DataSource = dt;
            dgHabitaciones.DataBind();
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {


            if (txtNombres.Text != "" & txtApellidos.Text != "" & txtDireccion.Text != "" & txtCorreo.Text != "")
            {

                if (reserva.insertReserva(txtNombres.Text, txtApellidos.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, System.DateTime.Parse(txtFechaIngreso.Text), System.DateTime.Parse(txtSalida.Text), int.Parse(cboPersonas.Text), double.Parse(txtPrecio.Text), int.Parse(txtIdHabitacion.Text)) )

                {
                    lblMensaje.Text = "El registro se guardo correctamente";
                    txtNombres.Text = "";
                    txtApellidos.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                    txtCorreo.Text = "";
                    txtFechaIngreso.Text = "";
                    txtSalida.Text = "";
                    cboPersonas.Text = "";
                    txtPrecio.Text = "";

                }
                else
                {
                    lblMensaje.Text = "El registro no se pudo guardar";
                }



            }
            else
            {
                lblMensaje.Text = "Por favor completa los campos";
            }

        }

        protected void checkDatos_CheckedChanged(object sender, EventArgs e)
        {
            int rowID = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            cboPersonas.Text = dgHabitaciones.Rows[rowID].Cells[5].Text;
            txtPrecio.Text = dgHabitaciones.Rows[rowID].Cells[2].Text;
            txtIdHabitacion.Text = dgHabitaciones.Rows[rowID].Cells[0].Text;
        }
    }
}
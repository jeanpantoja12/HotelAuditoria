using HotelAuditoria.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelAuditoria
{
    public partial class WebForm2 : System.Web.UI.Page
    {

            Reservas reserva = new Reservas();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {


            if (txtNombres.Text != "" & txtApellidos.Text != "" & txtDireccion.Text != "" & txtCorreo.Text != "")
            {
                if (reserva.insertReserva(txtNombres.Text, txtApellidos.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, System.DateTime.Parse(txtFechaIngreso.Text), System.DateTime.Parse(FechaSalida.Text), int.Parse(cboPersonas.Text), double.Parse(txtPrecio.Text)))

                {
                    lblMensaje.Text = "El registro se guardo correctamente";
                    txtNombres.Text = "";
                    txtApellidos.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                    txtCorreo.Text = "";
                    txtFechaIngreso.Text = "";
                    FechaSalida.Text = "";
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
    }
}
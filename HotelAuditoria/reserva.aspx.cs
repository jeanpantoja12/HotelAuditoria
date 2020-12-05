using HotelAuditoria.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelAuditoria
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        BusquedasHO ho = new BusquedasHO();
        Reservas reserva = new Reservas();
        private int idRes;
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
        protected int contarFilas()
        {
            int contFilas = 0;
            foreach (GridViewRow dr in dgHabitaciones.Rows)
            {
                CheckBox check = (dr.Cells[2].FindControl("checkDatos") as CheckBox);

                if (check != null)
                {
                    if (check.Checked)
                    {
                        contFilas++;
                    }
                }
            }
            return contFilas;
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int contadorFilas = 0;
            if (txtNombres.Text != "" & txtApellidos.Text != "" & txtDireccion.Text != "" & txtCorreo.Text != "")
            {
                contadorFilas = contarFilas();
                if (contadorFilas == Convert.ToInt32(Request.QueryString["Habitaciones"]))
                {
                    idRes = reserva.insertReserva(txtNombres.Text, txtApellidos.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, System.DateTime.Parse(txtFechaIngreso.Text), System.DateTime.Parse(txtSalida.Text), int.Parse(cboPersonas.Text), double.Parse(txtPrecio.Text));
                    foreach (GridViewRow dr in dgHabitaciones.Rows)
                    {
                        CheckBox check = (dr.Cells[2].FindControl("checkDatos") as CheckBox);

                        if (check != null)
                        {
                            if (check.Checked)
                            {
                                reserva.insertTReservaHab(idRes.ToString(), dr.Cells[0].Text);
                            }
                        }
                    }
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Venta Registrada','Datos Guardados Correctamente','success').then((value) => { window.location ='index.aspx'; });", true);
                    SendMail();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error','La cantidad de habitaciones es incorrecta.','error');", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error','Completar los datos correctamente.','error');", true);
                //lblMensaje.Text = "Por favor completa los campos";
            }

        }

        protected void checkDatos_CheckedChanged(object sender, EventArgs e)
        {
                        int rowID = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
          
            txtIdHabitacion.Text = dgHabitaciones.Rows[rowID].Cells[0].Text;

            decimal suma=0;
            int totalpersonas = 0;
            foreach (GridViewRow grvRow in dgHabitaciones.Rows)
            {
               CheckBox check = (grvRow.Cells[2].FindControl("checkDatos") as CheckBox);

                if (check != null)
                {
                    if (check.Checked)
                    {
                         suma = dgHabitaciones.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[2].Text));
                        totalpersonas= dgHabitaciones.Rows.Cast<GridViewRow>().Sum(x => Convert.ToInt32(x.Cells[5].Text));
                        
                        txtPrecio.Text = Convert.ToString(suma);
                        cboPersonas.Text = Convert.ToString(totalpersonas);

                    }
                }



              
            }



        }

       

        protected void SendMail()
        {
       
            var fromAddress = "ghgiancohg@gmail.com";
            var toAddress = txtCorreo.Text.ToString();
            const string fromPassword = "trentrigo";

            string subject = txtCorreo.Text.ToString();
            string body = "From: " + txtNombres.Text + "n";
            body += "Email: " + txtCorreo.Text + "n";
            body += "Nombres: " + txtNombres.Text + "n";
            body += "Apellidos: n" + txtApellidos.Text + "n";
            body += "Direccion: n" + txtDireccion.Text + "n";
            body += "Telefono: n" + txtTelefono.Text + "n";
            body += "Fecha LLegada: n" + txtFechaIngreso.Text + "n";
            body += "Fecha Salida: n" + txtSalida.Text + "n";
            body += "Cantidad personas: n" + cboPersonas.Text + "n";
            body += "Precio total: n" + txtPrecio.Text + "n";

            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
        
            smtp.Send(fromAddress, toAddress, subject, body);
        }


    }
    }

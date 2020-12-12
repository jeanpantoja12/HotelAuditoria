using HotelAuditoria.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
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
        private string personas;
        private string cantidad;
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = Request.QueryString["Personas"];
            string query2 = Request.QueryString["Habitaciones"];
            if (null == Session["PersonasID"] && null==Session["HabID"])
            {
                Session["PersonasID"] = query;
                Session["HabID"] = query2;
            }
            if (!Page.IsPostBack)
            {
                personas = Request.QueryString["Personas"];
                cantidad = Request.QueryString["Habitaciones"];
                if (Request.QueryString["Llegada"] != null && Request.QueryString["Personas"] != null && Request.QueryString["Habitaciones"] != null)
                {
                    llenarDatos();
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            string personasCheck = "";
            string habitacionesCheck = "";
            try
            {
                personasCheck = Session["PersonasID"].ToString();
                habitacionesCheck = Session["HabID"].ToString();
            }
            catch (Exception)
            {
                Session.Abandon();
                Response.Redirect("index.aspx");
            }
            if(personasCheck.Equals(Request.QueryString["Personas"].ToString())==false || habitacionesCheck.Equals(Request.QueryString["Habitaciones"].ToString()) == false)
            {
                Session.Abandon();
                Response.Redirect("index.aspx");
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
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "hyddhrii%2moi43Hd5%%";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int contadorFilas = 0;
            if (txtNombres.Text != "" & txtApellidos.Text != "" & txtDireccion.Text != "" & txtCorreo.Text != "")
            {
                contadorFilas = contarFilas();
                if (contadorFilas == Convert.ToInt32(Request.QueryString["Habitaciones"]))
                {
                    idRes = reserva.insertReserva(txtdni.Text,txtNombres.Text, txtApellidos.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, System.DateTime.Parse(txtFechaIngreso.Text), System.DateTime.Parse(txtSalida.Text), int.Parse(cboPersonas.Text), double.Parse(txtPrecio.Text));
                    foreach (GridViewRow dr in dgHabitaciones.Rows)
                    {
                        CheckBox check = (dr.Cells[0].FindControl("checkDatos") as CheckBox);

                        if (check != null)
                        {
                            if (check.Checked)
                            {
                                reserva.insertTReservaHab(idRes.ToString(), dr.Cells[0].Text);
                            }
                        }
                    }
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Venta Registrada','Datos Guardados Correctamente','success').then((value) => { window.location ='index.aspx'; });", true);
                    string idRev = HttpUtility.UrlEncode(Encrypt(idRes.ToString()));
                    string monto = HttpUtility.UrlEncode(Encrypt(txtPrecio.Text));
                    Response.Redirect(string.Format("pasarela.aspx?idReserva={0}&montoTotal={1}", idRev,monto));
                  //  SendMail();
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
                        suma += Convert.ToDecimal(grvRow.Cells[2].Text);
                        totalpersonas += Convert.ToInt32(grvRow.Cells[5].Text);
                        //suma = dgHabitaciones.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[2].Text));
                        //totalpersonas= dgHabitaciones.Rows.Cast<GridViewRow>().Sum(x => Convert.ToInt32(x.Cells[5].Text));
                        
                       

                    }
                    txtPrecio.Text = Convert.ToString(suma);
                    cboPersonas.Text = Convert.ToString(totalpersonas);
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

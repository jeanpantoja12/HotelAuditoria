using HotelAuditoria.modelo;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelAuditoria
{
    public partial class pasarela : System.Web.UI.Page
    {
        private string reserva;
        private string montoT;
        Reservas sql = new Reservas();
        Pasarela pasarel = new Pasarela();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                divReport.Visible = false;
                if (Request.QueryString["idReserva"] == null || Request.QueryString["montoTotal"]==null)
                {
                    
                    Response.Redirect("index.aspx");
                }
                else
                {
                    if (Request.QueryString["idReserva"] != null)
                    {
                        reserva = Decrypt(HttpUtility.UrlDecode(Request.QueryString["idReserva"]));
                        montoT = Decrypt(HttpUtility.UrlDecode(Request.QueryString["montoTotal"]));
                        llenarDatos();
                    }
                   
                }
            }
        }

        private void llenarDatos()
        {
            txtmontototal.Text = montoT;
        }
        private void printPDF()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            divReport.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "hyddhrii%2moi43Hd5%%";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        void llenarVenta()
        {
            DataTable dt = new DataTable();
            dt = sql.getVenta(Decrypt(HttpUtility.UrlDecode(Request.QueryString["idReserva"])));
            Fecha_Entrada.Text = dt.Rows[0][0].ToString();
            Fecha_Salida.Text = dt.Rows[0][1].ToString();
            PrecioT.Text = dt.Rows[0][3].ToString();
            Cli_Name.Text = dt.Rows[0][4].ToString();
            Cli_DNI.Text = dt.Rows[0][5].ToString();
            Habitaciones.Text = dt.Rows[0][6].ToString();
            Boleta.Text = dt.Rows[0][7].ToString();
            //Tarjeta.Text = dt.Rows[0][8].ToString();

        }
        protected void btnpagar_Click(object sender, EventArgs e)
        {
            if (txtcvv.Text != "" & txtnumerot.Text != "" & txtnombres.Text != "" & txtFechaExpiracion.Text != "")
            {
                divReport.Visible = true;
                if (pasarel.insertPasarela(Decrypt(HttpUtility.UrlDecode(Request.QueryString["idReserva"])), txtmontototal.Text, txtnumerot.Text, txtcvv.Text, txtFechaExpiracion.Text, txtnombres.Text, txtemail.Text))

                {
                    lblMensaje.Text = "El registro se guardo correctamente";
                    llenarVenta();
                    printPDF();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Venta Registrada','Datos Guardados Correctamente','success').then((value) => { window.location ='index.aspx'; });", true);
                }
                //Despues de agregar la venta

            }
        }
    }
}
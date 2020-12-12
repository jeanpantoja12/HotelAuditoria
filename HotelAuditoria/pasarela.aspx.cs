using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                if (Request.QueryString["idReserva"] == null || Request.QueryString["montoTotal"]==null)
                {
                    
                    Response.Redirect("index.aspx");
                }
                else
                {
                    reserva = Decrypt(HttpUtility.UrlDecode(Request.QueryString["idReserva"]));
                    montoT = Decrypt(HttpUtility.UrlDecode(Request.QueryString["montoTotal"]));
                    llenarDatos();
                }
            }
        }

        private void llenarDatos()
        {
            txtmontototal.Text = montoT;
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
        protected void btnpagar_Click(object sender, EventArgs e)
        {

        }
    }
}
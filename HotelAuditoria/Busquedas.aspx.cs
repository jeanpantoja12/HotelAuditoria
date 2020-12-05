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
        BusquedasHO sql = new BusquedasHO();
        Ciudad ciudades = new Ciudad();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Destino"] != null && Request.QueryString["Personas"] != null && Request.QueryString["Habitaciones"] != null)
                {
                    llenarCiudad();
                    drpCiudad.SelectedValue = Request.QueryString["Destino"];
                    drpCantidad.SelectedValue = Request.QueryString["Personas"];
                    drpHabitaciones.SelectedValue = Request.QueryString["Habitaciones"];
                    //drpCiudad.SelectedValue = Request.QueryString["Ciudad"];
                    txtLlegada.Text = Request.QueryString["Llegada"];
                    txtSalida.Text = Request.QueryString["Salida"];
                    llenarCamposBusqueda();
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
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
        protected void llenarCamposBusqueda()
        {
            System.Web.UI.HtmlControls.HtmlGenericControl divCol;
            System.Web.UI.HtmlControls.HtmlGenericControl divAcom;
            System.Web.UI.HtmlControls.HtmlGenericControl divImg;
            System.Web.UI.HtmlControls.HtmlGenericControl divDetalle;
            System.Web.UI.HtmlControls.HtmlGenericControl divBoton;
            System.Web.UI.HtmlControls.HtmlGenericControl divImgClass;
            System.Web.UI.HtmlControls.HtmlGenericControl imgHotel;
            System.Web.UI.HtmlControls.HtmlGenericControl aNombre;
            System.Web.UI.HtmlControls.HtmlGenericControl hNombre;
            System.Web.UI.HtmlControls.HtmlGenericControl h4Direccion;
            System.Web.UI.HtmlControls.HtmlGenericControl h4Precio;
            System.Web.UI.HtmlControls.HtmlGenericControl h4Habitaciones;
            System.Web.UI.HtmlControls.HtmlGenericControl h4Oferta;
            System.Web.UI.HtmlControls.HtmlGenericControl h5Ciudad;
            System.Web.UI.HtmlControls.HtmlGenericControl btnReserva;
            DataTable dt = new DataTable();
            dt = sql.getHoteles(txtLlegada.Text, txtSalida.Text, drpHabitaciones.SelectedValue, drpCantidad.SelectedValue,drpCiudad.SelectedValue);
            foreach(DataRow dr in dt.Rows)
            {
                divCol = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divAcom = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divImg = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divDetalle = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divBoton = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divImgClass = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                imgHotel = new System.Web.UI.HtmlControls.HtmlGenericControl("img");
                aNombre = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                hNombre = new System.Web.UI.HtmlControls.HtmlGenericControl("h1"); 
                h4Direccion = new System.Web.UI.HtmlControls.HtmlGenericControl("h4");
                h4Precio = new System.Web.UI.HtmlControls.HtmlGenericControl("h4");
                h4Habitaciones = new System.Web.UI.HtmlControls.HtmlGenericControl("h4");
                h4Oferta = new System.Web.UI.HtmlControls.HtmlGenericControl("h4");
                h5Ciudad= new System.Web.UI.HtmlControls.HtmlGenericControl("h5");
                btnReserva = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                divCol.Attributes.Add("class", "col-lg-12 col-sm-12");
                divAcom.Attributes.Add("class", "accomodation_item text-left");
                divImg.Attributes.Add("class", "col-md-4");
                divImg.Attributes.Add("style", "float:left;");
                divImgClass.Attributes.Add("class", "hotel_img");
                imgHotel.Attributes.Add("src", "image/room1.jpg");
                divDetalle.Attributes.Add("class", "col-md-5");
                divDetalle.Attributes.Add("style", "float:left;");
                hNombre.Attributes.Add("class", "sec_h1");
                divBoton.Attributes.Add("class", "col-md-3");
                divBoton.Attributes.Add("style", "float:left;align-content:center;");
                btnReserva.Attributes.Add("class", "btn theme_btn button_hover");
                btnReserva.Attributes.Add("style", "width:100%;");
                //btnReserva = new System.Web.UI.HtmlControls.HtmlGenericControl("input");
                plHoteles.Controls.Add(divCol);
                divCol.Controls.Add(divAcom);
                divAcom.Controls.Add(divImg);
                divAcom.Controls.Add(divDetalle);
                divAcom.Controls.Add(divBoton);
                divImg.Controls.Add(divImgClass);
                divImgClass.Controls.Add(imgHotel);
                divDetalle.Controls.Add(aNombre);
                aNombre.Controls.Add(hNombre);
                divDetalle.Controls.Add(h4Direccion);
                divDetalle.Controls.Add(h4Precio);
                divDetalle.Controls.Add(h4Habitaciones);
                divBoton.Controls.Add(h4Oferta);
                divBoton.Controls.Add(h5Ciudad);
                divBoton.Controls.Add(h4Oferta);
                //divBoton.InnerHtml = "<br/>";
                divBoton.Controls.Add(btnReserva);
                aNombre.Attributes.Add("href", "#");
                hNombre.InnerText = dr[1].ToString();
                h4Direccion.InnerText ="Dirección: "+ dr[2].ToString();
                h4Precio.InnerText ="Precio Total: S/."+ dr[4].ToString();
                h4Habitaciones.InnerText ="Habitaciones: "+ dr[5].ToString();
                h4Oferta.InnerText = "Oferta:";
                h5Ciudad.InnerText = dr[3].ToString();
                btnReserva.Attributes.Add("href", "reserva.aspx?Hotel="+dr[0].ToString()+"&Llegada=" + Request.QueryString["Llegada"]+"&Salida=" + Request.QueryString["Salida"]
                    + "&Personas=" + Request.QueryString["Personas"] + "&Habitaciones=" + Request.QueryString["Habitaciones"]);
                btnReserva.InnerText = "Reservar";
            }
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Busquedas.aspx?Llegada=" + txtLlegada.Text + "&Salida=" + txtSalida.Text + "&Destino=" + drpCiudad.SelectedValue
                    + "&Personas=" + drpCantidad.SelectedValue + "&Habitaciones=" + drpHabitaciones.SelectedValue);
            llenarCamposBusqueda();
        }
    }
}
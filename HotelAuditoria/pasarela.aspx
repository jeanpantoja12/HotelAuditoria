<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="pasarela.aspx.cs" Inherits="HotelAuditoria.pasarela" %>

  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <!-- Google font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lato:300,400,400i,700&amp;subset=latin-ext" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css" />
    <!-- Bootstrap -->
    <link rel="stylesheet" href="css/bootstrap.min.css" type="text/css" />
    <!-- Page style -->
    <link rel="stylesheet" href="css/pagestyle.css" type="text/css" />
    <!-- Form style -->
    <link rel="stylesheet" href="css/formstyle.css" type="text/css" />
    <link rel="stylesheet" href="css/sweetalert2.min.css">
</asp:Content>
  
  
  <asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="container testimonial_area">
       
        <div class="content" style='margin-top:10px'>
            <div class="row">
               
                <article class="col-md-12">
                    <!-- Start Subscribe Form -->

                    <div class="row">
                        <div class="col-md-10 offset-md-1">
                            <form method="post" name="booking" runat="server" id="booking">
                                <!-- Form Title -->
                                <div class="form-heading text-center">
                                    <div class="title">Pasarela de pagos</div>
                                   
                                </div>
								
								<div class='row' id="resultados_ajax"></div>
                                <!-- Nombres -- Apellidos -->
                                
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Boleta: </label>
                                        <asp:TextBox ID="txtBoleta" required ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                   
                                </div>
                                <div class="row">
                                  
                                    <div class="col-md-6">
                                        <label>Numero de Tarjeta</label>
                                        <asp:TextBox ID="txtnumerot" required onkeypress="return isNumber(event)" pattern="[1-9]{1}[0-9]{9}" runat="server"></asp:TextBox>
									</div>
                                      <div class="col-md-6">
                                        <label>CVV</label>
                                         <asp:TextBox ID="txtcvv" required type="password" onkeypress="return isNumber2(event)" runat="server"></asp:TextBox>
									</div>
                                    
                                </div>
                                 
                                	<div class="row">
                                  <div class="col-md-6">
                                        <label>Fecha de Expiración</label>
                                         <div class="form-group">
                                                <div class='input-group date form_datetime'  id="lstFecha">
                                                    <asp:TextBox ID="txtFechaExpiracion" CssClass="form-control form_datetime" Enabled="false" runat="server"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar" aria-hidden="true">
                                                    
                                                    </i>
                                                    </span>
                                                </div>
                                            </div>
									</div>
                                  
                                     <div class="col-md-6">
                                        <label>Correo electrónico</label>
                                        <asp:TextBox ID="txtemail" required type="email" runat="server"></asp:TextBox> 
									</div>
                                
                                  
                                </div>




                                <!-- Email  -->
                                <div class="row">
                                    
                                       <div class="col-md-8">
                                        <label>Nombres Completos del Titular de la tarjeta</label>
                                        <asp:TextBox ID="txtnombres" required  runat="server"></asp:TextBox>
									</div>

                                       <div class="col-md-3">
                                        <label>Monto</label>
                                        <asp:TextBox ID="txtmontototal" Enabled="false" required type="number" runat="server"></asp:TextBox>
									</div>
                                    
                                </div>
							
                          <div class="row">
                                <asp:Image ID="imgvisa" runat="server" ImageUrl="image/visa.png" />
                                </div>

	
								<br>
                       
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnpagar" CssClass="adam-button" runat="server" Text="PAGAR" OnClick="btnpagar_Click" />
                                        
                                    </div>                                    
                               
                                </div>
                            </form>
                        </div>
                    </div>
                    
                    <asp:Label ID="lblMensaje" runat="server" Text="Mensaje"></asp:Label>
                </article>
                <div class="clearfix"></div>
                <div class="col-md-12" id="divReport" runat="server">
                    <table style="width:100%">
                        <tbody>
                            <tr>
                                <th colspan="9">DETALLE DE VENTA</th>
                            </tr>
                            <tr>
                                <td>Boleta</td>
                                <td><asp:Label ID="Boleta" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Nombre del Cliente</td>
                                <td><asp:Label ID="Cli_Name" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>DNI:</td>
                                <td><asp:Label ID="Cli_DNI" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Número de Tarjeta:</td>
                                <td><asp:Label ID="Tarjeta" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">Fecha de Entrada</td>
                                <td colspan="2"><asp:Label ID="Fecha_Entrada" runat="server" /></td>
                                <td colspan="2">Fecha de Salida</td>
                                <td colspan="3"><asp:Label ID="Fecha_Salida" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="7">Habitaciones</td>
                                <td colspan="2">Precio</td>
                            </tr>
                            <tr>
                                <td colspan ="7"><asp:Label ID="Habitaciones" runat="server" /></td>
                                <td colspan="2"><asp:Label ID="PrecioT" runat="server" /></td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="vendors/bootstrap-datepicker/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="vendors/bootstrap-datepicker//bootstrap-datetimepicker.es.js" charset="UTF-8"></script>
    <script>
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            else {
                if (document.getElementById("<%= txtnumerot.ClientID%>").value.length < 16) {
                    return true;
                } else {
                    return false;
                }
            }
            
        }
        function isNumber2(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            else {
                if (document.getElementById("<%= txtcvv.ClientID%>").value.length < 3) {
                    return true;
                } else {
                    return false;
                }
            }

        }
    </script>
    <script>

        $("#lstFecha").datetimepicker({
            format: "dd-mm-yyyy",
            autoclose: true,
            todayBtn: true,
            startView: 'month',
            minView: 'month',
            startDate: new Date(),
            minuteStep: 10,
            language: 'es'
        });
        //$('#datetimepicker11').data('DateTimePicker').setLocalDate(new Date(year, month, day, 00, 01));
    </script>
    <script type = "text/javascript" >
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
   </script>
</asp:Content>
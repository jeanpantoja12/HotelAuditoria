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
                                  
                                    <div class="col-md-6">
                                        <label>Numero de Tarjeta</label>
                                        <asp:TextBox ID="txtnumerot" required  runat="server"></asp:TextBox>
									</div>
                                      <div class="col-md-6">
                                        <label>CVV</label>
                                         <asp:TextBox ID="txtcvv" required  runat="server"></asp:TextBox>
									</div>
                                    
                                </div>
                                 
                                	<div class="row">
                                  <div class="col-md-6">
                                        <label>Fecha de Expiración</label>
                                         <div class="form-group">
                                                <div class='input-group date' id='datetimepicker11'>
                                                    <asp:TextBox ID="txtFechaExpiracion" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
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
            </div>
        </div>
    </div>
</asp:Content>
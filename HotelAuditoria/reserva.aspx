<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="reserva.aspx.cs" Inherits="HotelAuditoria.WebForm2" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
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
                                    <div class="title">Reservar Habitación</div>
                                   
                                </div>
								
								<div class='row' id="resultados_ajax"></div>
                                <!-- Nombres -- Apellidos -->
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Nombres</label>
                                        <asp:TextBox ID="txtNombres" required  runat="server"></asp:TextBox>
									</div>
                                    <div class="col-md-6">
                                        <label>Apellidos</label>
                                        <asp:TextBox ID="txtApellidos" required  runat="server"></asp:TextBox>
									</div>
                                </div>
                                   <!-- Direccion  -->
                                	<div class="row">
                                    <div class="col-md-8">
                                        <label>Dirección</label>
                                         <asp:TextBox ID="txtDireccion" required  runat="server"></asp:TextBox>
									</div>
                                  
                                </div>

                                <!-- Email  -->
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Teléfono</label>
                                        <asp:TextBox ID="txtTelefono" required  runat="server"></asp:TextBox>
									</div>
                                    <div class="col-md-6">
                                        <label>Correo electrónico</label>
                                        <asp:TextBox ID="txtCorreo" required  runat="server"></asp:TextBox> 
									</div>
                                    
                                </div>
								
															
								
								<div class="row">
                                    <div class="col-md-6">
                                        <label>Fecha ingreso</label>
                                       <asp:TextBox ID="txtFechaIngreso" runat="server"></asp:TextBox>  
									</div>
                                    <div class="col-md-6">
                                        <label>Fecha salida</label>
                                        <asp:TextBox ID="FechaSalida" runat="server"></asp:TextBox>  
									</div>	
                                </div>
								
								<div class="row">
                                    <div class="col-md-6">
                                        <label>Personas<br />
                                       <br>
                                        </label>
                                            <asp:DropDownList ID="cboPersonas" runat="server">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                        </asp:DropDownList>
									</div>
                                    <div class="col-md-6">
                                        <label>Precio</label>
                                     <asp:TextBox ID="txtPrecio"  runat="server"></asp:TextBox>  
									</div>	
                                </div>
								<br>
                       
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnEnviar" CssClass="adam-button" runat="server" Text="ENVIAR" OnClick="btnEnviar_Click" />
                                        
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
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>

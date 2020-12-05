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
                                        <label>Fecha de LLegada</label>
                                         <div class="form-group">
                                                <div class='input-group date' id='datetimepicker11'>
                                                    <asp:TextBox ID="txtFechaIngreso" CssClass="form-control" runat="server"></asp:TextBox>
                                                
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar" aria-hidden="true">
                                                    
                                                    </i>
                                                    </span>
                                                </div>
                                            </div>
									</div>
                                    <div class="col-md-6">
                                     <label>Fecha de Salida</label>
                                        <div class="form-group">
                                                <div class='input-group date' id='datetimepicker11'>
                                                    <asp:TextBox ID="txtSalida" CssClass="form-control" runat="server"></asp:TextBox>
                                                
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar" aria-hidden="true">
                                                    
                                                    </i>
                                                    </span>
                                                </div>
                                            </div>		 
									</div>	
                                
                                </div>




                                <div class="row">
                                    
                                    <div class="col-md-12">
                                        <label>Habitaciones</label>
                                        <asp:GridView ID="dgHabitaciones" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100px">
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                            <Columns>
                                                <asp:BoundField DataField="ID_Habitacion" HeaderText="ID Habitación" />
                                                <asp:BoundField DataField="HAB_Numero" HeaderText="Num de Habitacion" />
 
                                                <asp:BoundField DataField="HAB_Precio" HeaderText="Precio(S/.)" />
                                                <asp:BoundField DataField="HAB_Descripcion" HeaderText="Descripción" />
                                                <asp:BoundField DataField="HAB_Tipo" HeaderText="Tipo" />
                                                <asp:BoundField DataField="HAB_Personas" HeaderText="Cantidad de Personas" />
                                            </Columns>
                                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                            <Columns>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                            <asp:CheckBox ID="checkDatos" runat="server" AutoPostBack="True" OnCheckedChanged="checkDatos_CheckedChanged" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
									</div>	
                                </div>




                          
                                
								
								<div class="row">

                               
                                    <div class="col-md-6">
                                    
                                         <label>Personas</label>
                                        <asp:TextBox ID="cboPersonas" required  runat="server"></asp:TextBox>
									</div>
                                    <div class="col-md-6">
                                        <label>Precio</label>
                                     <asp:TextBox ID="txtPrecio"  runat="server"></asp:TextBox>  
									</div>
                                    
                                     <div class="col-md-6">
                                    
                                         &nbsp;<asp:TextBox ID="txtIdHabitacion" required  runat="server" Visible="False"></asp:TextBox>
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

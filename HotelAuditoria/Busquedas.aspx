<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Busquedas.aspx.cs" Inherits="HotelAuditoria.Busquedas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <section class="breadcrumb_area">
            <div class="overlay bg-parallax" data-stellar-ratio="0.8" data-stellar-vertical-offset="0" data-background=""></div>
            <div class="container">
                <div class="page-cover text-center">
                    <h2 class="page-cover-tittle">Buscar Hotel</h2>
                    <ol class="breadcrumb">
                        <li><a href="index.html">Home</a></li>
                        <li class="active">Busquedas</li>
                    </ol>
                </div>
            </div>
        <div class="hotel_booking_area position">
                <form id="form1" runat="server">
                    <div class="container">
                    <div class="hotel_booking_table">
                        <div class="col-md-3">
                            <h2>Reserva <br> tu Habitación</h2>
                        </div>
                        <div class="col-md-9">
                            <div class="boking_table">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="book_tabel_item">
                                            <div class="form-group">
                                                <div class='input-group date' id='datetimepicker11'>
                                                    <asp:TextBox ID="txtLlegada" CssClass="form-control" autocomplete="off" required placeholder="Fecha de Llegada" runat="server"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator id="RequiredFieldValidator1" ControlToValidate="txtLlegada" ErrorMessage="Required" runat="server"/>--%>
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar" aria-hidden="true"></i>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class='input-group date' id='datetimepicker1'>
                                                    <asp:TextBox ID="txtSalida" CssClass="form-control" required placeholder="Fecha de Salida" runat="server"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar" aria-hidden="true"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="book_tabel_item">
                                            <div class="input-group">
                                                <asp:DropDownList CssClass="wide" ID="drpCantidad" AutoPostBack="true" OnSelectedIndexChanged="drpCantidad_SelectedIndexChanged" runat="server">
                                                    <asp:ListItem Value="1">1 Persona</asp:ListItem>
                                                    <asp:ListItem Value="2">2 Personas</asp:ListItem>
                                                    <asp:ListItem Value="3">3 Personas</asp:ListItem>
                                                    <asp:ListItem Value="4">4 Personas</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="input-group">
                                                <asp:DropDownList CssClass="wide" ID="drpCiudad" data-display="Niños" runat="server">
                                                    
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="book_tabel_item">
                                            <div class="input-group">
                                                <asp:DropDownList CssClass="wide" data-display="Habitaciones" ID="drpHabitaciones" runat="server">
                                                    <asp:ListItem Value="1">1 Habitación</asp:ListItem>
                                                    <asp:ListItem Value="2">2 Habitaciones</asp:ListItem>
                                                    <asp:ListItem Value="3">3 Habitaciones</asp:ListItem>
                                                    <asp:ListItem Value="4">4 Habitaciones</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                            <asp:Button ID="btnReservar" runat="server" Text="Buscar"  CssClass="book_now_btn button_hover" OnClick="btnReservar_Click"/>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </form>
                
            </div>
        </section>
    <section class="accomodation_area section_gap">
            <div class="container">
                <div class="section_title text-center">
                    <h2 class="title_color">Búsquedas Relacionadas</h2>
                    <p>Resultados:</p>
                </div>
                <div class="row mb_30">
                    <asp:PlaceHolder ID="plHoteles" runat="server"></asp:PlaceHolder>
                    <%--<div class="col-lg-12 col-sm-12">
                        <div class="accomodation_item text-left">
                            <div class="col-md-4" style="float:left">
                            
                                <div class="hotel_img">
                                <img src="image/room1.jpg" alt="">
                                
                                </div>
                        </div>
                        
                        <div class="col-md-5" style="float:left">
                                <a href="#"><h1 class="sec_h1">Hotel Los Pinos</h1></a>
                            <h4>Dirección: <small>Jr. Los Pinos 150</small></h4>
                            <h4>Precio Total: <small>S/.150.00</small></h4>
                            <h4>Habitaciones: <small>2</small></h4>
                            </div>
                            <div class="col-md-3" style="float:left;align-content:center">
                                <h4>Oferta:</h4>
                                <h5>Huancayo</h5>
                                <br />
                            <a href="#" class="btn theme_btn button_hover" style="width:100%">Reservar</a>
                        </div>
                        </div>
                        
                    </div>--%>
                                       
                </div>
            </div>
        </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="vendors/bootstrap-datepicker/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="vendors/bootstrap-datepicker//bootstrap-datetimepicker.es.js" charset="UTF-8"></script>
    <script>

        $("#lstllegada").datetimepicker({
            format: "dd-mm-yyyy hh:ii",
            autoclose: true,
            todayBtn: true,
            startDate: new Date(),
            minuteStep: 10,
            language: 'es'
        });
        $("#lstsalida").datetimepicker({
            format: "dd-mm-yyyy hh:ii",
            autoclose: true,
            todayBtn: true,
            startDate: "2013-02-14 10:00",
            minuteStep: 10,
            language: 'es'
        });
        $('#lstllegada').datetimepicker().on('changeDate', function (ev) {
            var departureDate = ev.date;
            var endDate = new Date();
            departureDate.setDate(departureDate.getDate() + 1);
            endDate.setDate(departureDate.getDate() + 6);
            $('#lstsalida').datetimepicker('setStartDate', departureDate);
            $('#lstsalida').datetimepicker('setEndDate', endDate);
        });

        $('#lstsalida').datetimepicker().on('changeDate', function (ev) {
            var returnDate = ev.date;
            $('#lstllegada').datetimepicker('setEndDate', returnDate);
        });
        //$('#datetimepicker11').data('DateTimePicker').setLocalDate(new Date(year, month, day, 00, 01));
    </script>
</asp:Content>

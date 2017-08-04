<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaInfo.aspx.cs" Inherits="WebAppBasicosParisina.ConsultaInfo" EnableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Titulo o nombre de la pagina web -->
    <title>Basicos Parisina | Skytex México</title>

    <!-- Icono de la aplicacion web -->
    <link rel="shortcut icon" href="Media/skytex.ico" />

    <!-- Etiquetas META para la compatibilidad de IE -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"/>
    <!-- Referencia a estilos en la carpeta Content -->
    <link type="text/css" rel="stylesheet" href="<%=ResolveUrl("~/Content/bootstrap.css")%>" />

    <!-- Referencia de archivos JavaScript en la carpeta Scripts -->
    <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/jquery-1.10.2.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/bootstrap.js") %>"></script>
</head>
<body>
    <form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">
                    <img alt="Brand" src="Media/Imagenes/logoSkytexB.png" width="17" height="15" />
                </a>
            </div>
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="Inicio.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span> Inicio <span class="sr-only">(current)</span></a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><asp:LinkButton ID="lnkCerrarSession" runat="server" OnClick="CerrarSession"><span class="glyphicon glyphicon-log-in" aria-hidden="true"> </span> Cerrar Sesion</asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </nav>
    <br />
    <br />
    <br />
    <br />
    <div style="padding-left:5px; padding-right:5px;">
        <div class="well">
            <div class="form-inline">
                <div class="form-group">
                    <div class="col-md-2">
                        <img src="Media/Imagenes/logo_skytex.png" width="50" height="50" />
                    </div>
                    <div class="col-md-8">
                        <h2>Resurtido_Parisina</h2>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-4">
                        <br />
                        <%-- <asp:Button ID="btnGenPed" runat="server" Text="Genera Pedido" CssClass="btn btn-success" OnClick="btnGenPed_Click" /> --%>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div style="width: 40%;float: left; position:relative; min-height: 1px; padding-left: 15px;">
                <asp:GridView ID="gvBP" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#042644" HeaderStyle-ForeColor="White"
                    EmptyDataText="No hay resultados para la busqueda" Font-Size="X-Small" OnDataBound="OnDataBound" OnRowCreated = "OnRowCreated">
                    <HeaderStyle Font-Bold="True" />
                    <Columns>
                        <asp:BoundField DataField="telanom" HeaderText="Producto:"  HeaderStyle-Height="60px" ItemStyle-Width="150px" HtmlEncode="false" />
                        <asp:BoundField DataField="color_bar" HeaderText="Color Variante:" HeaderStyle-Height="60px"  HtmlEncode="false"/>
                        <asp:BoundField DataField="desc_cliente" HeaderText="Descripcion Cliente:" ItemStyle-Height="50px" ItemStyle-Width="200px"  HeaderStyle-Height="60px" />
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width: 59%;float: left; position:relative; min-height: 1px; padding-right: 15px; overflow-x:scroll;">
                <asp:GridView ID="gvBP2" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#042644" HeaderStyle-ForeColor="White"
                    EmptyDataText="No hay resultados para la busqueda" Font-Size="X-Small" OnDataBound="OnDataBound2" OnRowCreated = "OnRowCreated2" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="inv_int_trans" HeaderText="Inventario inc intermedio y transito:" ItemStyle-HorizontalAlign = "Right"  ItemStyle-Height="50px" HeaderStyle-Height="60px"  />
                        <asp:BoundField DataField="rollos_ped_xsurtir" HeaderStyle-Height="60px" HeaderText="Pedidos x Surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_xsurtir_old" HeaderStyle-Height="60px" HeaderText="'Pedidos viejos x surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_surtidos" HeaderStyle-Height="60px" HeaderText="Pedidos Surtidos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="ExistTotal" HeaderText="Exis Total:"  HeaderStyle-Height="60px" ItemStyle-BackColor="#3B6B97" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="com_sug_tarima" HeaderText="Compra Sugerida Tarima:"  HeaderStyle-Height="60px" ItemStyle-BackColor="#AF7728" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="sobra_desp_compra" HeaderText="Sobrante despues compra disp" HeaderStyle-Height="60px" ItemStyle-BackColor="#8D2F0C" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="faltanteAlmacen" HeaderText="Faltante vs almacen:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="faltAlmPedido" HeaderText="Faltante vs almacen + pedidos:" HeaderStyle-Height="60px" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="max_tarima" HeaderStyle-Height="60px" HeaderText="Maximo tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="preorden_tarima" HeaderStyle-Height="60px" HeaderText="Punto de reorden tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="temporada_tarima" HeaderStyle-Height="60px" HeaderText="Temporada tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="dispo_tarima" HeaderStyle-Height="60px" HeaderText="Tarima x dispo:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="resurtido_rollos" HeaderStyle-Height="60px" HeaderText="Fabricar para Resurtido Dispos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"  HeaderStyle-Wrap="false" />
                        <asp:BoundField DataField="resurtido_mts" HeaderText="Fabricar para Resurtido Mts:" HeaderStyle-Height="60px" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="resurtido_tarima" HeaderText="Fabricar para Resurido tarimas:" HeaderStyle-Height="60px" ItemStyle-BackColor="#9BC2E6" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="tarima_extra" HeaderText="Tarimas Extras en pedido:" HeaderStyle-Height="60px" ItemStyle-BackColor="#3B6B97" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="autorizadoXpedido" HeaderText="Autorizado x meter_pedidos:" HeaderStyle-Height="60px" ItemStyle-BackColor="#006F07" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="demanda_residual" HeaderText="Demanda Residual:" HeaderStyle-Height="60px" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="compra_sugerida" HeaderText="Parisina Demanda:" ItemStyle-BackColor="#3B6B97" ItemStyle-ForeColor="WhiteSmoke" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"/>
                        <asp:BoundField DataField="fabTemporadaTarima" HeaderStyle-Height="60px" HeaderText="Fabricar para Temporada tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" HeaderStyle-Wrap="false" />
                        <asp:BoundField DataField="fabTemporadaDispo" HeaderStyle-Height="60px" HeaderText="Fabricar para Temporada dispos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" HeaderStyle-Wrap="false" />
                        <asp:BoundField DataField="excedentePedido" HeaderText="Excedentes inc Pedidos:" HeaderStyle-Height="60px" ItemStyle-BackColor="#DBB721" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"/>
                        <asp:BoundField DataField="excedenteBodega" HeaderStyle-Height="60px" HeaderText="Excedentes en Bodega:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="skuSinExis" HeaderStyle-Height="60px" HeaderText="Sku sin existencia:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="skuBajoDisp" HeaderStyle-Height="60px" HeaderText="Sku bajo disponible:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="contSku_cve" HeaderStyle-Height="60px" HeaderText="Total Skus:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_tarima" HeaderStyle-Height="60px" HeaderText="Rollos x tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollo_mts" HeaderStyle-Height="60px" HeaderText="Mts x rollo.:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    </form>
    <br />
    <br />
    <br />
    <div class="container">
        <footer class="piePagina">
            <address>
                <strong>Skytex México S.A de C.V. <%= DateTime.Now.ToString("yyyy") %></strong><br />
                Corredor Industrial Quetzalcóatl, Huejotzingo, Pue<br />
            </address>

            <address>
                <strong>Pagina Web</strong><br />
                <a href="http://www.skytex.com.mx/">Skytex México</a>
            </address>
        </footer>
    </div>
</body>
</html>

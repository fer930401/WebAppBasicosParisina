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
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- Referencia a estilos en la carpeta Content -->
    <link type="text/css" rel="stylesheet" href="<%=ResolveUrl("~/Content/bootstrap.css")%>" />

    <!-- Referencia de archivos JavaScript en la carpeta Scripts -->
    <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/jquery-1.10.2.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/bootstrap.js") %>"></script>
</head>
<body>
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
            </div>
        </div>
    </nav>
    <br />
    <br />
    <br />
    <br />
    <form id="form1" runat="server">
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
                        <asp:Button ID="btnGenPed" runat="server" Text="Genera Pedido" CssClass="btn btn-success" OnClick="btnGenPed_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:GridView ID="gvBP" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#042644" HeaderStyle-ForeColor="White"
                    EmptyDataText="No hay resultados para la busqueda" Font-Size="X-Small" OnDataBound="OnDataBound" OnRowCreated = "OnRowCreated">
                    <HeaderStyle Font-Bold="True" />
                    <Columns>
                        <asp:BoundField DataField="telanom" HeaderText="Producto:" />
                        <asp:BoundField DataField="color_bar" HeaderText="Color Variante:" />
                        <asp:BoundField DataField="desc_cliente" HeaderText="Descripcion Cliente:" />
                        <asp:BoundField DataField="inv_int_trans" HeaderText="Inventario inc intermedio y transito:" />
                        <asp:BoundField DataField="rollos_ped_xsurtir" HeaderText="Pedidos x Surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_xsurtir_old" HeaderText="'Pedidos viejos x surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_surtidos" HeaderText="Pedidos Surtidos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="ExistTotal" HeaderText="Exis Total:"  ItemStyle-BackColor="Gray" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="com_sug_tarima" HeaderText="Compra Sugerida Tarima:"  ItemStyle-BackColor="#9BC2E6"  ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="sobra_desp_compra" HeaderText="Sobrante despues compra disp" ItemStyle-BackColor="#F4B084" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="faltanteAlmacen" HeaderText="Faltante vs almacen:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="faltAlmPedido" HeaderText="Faltante vs almacen + pedidos:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="max_tarima" HeaderText="Maximo tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="preorden_tarima" HeaderText="Punto de reorden tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="temporada_tarima" HeaderText="Temporada tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="dispo_tarima" HeaderText="Tarima x dispo:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="resurtido_rollos" HeaderText="Fabricar para Resurtido Dispos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="resurtido_mts" HeaderText="Fabricar para Resurtido Mts:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="resurtido_tarima" HeaderText="Fabricar para Resurido tarimas:" ItemStyle-BackColor="#9BC2E6" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="tarima_extra" HeaderText="Tarimas Extras en pedido:" ItemStyle-BackColor="#DDEBF7" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="autorizadoXpedido" HeaderText="Autorizado x meter_pedidos:" ItemStyle-BackColor="#92CE50" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="demanda_residual" HeaderText="Demanda Residual:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="compra_sugerida" HeaderText="Parisina Demanda:" ItemStyle-BackColor="#DDEBF7" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"/>
                        <asp:BoundField DataField="fabTemporadaTarima" HeaderText="Fabricar para Temporada tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="fabTemporadaDispo" HeaderText="Fabricar para Temporada dispos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="excedentePedido" HeaderText="Excedentes inc Pedidos:" ItemStyle-BackColor="#FFFF00" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"/>
                        <asp:BoundField DataField="excedenteBodega" HeaderText="Excedentes en Bodega:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="skuSinExis" HeaderText="Sku sin existencia:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="skuBajoDisp" HeaderText="Sku bajo disponible:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="contSku_cve" HeaderText="Total Skus:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_tarima" HeaderText="Rollos x tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollo_mts" HeaderText="Mts x rollo.:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
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

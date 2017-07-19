<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppBasicosParisina._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding-left:5px; padding-right:5px;">
        <div class="well">
            <div class="form-inline">
                <div class="form-group">
                    <img src="Media/Imagenes/logo_skytex.png" width="50" height="50" />
                </div>
                <div class="form-group">
                    <h2>Resurtido Parisina</h2>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnGenPed" runat="server" Text="Genera Pedido" CssClass="btn btn-success" />
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
                        <asp:TemplateField HeaderText="Color variante">
                            <ItemTemplate>
                                <%# Eval("color_cliente") + ", ," + Eval("code_bar")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="desc_cliente" HeaderText="Descripcion Cliente:" />
                        <asp:BoundField  HeaderText="Inventario inc intermedio y transito:" />
                        <asp:BoundField DataField="rollos_ped_xsurtir" HeaderText="Pedidos x Surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_xsurtir_old" HeaderText="'Pedidos viejos x surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_surtidos" HeaderText="Pedidos Surtidos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField  HeaderText="Exis Total:"  ItemStyle-BackColor="Gray"/>
                        <asp:BoundField  HeaderText="Compra Sugerida Tarima" ItemStyle-BackColor="#9BC2E6" />
                        <asp:BoundField  HeaderText="Sobrante despues compra disp" ItemStyle-BackColor="#F4B084" />
                        <asp:BoundField  HeaderText="Faltante vs almacen:" />
                        <asp:BoundField  HeaderText="Faltante vs almacen+pedidos:" />
                        <asp:BoundField DataField="max_tarima" HeaderText="Maximo tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField  HeaderText="Punto de reorden tarima:" />
                        <asp:BoundField DataField="temporada_tarima" HeaderText="Temporada tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="dispo_tarima" HeaderText="Tarima x dispo:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField  HeaderText="Fabricar para Resurtido Dispos:" />
                        <asp:BoundField  HeaderText="Fabricar para Resurtido Mts:" />
                        <asp:BoundField  HeaderText="Fabricar para Resurido tarimas:" ItemStyle-BackColor="#9BC2E6" />
                        <asp:BoundField  HeaderText="Tarimas Extras en pedido:" ItemStyle-BackColor="#DDEBF7" />
                        <asp:TemplateField  HeaderText="Autorizado x meter pedidos:" ItemStyle-BackColor="#92CE50" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtNumTarimas" runat="server" TextMode="Number" CssClass="form-control" Min="0" Value="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField  HeaderText="Demanda Residual:" />
                        <asp:BoundField  HeaderText="Parisina Demanda:" ItemStyle-BackColor="#DDEBF7" />
                        <asp:BoundField  HeaderText="Fabricar para Temporada tarimas:" />
                        <asp:BoundField  HeaderText="Fabricar para Temporada dispos:" />
                        <asp:BoundField  HeaderText="Excedentes inc Pedidos:" />
                        <asp:BoundField  HeaderText="Excedentes en Bodega:" ItemStyle-BackColor="#FFFF00" />
                        <asp:BoundField  HeaderText="Sku sin existencia:" />
                        <asp:BoundField  HeaderText="Sku bajo disponible:" />
                        <asp:BoundField  HeaderText="Total Skus:" />
                        <asp:BoundField DataField="rollo_yardas" HeaderText="Rollos x tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField  HeaderText="Mts x rollo.:" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

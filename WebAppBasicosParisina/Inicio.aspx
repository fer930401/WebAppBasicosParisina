<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppBasicosParisina._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function CalculateTotals() {
            var gv = document.getElementById("<%= gvBP.ClientID %>");
            var lblSCD = gv.getElementsByClassName("lblSobranteComDispo");
            var lblExis = gv.getElementsByClassName("lblExisTotal");
            var lblCST = gv.getElementsByClassName("lblCST");
            var tb = gv.getElementsByTagName("input");
            var lb = gv.getElementsByTagName("span");

            var sub = 0;
            var total = 0;
            var indexQ = 1;
            var indexP = 0;

            sub = parseFloat(lblExis.innerHTML) * parseFloat(lblCST.innerHTML);
                    if (isNaN(sub)) {
                        sub = 0;
                    }
                    else {
                        lblSCD.innerHTML = sub;
                    }

                    
        }
    </script>
    <div style="padding-left:5px; padding-right:5px;">
        <div class="well">
            <div class="form-inline">
                <div class="form-group col-md-3">
                    <img src="Media/Imagenes/logo_skytex.png" width="50" height="50" />
                </div>
                <div class="form-group">
                    <h2>Resurtido Parisina</h2>
                </div>
                <div class="form-group">
                    <br />
                    <asp:Button ID="btnGenPed" runat="server" Text="Genera Pedido" CssClass="btn btn-success" OnClick="btnGenPed_Click" />
                </div>
                <div class="form-group">
                    <h2>Resurtido Parisina</h2>
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
                        <asp:BoundField  HeaderText="Inventario inc intermedio y transito:" />
                        <asp:BoundField DataField="rollos_ped_xsurtir" HeaderText="Pedidos x Surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_xsurtir_old" HeaderText="'Pedidos viejos x surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_surtidos" HeaderText="Pedidos Surtidos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:TemplateField HeaderText="Exis Total:"  ItemStyle-BackColor="Gray" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblExisTotal" runat="server" Text='<%# ExisTotal("0", Eval("rollos_ped_xsurtir").ToString(), Eval("rollos_ped_xsurtir_old").ToString(), Eval("rollos_ped_surtidos").ToString()) %>'></asp:Label>
                                <%-- agregar Inventario inc intermedio y transito: al primer parametro --%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Compra Sugerida Tarima:"  ItemStyle-BackColor="#9BC2E6"  ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblCST" runat="server" Text='<%# compraSugerida("0") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sobrante despues compra disp" ItemStyle-BackColor="#F4B084" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblSDC" runat="server" Text='<%# restaColumnas() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Faltante vs almacen:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblFA" runat="server" Text='<%# restaExistSobrante() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Faltante vs almacen + pedidos:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblFAP" runat="server" Text='<%# sumaFaltanteAlmacen(Eval("rollos_ped_xsurtir").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="max_tarima" HeaderText="Maximo tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="preorden_tarima" HeaderText="Punto de reorden tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="temporada_tarima" HeaderText="Temporada tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="dispo_tarima" HeaderText="Tarima x dispo:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="resurtido_rollos" HeaderText="Fabricar para Resurtido Dispos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:TemplateField HeaderText="Fabricar para Resurtido Mts:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblFRMTS" runat="server" Text='<%# resurtidoMTS(Eval("rollos_tarima","{0:N2}").ToString(), Eval("rollo_yardas","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField  HeaderText="Fabricar para Resurido tarimas:" ItemStyle-BackColor="#9BC2E6" />
                        <asp:BoundField  HeaderText="Tarimas Extras en pedido:" ItemStyle-BackColor="#DDEBF7" />
                        
                        <asp:TemplateField  HeaderText="Autorizado x meter_pedidos:" ItemStyle-BackColor="#92CE50" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtNumTarimas" runat="server" TextMode="Number" CssClass="form-control" Min="0" Value="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Demanda Residual:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblDemResi" runat="server" Text='<%# demandaResidual(Eval("max_tarima","{0:N2}").ToString(),Eval("preorden_tarima","{0:N2}").ToString(),Eval("dispo_tarima","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="compra_sugerida" HeaderText="Parisina Demanda:" ItemStyle-BackColor="#DDEBF7" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"/>
                        <asp:BoundField  HeaderText="Fabricar para Temporada tarimas:" />
                        <asp:BoundField  HeaderText="Fabricar para Temporada dispos:" />
                        <asp:BoundField  HeaderText="Excedentes inc Pedidos:" ItemStyle-BackColor="#FFFF00" ItemStyle-HorizontalAlign = "Right"/>

                        <asp:TemplateField HeaderText="Excedentes en Bodega:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblExcBod" runat="server" Text='<%# excedenteBodega(Eval("stock").ToString(),Eval("max_parisina").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sku sin existencia:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblSkuSinExis" runat="server" Text='<%# skuSinExist(Eval("stock").ToString(),Eval("contSku_cve").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sku bajo disponible:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblSkuBajoDispo" runat="server" Text='<%# skuBajoExist(Eval("stock").ToString(),Eval("contSku_cve").ToString(), Eval("min_parisina").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="contSku_cve" HeaderText="Total Skus:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_tarima" HeaderText="Rollos x tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:TemplateField HeaderText="Mts x rollo.:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblMTSR" runat="server" Text='<%# mtsRollos(Eval("rollo_yardas","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

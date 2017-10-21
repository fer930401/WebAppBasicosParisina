<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppBasicosParisina._Default" EnableEventValidation="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        function CalculateTotals() {
            var gv = document.getElementById("<%= gvBP.ClientID %>");
            var txtTarExtrasPed = gv.getElementsByClassName("txtTarExtrasPed");
            var txtNumTarimas = gv.getElementsByClassName("txtNumTarimas");
            var txtDemResidual = gv.getElementsByClassName("txtDemResidual");

            var sub = 0;
            var total = 0;
            var indexQ = 1;
            var indexP = 0;
            for (var i = 0; i < txtNumTarimas.length; i++) {
                sub = parseFloat(txtTarExtrasPed[i].value) + parseFloat(txtNumTarimas[i].value);
                if (isNaN(sub)) {
                    txtDemResidual[i].value = "0";
                    sub = 0;
                }
                else {
                    txtDemResidual[i].value = sub;
                }
                indexQ++;
                indexP = indexP + 2;
                total += parseFloat(sub);
            }
            txtDemResidual[txtDemResidual.length - 1].value = total;
            
        }
        $(document).ready(function () {
            $(window).scroll(function () {
                $('.flotante').slideDown(300);
            });
        });
    </script>
    <style type="text/css">
        .minusculas {
            text-transform: lowercase;
        }

        .mayusculas {
            text-transform: uppercase;
        }
        .flotante{
            width: 100%;
            float: right;
            position: fixed;
            top:50px;
            text-align:left;
            cursor:pointer;
            z-index:99;
            background-color: rgba(4, 38, 68, 0)
        }  
    </style>
    <div style="padding-left:5px; padding-right:5px;">
        <div class="flotante">
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
                        <div class="col-md-6">
                            <asp:Label ID="lblBusqueda" runat="server" Text="Busqueda de fechas pasadas"></asp:Label>
                            <asp:DropDownList ID="ddlBusqueda" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBusqueda_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <!--<div class="flotante">
            <br />
            <br />
            <br />
        </div>    -->   
        <div class="row">
            <div class="col-md-4">
                <asp:GridView ID="gvBP" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#042644" HeaderStyle-ForeColor="White"
                    EmptyDataText="No hay resultados para la busqueda" Font-Size="X-Small" OnDataBound="OnDataBound" OnRowCreated = "OnRowCreated" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="telanom" HeaderText="Producto:"/>
                        <asp:BoundField HeaderText="Code bar:"/>
                        <asp:BoundField DataField="color_bar" HeaderText="Color Variante:"/>
                        <asp:BoundField DataField="desc_cliente" HeaderText="Descripcion Cliente:"/>
                        <asp:BoundField DataField="sku_cve" HeaderText="Sku_cve:"/>
                        <asp:BoundField DataField="art_tip" HeaderText="Art_tip:"/>
                        <asp:BoundField HeaderText="Cancelar pedidos:"/>
                        <asp:TemplateField HeaderText="Inventario inc intermedio y transito:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblInvIIT" runat="server" Text='<%# inventarioIntTrans(Eval("rollos_ped").ToString(), Eval("rollos_ped_surtidos").ToString(), Eval("rollos_ped_xsurtir").ToString(), Eval("rollos_ped_xsurtir_old").ToString(), Eval("resurtido_rollos").ToString(), Eval("rollos_tarima").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="rollos_ped_xsurtir" HeaderText="Pedidos x Surtir Tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_xsurtir_old" HeaderText="'Pedidos viejos x surtir Tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_surtidos" HeaderText="Pedidos Surtidos Tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:TemplateField HeaderText="Exis Total:"  ItemStyle-BackColor="#3B6B97" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblExisTotal" runat="server" Text='<%# ExisTotal(Eval("stock").ToString(), Eval("rollos_ped_surtidos").ToString(), Eval("rollos_ped_xsurtir").ToString(), Eval("rollos_ped_xsurtir_old").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Pedidos Extra:"/>
                        <asp:TemplateField HeaderText="Compra Sugerida Tarima:"  ItemStyle-BackColor="#AF7728" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblCST" runat="server" Text='<%# compraSugerida(Eval("compra_sugerida").ToString(),Eval("rollos_tarima").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Sobrante vs almacen+pedidos:"/>
                        <asp:BoundField HeaderText="Existencia Parisina Tarimas:"/>
                        <asp:BoundField DataField="compra_sugerida" HeaderText="Parisina Demanda:" ItemStyle-BackColor="#3B6B97" ItemStyle-ForeColor="WhiteSmoke" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"/>
                        <asp:BoundField HeaderText="Parisina Demanda No Surtida:"/>
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
                        <asp:TemplateField HeaderText="Fabricar para Resurido tarimas:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblFRT" runat="server" Text='<%# resurtidoTarima(Eval("resurtido_rollos","{0:N2}").ToString(), Eval("rollos_tarima","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Autorizado x meter_pedidos:" ItemStyle-BackColor="#006F07"  ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtNumTarimas" runat="server" TextMode="Number" CssClass="form-control txtNumTarimas" style="background-color:#006F07; color:whitesmoke;" Min="0" Value="0" Font-Size="Small" onkeyup="CalculateTotals();" onclick="CalculateTotals();" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Pedidos Adicionales:"/>
                        <asp:TemplateField HeaderText="Demanda Residual:" ItemStyle-HorizontalAlign = "Right" ItemStyle-Width="120px" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtDemResidual" runat="server" CssClass="form-control txtDemResidual" Font-Size="Small" style="cursor: not-allowed; background-color: #eeeeee; pointer-events: none;" onkeyup="CalculateTotals();" onclick="CalculateTotals();" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fabricar para Temporada dispos:" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblFTD" runat="server" Text='<%# temporadaDispo(Eval("temporada_tarima","{0:N2}").ToString(),Eval("dispo_tarima","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excedentes inc Pedidos:" ItemStyle-BackColor="#DBB721" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblEIP" runat="server" Text='<%# excedentePedido(Eval("stock","{0:N2}").ToString(),Eval("compra_sugerida","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Excendentes semana anterior:"/>
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




                        <%--
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
                        <asp:TemplateField  HeaderText="Tarimas Extras en_pedido:" ItemStyle-BackColor="#3B6B97"  ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTarExtrasPed" runat="server" TextMode="Number" CssClass="form-control txtTarExtrasPed" style="background-color:#3B6B97; color:whitesmoke;" Min="0" Value="0" Font-Size="Small" onkeyup="CalculateTotals();" onclick="CalculateTotals();" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        --%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

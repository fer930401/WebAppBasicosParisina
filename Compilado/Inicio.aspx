﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppBasicosParisina._Default" EnableEventValidation="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        function CalculateTotals() {
            var gv = document.getElementById("<%= gvBP2.ClientID %>");
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
        document.getElementById("<%= gvBP2.ClientID %>").onclick();
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
            <div style="width: 40%;float: left; position:relative; min-height: 1px; padding-left: 15px;">
                <asp:GridView ID="gvBP" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#042644" HeaderStyle-ForeColor="White"
                    EmptyDataText="No hay resultados para la busqueda" Font-Size="X-Small" OnDataBound="OnDataBound" OnRowCreated = "OnRowCreated" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="telanom" HeaderText="Producto:" HeaderStyle-Height="60px" ItemStyle-Width="150px"/>
                        <asp:BoundField DataField="color_bar" HeaderText="Color Variante:"  HeaderStyle-Height="60px"/>
                        <asp:BoundField DataField="desc_cliente" HeaderText="Descripcion Cliente:" ItemStyle-Height="50px" ItemStyle-Width="200px"  HeaderStyle-Height="60px"/>
                        
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width: 59%;float: left; position:relative; min-height: 1px; padding-right: 15px; overflow-x:scroll;">
                <asp:GridView ID="gvBP2" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#042644" HeaderStyle-ForeColor="White"
                    EmptyDataText="No hay resultados para la busqueda" Font-Size="X-Small" OnDataBound="OnDataBound2" OnRowCreated = "OnRowCreated2" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Inv. intermedio y transito:" ItemStyle-HorizontalAlign = "Right"  ItemStyle-Height="50px" HeaderStyle-Height="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblInvIIT" runat="server" Text='<%# inventarioIntTrans(Eval("rollos_ped").ToString(), Eval("rollos_ped_surtidos").ToString(), Eval("rollos_ped_xsurtir").ToString(), Eval("rollos_ped_xsurtir_old").ToString(), Eval("resurtido_rollos").ToString(), Eval("rollos_tarima").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="rollos_ped_xsurtir" HeaderStyle-Height="60px" HeaderText="Pedidos x Surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_xsurtir_old" HeaderStyle-Height="60px" HeaderText="'Pedidos viejos x surtir:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_ped_surtidos" HeaderStyle-Height="60px" HeaderText="Pedidos Surtidos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:TemplateField HeaderText="Exis Total:" HeaderStyle-Height="60px" ItemStyle-BackColor="#3B6B97" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblExisTotal" runat="server" Text='<%# ExisTotal(Eval("stock").ToString(), Eval("rollos_ped_surtidos").ToString(), Eval("rollos_ped_xsurtir").ToString(), Eval("rollos_ped_xsurtir_old").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Compra Sugerida Tarima:" HeaderStyle-Height="60px" ItemStyle-BackColor="#AF7728" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblCST" runat="server" Text='<%# compraSugerida(Eval("compra_sugerida").ToString(),Eval("rollos_tarima").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sobrante despues compra" HeaderStyle-Height="60px" ItemStyle-BackColor="#8D2F0C" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblSDC" runat="server" Text='<%# restaColumnas() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Faltante vs almacen:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblFA" runat="server" Text='<%# restaExistSobrante() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Faltante vs almacen + pedidos:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right"  HeaderStyle-Wrap="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFAP" runat="server" Text='<%# sumaFaltanteAlmacen(Eval("rollos_ped_xsurtir").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="max_tarima" HeaderStyle-Height="60px" HeaderText="Maximo tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="preorden_tarima" HeaderStyle-Height="60px" HeaderText="Punto de reorden tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="temporada_tarima" HeaderStyle-Height="60px" HeaderText="Temporada tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="dispo_tarima" HeaderStyle-Height="60px" HeaderText="Tarima x dispo:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="resurtido_rollos" HeaderStyle-Height="60px" HeaderText="Fabricar para Resurtido Dispos:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"  HeaderStyle-Wrap="false" />
                        <asp:TemplateField HeaderText="Fabricar para Resurtido Mts:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblFRMTS" runat="server" Text='<%# resurtidoMTS(Eval("rollos_tarima","{0:N2}").ToString(), Eval("rollo_yardas","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fabricar para Resurido tarimas:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right"  HeaderStyle-Wrap="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFRT" runat="server" Text='<%# resurtidoTarima(Eval("resurtido_rollos","{0:N2}").ToString(), Eval("rollos_tarima","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField  HeaderText="Tarimas Extras en_pedido:" HeaderStyle-Height="60px" ItemStyle-BackColor="#3B6B97"  ItemStyle-Width="100px">
                            <ItemTemplate>
                                <div style=<%# validaArttip(Eval("art_tip").ToString()) %>>
                                    <asp:TextBox ID="txtTarExtrasPed" runat="server" TextMode="Number" CssClass="form-control txtTarExtrasPed" style="background-color:#3B6B97; color:whitesmoke;" Min="0" Value="0" Font-Size="Small" onkeyup="CalculateTotals();" onclick="CalculateTotals();"   ></asp:TextBox>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Autorizado x meter_pedidos:" HeaderStyle-Height="60px" ItemStyle-BackColor="#006F07"  ItemStyle-Width="100px">
                            <ItemTemplate>
                                <div style=<%# validaArttip(Eval("art_tip").ToString()) %>>
                                    <asp:TextBox ID="txtNumTarimas" runat="server" TextMode="Number" CssClass="form-control txtNumTarimas" style="background-color:#006F07; color:whitesmoke;" Min="0" Value="0" Font-Size="Small" onkeyup="CalculateTotals();" onclick="CalculateTotals();" ></asp:TextBox>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Demanda Residual:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right" ItemStyle-Width="120px" >
                            <ItemTemplate>
                                <div style=<%# validaArttip(Eval("art_tip").ToString()) %>>
                                    <asp:TextBox ID="txtDemResidual" runat="server" CssClass="form-control txtDemResidual" Font-Size="Small" style="cursor: not-allowed; background-color: #eeeeee; pointer-events: none;" onkeyup="CalculateTotals();" onclick="CalculateTotals();" ></asp:TextBox>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="compra_sugerida" HeaderStyle-Height="60px" HeaderText="Parisina Demanda:" ItemStyle-BackColor="#3B6B97" ItemStyle-ForeColor="WhiteSmoke" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"/>
                        <asp:BoundField DataField="temporada_tarima" HeaderStyle-Height="60px" HeaderText="Fabricar para Temporada tarimas:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right"  HeaderStyle-Wrap="false" />
                        <asp:TemplateField HeaderText="Fabricar para Temporada dispos:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right"  HeaderStyle-Wrap="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblFTD" runat="server" Text='<%# temporadaDispo(Eval("temporada_tarima","{0:N2}").ToString(),Eval("dispo_tarima","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excedentes inc Pedidos:" HeaderStyle-Height="60px" ItemStyle-BackColor="#DBB721" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblEIP" runat="server" Text='<%# excedentePedido(Eval("stock","{0:N2}").ToString(),Eval("compra_sugerida","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excedentes en Bodega:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblExcBod" runat="server" Text='<%# excedenteBodega(Eval("stock").ToString(),Eval("max_parisina").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sku sin existencia:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblSkuSinExis" runat="server" Text='<%# skuSinExist(Eval("stock").ToString(),Eval("contSku_cve").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sku bajo disponible:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblSkuBajoDispo" runat="server" Text='<%# skuBajoExist(Eval("stock").ToString(),Eval("contSku_cve").ToString(), Eval("min_parisina").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="contSku_cve" HeaderStyle-Height="60px" HeaderText="Total Skus:" ItemStyle-HorizontalAlign = "Right" />
                        <asp:BoundField DataField="rollos_tarima" HeaderStyle-Height="60px" HeaderText="Rollos x tarima:" DataFormatString = "{0:N2}" ItemStyle-HorizontalAlign = "Right" />
                        <asp:TemplateField HeaderText="Mts x rollo.:" HeaderStyle-Height="60px" ItemStyle-HorizontalAlign = "Right" >
                            <ItemTemplate>
                                <asp:Label ID="lblMTSR" runat="server" Text='<%# mtsRollos(Eval("rollo_yardas","{0:N2}").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="sku_cve" HeaderStyle-Height="60px" HeaderText="Clave SKU" ItemStyle-HorizontalAlign = "Right" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

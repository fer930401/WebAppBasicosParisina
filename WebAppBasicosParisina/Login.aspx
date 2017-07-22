<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppBasicosParisina.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="container-fluid">
            <div class="inner cover">
                <!--<h1 class="cover-heading">Accede a la aplicacion</h1>-->
                <br />
                <div class="col-md-2">.</div>
                <div class="col-md-4">
                    <img src="Media/logo2.png" class="img-responsive left" width="500" height="500"/>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                        <asp:DropDownList ID="ddlUser_cve" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblPass" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-success" OnClick="btnEntrar_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

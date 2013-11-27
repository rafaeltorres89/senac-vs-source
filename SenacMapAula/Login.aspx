<%@ Page Title="" Language="C#" MasterPageFile="~/SenacMapSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="br.senac.sp.mapaaula.web.Login" %>
<asp:Content ID="Login" ContentPlaceHolderID="content" runat="server">

        <div class="main-MP">
            <div class="col-lg-4"></div>
            <div class="col-lg-4 center-login">
			    <p>Faça seu login para acessar</p>

			    <div class="block-login">
                    <asp:TextBox ID="txtUsuario" runat="server" />
                    <asp:TextBox ID="txtSenha" runat="server" />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

                    <asp:Label ID="lblErro" runat="server" Text=""></asp:Label>
			    </div>
		    </div>
            <div class="col-lg-4"></div>
        </div>

</asp:Content>

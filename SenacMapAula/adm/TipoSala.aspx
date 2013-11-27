<%@ Page Title="Tipo de Sala" Language="C#" MasterPageFile="~/SenacMapSite.Master" AutoEventWireup="true" CodeBehind="TipoSala.aspx.cs" Inherits="br.senac.sp.mapaaula.web.TipoSala" %>

<asp:Content ID="TipoSalaContent" ContentPlaceHolderID="content" runat="server">



    <h2>Tipo de Sala</h2>

    <ul class="nav nav-tabs">
	    <li><a href="#content_tabBusca" data-toggle="tab">Busca</a></li>
	    <li><a href="#content_tabDetalhe" data-toggle="tab">Detalhe</a></li>
    </ul>

    <div class="tab-content">
    <div class="tab-pane" id="tabBusca" runat="server">
        
        <p class="input-append">
            <asp:TextBox ID="txtBusca" runat="server" ToolTip="Utilize esse campo para filtrar a busca." />
            <asp:Button ID="btnBusca" runat="server" Text="Buscar" OnClick="btnBusca_Click" />
        </p>

        <table class="table table-hover">
            <thead>
                <tr>
                    <th>
                        <asp:Label ID="lblColId" runat="server" Text="Cód." /></th>
                    <th>
                        <asp:Label ID="lblColDscTipoSala" runat="server" Text="Tipo de Sala" /></th>
                    <th>
                        <asp:Label ID="lblColDatInativo" runat="server" Text="Inativo" /></th>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ResultListData" runat="server" />

            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblResultListFooter" runat="server" Text="" />
	
                    </td>

                </tr>
            </tfoot>
        </table>
    </div>

    <div class="tab-pane" id="tabDetalhe" runat="server">

        <p>
            <asp:Label ID="lblDetId" runat="server" Text="Código" AssociatedControlID="txtId" />
            <asp:TextBox ID="txtId" runat="server" ReadOnly="True" />
        </p>
        <p>
            <asp:Label ID="lblDetDscTipoSala" runat="server" Text="Descrição" AssociatedControlID="txtDscTipoSala" />
            <asp:TextBox ID="txtDscTipoSala" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetDatInativo" runat="server" Text="Inativo" AssociatedControlID="chkDatInativo" />
            <asp:CheckBox ID="chkDatInativo" runat="server" ToolTip="Marque para inativar esse item." />
        </p>
        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Gravar" OnClick="btnSalvar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnNovo_Click" />
        </p>

        
    </div>
    </div>

				
</asp:Content>

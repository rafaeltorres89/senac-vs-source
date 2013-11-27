<%@ Page Title="Sala" Language="C#" MasterPageFile="~/SenacMapSite.Master" AutoEventWireup="true" CodeBehind="Sala.aspx.cs" Inherits="br.senac.sp.mapaaula.web.Sala" %>

<asp:Content ID="Sala" ContentPlaceHolderID="content" runat="server">

    <h2>Sala</h2>

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
                        <asp:Label ID="lblColDscNome" runat="server" Text="Nome" /></th>
                    <th>
                        <asp:Label ID="lblColNumComputadores" runat="server" Text="Computadores" /></th>
                    <th>
                        <asp:Label ID="lblColNumProjetores" runat="server" Text="Projetores" /></th>
                    <th>
                        <asp:Label ID="lblColNumCadeiras" runat="server" Text="Cadeiras" /></th>
                    <th>
                        <asp:Label ID="lblColDatInativo" runat="server" Text="Inativo" /></th>
                  
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ResultListData" runat="server" />

            </tbody>
            <tfoot>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="lblResultListFooter" runat="server" Text="" />
	
                    </td>

                </tr>
            </tfoot>
        </table>
    </div>

    <div class="tab-pane" id="tabDetalhe" runat="server">

        <p>
            <asp:Label ID="lblDetId" runat="server" Text="Sala" AssociatedControlID="txtId" />
            <asp:TextBox ID="txtId" runat="server" ReadOnly="True" />
        </p>

        <p>
            <asp:Label ID="lblDetTipo" runat="server" Text="Tipo" AssociatedControlID="txtNumCadeiras" />
            <asp:DropDownList ID="cmbTipoSala" runat="server" />
        </p>

        <p>
            <asp:Label ID="lblDetDatInativo" runat="server" Text="Inativo" AssociatedControlID="chkDatInativo" />
            <asp:CheckBox ID="chkDatInativo" runat="server" ToolTip="Marque para inativar esse item." />
        </p>

        <p>
            <asp:Label ID="lblDetNumComputadores" runat="server" Text="Computadores" AssociatedControlID="txtNumComputadores" />
            <asp:TextBox ID="txtNumComputadores" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetNumProjetores" runat="server" Text="Projetores" AssociatedControlID="txtNumProjetores" />
            <asp:TextBox ID="txtNumProjetores" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetNumCadeiras" runat="server" Text="Cadeiras" AssociatedControlID="txtNumCadeiras" />
            <asp:TextBox ID="txtNumCadeiras" runat="server" ToolTip="" MaxLength="60" />
        </p>


        <p>
            <asp:Label ID="lblDetObs" runat="server" Text="OBS" AssociatedControlID="txtObs" />
            <asp:TextBox ID="txtObs" runat="server" ToolTip="" MaxLength="60" Rows="3" TextMode="MultiLine" />
        </p>

        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Gravar" OnClick="btnSalvar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnNovo_Click" />
        </p>

        
    </div>
    </div>

</asp:Content>

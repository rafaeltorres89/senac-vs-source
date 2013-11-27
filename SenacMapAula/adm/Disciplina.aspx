<%@ Page Title="" Language="C#" MasterPageFile="~/SenacMapSite.Master" AutoEventWireup="true" CodeBehind="Disciplina.aspx.cs" Inherits="br.senac.sp.mapaaula.web.adm.Disciplina" %>
<asp:Content ID="Disciplina" ContentPlaceHolderID="content" runat="server">


    <h2>Disciplina</h2>

    <ul class="nav nav-tabs">
	    <li><a href="#content_tabBusca" data-toggle="tab">Busca</a></li>
	    <li><a href="#content_tabDetalhe" data-toggle="tab">Detalhe</a></li>
    </ul>

    <div class="tab-content">
    <div class="tab-pane" id="tabBusca" runat="server">
        
        <p class="input-append">
            <asp:TextBox ID="txtBusca" runat="server" ToolTip="Utilize esse campo para filtrar a busca." />
            <asp:Button ID="btnBusca" runat="server" Text="Buscar"  />
        </p>

        <table class="table table-hover">
            <thead>
                <tr>
                    <th>
                        <asp:Label ID="lblColId" runat="server" Text="Cód." /></th>
                    <th>
                        <asp:Label ID="lblColDscDisciplina" runat="server" Text="Disciplina" /></th>
                    <th>
                        <asp:Label ID="lblColDatInativo" runat="server" Text="Inativo" /></th>
                    <th>
                                
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
            <asp:Label ID="lblDetDscDisciplina" runat="server" Text="Disciplina" AssociatedControlID="txtDscDisciplina" />
            <asp:TextBox ID="txtDscDisciplina" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetDatInativo" runat="server" Text="Email" AssociatedControlID="txtDatInativo" />
            <asp:CheckBox ID="txtDatInativo" runat="server" ToolTip="" />
        </p>

       

        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Gravar"  />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir"  />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  />
        </p>

        
    </div>
    </div>

</asp:Content>

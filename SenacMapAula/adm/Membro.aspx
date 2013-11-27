<%@ Page Title="" Language="C#" MasterPageFile="~/SenacMapSite.Master" AutoEventWireup="true" CodeBehind="Membro.aspx.cs" Inherits="br.senac.sp.mapaaula.web.adm.Membro" %>
<asp:Content ID="Membro" ContentPlaceHolderID="content" runat="server">




    <h2>Membro</h2>

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
                        <asp:Label ID="lblColDscNome" runat="server" Text="Nome" /></th>
                    <th>
                        <asp:Label ID="lblColDscEmail" runat="server" Text="Email" /></th>
                    <th>
                        <asp:Label ID="lblColDscMatricula" runat="server" Text="Matricula" /></th>
                    <th>
                        <asp:Label ID="lblColIndStatus" runat="server" Text="Status" /></th>
                    <th>
                        <asp:Label ID="lblColIndTipo" runat="server" Text="Tipo" /></th>
                    <th>
                        <asp:Label ID="lblColDscSenha" runat="server" Text="Senha" /></th>
                    <th>
                        <asp:Label ID="lblColDatNascimento" runat="server" Text="Data de Nascimento" /></th>
                  
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
            <asp:Label ID="lblDetDscNome" runat="server" Text="Nome" AssociatedControlID="txtDscNome" />
            <asp:TextBox ID="txtDscNome" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetDscEmail" runat="server" Text="Email" AssociatedControlID="txtDscEmail" />
            <asp:TextBox ID="txtDscEmail" runat="server" ToolTip="" />
        </p>

        <p>
            <asp:Label ID="lblDetDscMatricula" runat="server" Text="Matricula" AssociatedControlID="txtDscMatricula" />
            <asp:TextBox ID="txtDscMatricula" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetIndStatus" runat="server" Text="Status" AssociatedControlID="txtIndStatus" />
            <asp:TextBox ID="txtIndStatus" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetIndTipo" runat="server" Text="Tipo" AssociatedControlID="txtIndTipo" />
            <asp:TextBox ID="txtIndTipo" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetDscSenha" runat="server" Text="Senha" AssociatedControlID="txtDscSenha" />
            <asp:TextBox ID="txtDscSenha" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetDatNascimento" runat="server" Text="Data de Nascimento" AssociatedControlID="txtDatNascimento" />
            <asp:TextBox ID="txtDatNascimento" runat="server" ToolTip="" MaxLength="60" />
        </p>


        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Gravar"  />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir"  />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  />
        </p>

        
    </div>
    </div>


</asp:Content>

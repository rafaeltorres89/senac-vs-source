<%@ Page Title="" Language="C#" MasterPageFile="~/SenacMapSite.Master" AutoEventWireup="true" CodeBehind="Curso.aspx.cs" Inherits="br.senac.sp.mapaaula.web.adm.Curso" %>
<asp:Content ID="Curso" ContentPlaceHolderID="content" runat="server">



    <h2>Curso</h2>

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
                        <asp:Label ID="lblColDscCurso" runat="server" Text="Curso" /></th>
                    <th>
                        <asp:Label ID="lblColDscAbreviatura" runat="server" Text="Abreviatura" /></th>
                    <th>
                        <asp:Label ID="lblColDatInicio" runat="server" Text="Data de Inicio" /></th>
                    <th>
                        <asp:Label ID="lblColIdCoordenador" runat="server" Text="Coordenador" /></th>
                    <th>
                        <asp:Label ID="lblColDatInativo" runat="server" Text="Inativo" /></th>
                                      
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ResultListData" runat="server" />

            </tbody>
            <tfoot>
                <tr>
                    <td colspan="6">
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
            <asp:Label ID="lblDetDscCurso" runat="server" Text="Curso" AssociatedControlID="txtDscCurso" />
            <asp:TextBox ID="txtDscCurso" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetDscAbreviatura" runat="server" Text="Abreviatura" AssociatedControlID="txtNumAbreviatura" />
            <asp:TextBox ID="txtNumAbreviatura" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetDatInicio" runat="server" Text="Data de Inicio" AssociatedControlID="txtDatInicio" />
            <asp:TextBox ID="txtDatInicio" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetIdCoordenador" runat="server" Text="Coordenador" AssociatedControlID="txtIdCoordenador" />
            <asp:TextBox ID="txtIdCoordenador" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetDatInativo" runat="server" Text="Inativo" AssociatedControlID="txtDatInativo" />
            <asp:CheckBox ID="txtDatInativo" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Gravar"  />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir"  />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  />
        </p>

        
    </div>
    </div>


</asp:Content>

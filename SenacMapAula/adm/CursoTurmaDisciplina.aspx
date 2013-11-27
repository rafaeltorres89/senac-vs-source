<%@ Page Title="" Language="C#" MasterPageFile="~/SenacMapSite.Master" AutoEventWireup="true" CodeBehind="CursoTurmaDisciplina.aspx.cs" Inherits="br.senac.sp.mapaaula.web.adm.CursoTurmaDisciplina" %>
<asp:Content ID="CursoTurmaDisciplina" ContentPlaceHolderID="content" runat="server">



    <h2>Curso Turma Disciplina</h2>

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
                        <asp:Label ID="lblColIdCurso" runat="server" Text="Curso" /></th>
                    <th>
                        <asp:Label ID="lblColIdDisciplina" runat="server" Text="Disciplina" /></th>
                    <th>
                        <asp:Label ID="lblColIndTurno" runat="server" Text="Turno" /></th>
                     <th>
                        <asp:Label ID="lblColNumPeriodo" runat="server" Text="Periodo" /></th>
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
            <asp:Label ID="lblDetIdCurso" runat="server" Text="Curso" AssociatedControlID="txtIdCurso" />
            <asp:TextBox ID="txtIdCurso" runat="server" ToolTip="" MaxLength="60" />
        </p>
        <p>
            <asp:Label ID="lblDetIdDisciplina" runat="server" Text="Disciplina" AssociatedControlID="txtIdDisciplina" />
            <asp:TextBox ID="txtIdDisciplina" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
             <asp:Label ID="lblDetIndTurno" runat="server" Text="Turno" AssociatedControlID="txtIndTurno" />
            <asp:CheckBox ID="txtIndTurno" runat="server" ToolTip="" /> 
        </p>

        <p>
            <asp:Label ID="lblDetNumPeriodo" runat="server" Text="Disciplina" AssociatedControlID="txtNumPeriodo" />
            <asp:TextBox ID="txtNumPeriodo" runat="server" ToolTip="" MaxLength="60" />
        </p>
       

        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Gravar"  />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir"  />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  />
        </p>

        
    </div>
    </div>


</asp:Content>

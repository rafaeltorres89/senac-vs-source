﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SenacMapSite.Master" AutoEventWireup="true" CodeBehind="AgendaSala.aspx.cs" Inherits="br.senac.sp.mapaaula.web.adm.AgendaSala" %>
<asp:Content ID="AgendaSala" ContentPlaceHolderID="content" runat="server">

     
    <h2>Agenda Sala</h2>

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
                        <asp:Label ID="lblColIdSala" runat="server" Text="Cód." /></th>
                    <th>
                        <asp:Label ID="lblColIndFixo" runat="server" Text="Fixo" /></th>
                    <th>
                        <asp:Label ID="lblColNumDiaSemana" runat="server" Text="Dia da Semana" /></th>
                    <th>
                        <asp:Label ID="lblColDatAgenda" runat="server" Text="Data" /></th>
                    <th>
                        <asp:Label ID="lblColHorAgenda" runat="server" Text="Horário" /></th>
                    <th>
                        <asp:Label ID="lblColIdProfessor" runat="server" Text="Professor" /></th>
                    <th>
                        <asp:Label ID="lblColIdCurso" runat="server" Text="Curso" /></th>
                    <th>
                        <asp:Label ID="lblColIdDisciplina" runat="server" Text="Disciplina" /></th>
                    <th>
                        <asp:Label ID="lblColIndTurno" runat="server" Text="Turno" /></th>
                    <th>
                        <asp:Label ID="lblColNumPeriodo" runat="server" Text="Periodo" /></th>
                                      
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
            <asp:Label ID="lblDetIndFixo" runat="server" Text="Fixo" AssociatedControlID="txtIndFixo" />
            <asp:TextBox ID="txtIndFixo" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetNumDiaSemana" runat="server" Text="Dia da Semana" AssociatedControlID="txtNumDiaSemana" />
            <asp:TextBox ID="txtNumDiaSemana" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetDatAgenda" runat="server" Text="Data" AssociatedControlID="txtDatAgenda" />
            <asp:TextBox ID="txtDatAgenda" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetHorAgenda" runat="server" Text="Horário" AssociatedControlID="txtHorAgenda" />
            <asp:TextBox ID="txtHorAgenda" runat="server" ToolTip="" MaxLength="60" />
        </p>

        <p>
            <asp:Label ID="lblDetIdProfessor" runat="server" Text="Professor" AssociatedControlID="txtIdProfessor" />
            <asp:TextBox ID="txtIdProfessor" runat="server" ToolTip="" MaxLength="60" />
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
            <asp:Label ID="lblDetInd" runat="server" Text="Turno" AssociatedControlID="txtIndTurno" />
            <asp:TextBox ID="txtIndTurno" runat="server" ToolTip="" MaxLength="60" />
        </p>

         <p>
            <asp:Label ID="lblDetNumPeriodo" runat="server" Text="Periodo" AssociatedControlID="txtNumPeriodo" />
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

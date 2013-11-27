using br.senac.sp.mapaaula.ado;
using br.senac.sp.mapaaula.ado.Vo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace br.senac.sp.mapaaula.web
{
    public partial class SenacMapMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList turmas = getTurmaDao().FindAll();
                lsCursos.Items.Clear();
                lsCursos.Items.Add(new ListItem("-- Selecione --"));
                foreach (TurmaVo turma in turmas)
                {
                    lsCursos.Items.Add(new ListItem(turma.Curso.dscCurso + " - " + turma.numPeriodo + "o Semestre", turma.Curso.id.ToString() + "-" + turma.numPeriodo + "-" + turma.indTurno));

                }


                if (Session["user"] != null)
                {
                    lnkLogin.Visible = false;
                    pnlMenu.Visible = true;
                    pnlUsuario.Visible = true;

                    MembroVo membroVo = (MembroVo)Session["user"];
                    lblUsuario.Text = membroVo.dscNome;
                }
                else
                {
                    lnkLogin.Visible = true;
                    pnlMenu.Visible = false;
                    pnlUsuario.Visible = false;

                }
            }
        }


        /*
         * Retorna o Dao utilizado pela Select/Insert/Update 
         */
        protected static TurmaDao getTurmaDao()
        {
            return new TurmaDao(ConfigurationManager.ConnectionStrings["br.senac.sp.mapaaula.dao.config"].ConnectionString);
        }

        protected void lsCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Server.Transfer("~/Agenda.aspx?id=" + lsCursos.SelectedValue);
        }
    }
}
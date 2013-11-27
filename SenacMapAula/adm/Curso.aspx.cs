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

namespace br.senac.sp.mapaaula.web.adm
{
    public partial class Curso : System.Web.UI.Page
    {

        bool activeTabDetail = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CursoDao cursoDao = getCursoDao();
                ArrayList resultadoDaQuery = cursoDao.FindAll();

                this.CarregarListaResultados(resultadoDaQuery);

                if (Request.QueryString["id"] != null)
                {
                    CursoVo cursoVo = (CursoVo) cursoDao.FindByPrimaryKey(new TipoSalaVo(Convert.ToInt32(Request.QueryString["id"])));
                    if (cursoVo != null)
                    {
                        txtId.Text = cursoVo.id.ToString();
                        txtDscCurso.Text = cursoVo.dscCurso;

                        activeTabDetail = true;
                    }
                }
            }

            tabBusca.Attributes["class"] = "tab-pane" + (!activeTabDetail ? " active" : "");
            tabDetalhe.Attributes["class"] = "tab-pane" + (activeTabDetail ? " active" : "");
        }


        protected void CarregarListaResultados(ArrayList resultList)
        {
            ResultListData.Text = "";
            foreach (CursoVo vo in resultList)
            {
                ResultListData.Text += "<tr>";

                ResultListData.Text += "<td>" + vo.id + "</td>";
                ResultListData.Text += "<td><a href=\"?id=" + vo.id + "\">" + vo.dscCurso + "</a></td>";
                ResultListData.Text += "<td>" + vo.dscAbreviatura + "</td>";
                ResultListData.Text += "<td>" + vo.datInicio + "</td>";
                ResultListData.Text += "<td>" + vo.Coordenador.dscNome + "</td>";
                ResultListData.Text += "<td>" + vo.datInativo + "</td>";

                ResultListData.Text += "</tr>";
            }

            lblResultListFooter.Text = resultList.Count.ToString() + " registros.";
        }

        /*
         * Retorna o Dao utilizado pela Select/Insert/Update 
         */
        protected static CursoDao getCursoDao()
        {
            return new CursoDao(ConfigurationManager.ConnectionStrings["br.senac.sp.mapaaula.dao.config"].ConnectionString);
        }
    }
}
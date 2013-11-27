using br.senac.sp.mapaaula.ado;
using br.senac.sp.mapaaula.ado.Vo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace br.senac.sp.mapaaula.web
{
    public partial class TipoSala : System.Web.UI.Page
    {
        bool activeTabDetail = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            activeTabDetail = false;

            if (!IsPostBack)
            {

                TipoSalaDao tipoSalaDao = getTipoSalaDao();
                ArrayList resultadoDaQuery = tipoSalaDao.FindAll();
                this.CarregarListaResultados(resultadoDaQuery);

                if (Request.QueryString["id"] != null)
                {
                    TipoSalaVo tipoSalaVo = (TipoSalaVo)tipoSalaDao.FindByPrimaryKey(new TipoSalaVo(Convert.ToInt32(Request.QueryString["id"])));
                    if (tipoSalaVo != null)
                    {
                        txtId.Text = tipoSalaVo.id.ToString();
                        txtDscTipoSala.Text = tipoSalaVo.dscTipoSala;
                        chkDatInativo.Checked = tipoSalaVo.inativo;

                        activeTabDetail = true;
                    }
                }
            }
            
            tabBusca.Attributes["class"] = "tab-pane" + (!activeTabDetail ? " active" : "");
            tabDetalhe.Attributes["class"] = "tab-pane" + (activeTabDetail ? " active" : "");
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            TipoSalaVo tipoSalaVo = new TipoSalaVo();
            tipoSalaVo.dscTipoSala = txtBusca.Text;

            ArrayList resultadoDaQuery = getTipoSalaDao().FindByCriteria(tipoSalaVo);
            this.CarregarListaResultados(resultadoDaQuery);
        }


        /*
         * Retorna o Dao utilizado pela Select/Insert/Update 
         */
        protected static TipoSalaDao getTipoSalaDao()
        {
            return new TipoSalaDao(ConfigurationManager.ConnectionStrings["br.senac.sp.mapaaula.dao.config"].ConnectionString);
        }

        protected void CarregarListaResultados(ArrayList resultList) {
            ResultListData.Text = "";
            foreach (TipoSalaVo vo in resultList)
            {
                ResultListData.Text += "<tr>";

                ResultListData.Text += "<td>" + vo.id + "</td>";
                ResultListData.Text += "<td><a href=\"?id=" + vo.id + "\">" + vo.dscTipoSala + "</a></td>";
                ResultListData.Text += "<td>" + vo.datInativo + "</td>";

                ResultListData.Text += "</tr>";
            }

            lblResultListFooter.Text = resultList.Count.ToString() + " registros.";
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            getTipoSalaDao().Delete(new TipoSalaVo(Convert.ToInt32(txtId.Text)));

            this.Cancelar();

        }

        protected void Cancelar()
        {
            string _CleanUrl = Request.Url.AbsoluteUri.Split('?')[0];
            Response.Redirect(_CleanUrl);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TipoSalaVo tipoSalaVo = new TipoSalaVo();
            tipoSalaVo.id = Convert.ToInt32( txtId.Text );
            tipoSalaVo.dscTipoSala = txtDscTipoSala.Text;
            tipoSalaVo.inativo = chkDatInativo.Checked;

            if ("".Equals(tipoSalaVo.id))
            {
                getTipoSalaDao().Create(tipoSalaVo);
            }
            else
            {
                getTipoSalaDao().Update(tipoSalaVo);
            }

            this.Cancelar();

        }


    }
}
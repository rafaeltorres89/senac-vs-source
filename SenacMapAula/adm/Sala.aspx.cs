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
    public partial class Sala : System.Web.UI.Page
    {
        bool activeTabDetail = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            activeTabDetail = false;

            if (!IsPostBack)
            {
                ArrayList tiposSala = getTipoSalaDao().FindAll();
                cmbTipoSala.Items.Add(new ListItem("-- Selecione --"));
                foreach (TipoSalaVo tipoSala in tiposSala)
                {
                    cmbTipoSala.Items.Add(new ListItem(
                        tipoSala.dscTipoSala,
                        tipoSala.id.ToString()
                    ));
                }

                SalaDao salaDao = getSalaDao();
                ArrayList resultadoDaQuery = salaDao.FindAll();
                this.CarregarListaResultados(resultadoDaQuery);

                if (Request.QueryString["id"] != null)
                {
                    SalaVo salaVo = (SalaVo)salaDao.FindByPrimaryKey(new SalaVo(Request.QueryString["id"]));
                    if (salaVo != null)
                    {
                        txtId.Text = salaVo.codSala;
                        chkDatInativo.Checked = salaVo.isInativo();
                        txtNumComputadores.Text = salaVo.numComputadores.ToString();
                        txtNumProjetores.Text = salaVo.numProjetores.ToString();
                        txtNumCadeiras.Text = salaVo.numCadeiras.ToString();
                        txtObs.Text = salaVo.dscObs;
                        cmbTipoSala.SelectedValue = salaVo.idTipoSala.ToString();

                        activeTabDetail = true;
                    }
                }
            }

            tabBusca.Attributes["class"] = "tab-pane" + (!activeTabDetail ? " active" : "");
            tabDetalhe.Attributes["class"] = "tab-pane" + (activeTabDetail ? " active" : "");
        }

        private SalaDao getSalaDao()
        {
            return new SalaDao(ConfigurationManager.ConnectionStrings["br.senac.sp.mapaaula.dao.config"].ConnectionString);
        }

        private TipoSalaDao getTipoSalaDao()
        {
            return new TipoSalaDao(ConfigurationManager.ConnectionStrings["br.senac.sp.mapaaula.dao.config"].ConnectionString);
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            SalaVo tipoSalaVo = new SalaVo();
            tipoSalaVo.codSala = txtBusca.Text;

            ArrayList resultadoDaQuery = getSalaDao().FindByCriteria(tipoSalaVo);
            this.CarregarListaResultados(resultadoDaQuery);
        }

        protected void CarregarListaResultados(ArrayList resultList)
        {
            ResultListData.Text = "";
            foreach (SalaVo vo in resultList)
            {
                ResultListData.Text += "<tr>";

                ResultListData.Text += "<td><a href=\"?id=" + vo.codSala + "\">" + vo.codSala  + "</a></td>";
                ResultListData.Text += "<td>" + vo.numComputadores + "</td>";
                ResultListData.Text += "<td>" + vo.numProjetores + "</td>";
                ResultListData.Text += "<td>" + vo.numCadeiras + "</td>";
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
            getSalaDao().Delete(new SalaVo(txtId.Text));

            this.Cancelar();

        }

        protected void Cancelar()
        {
            string _CleanUrl = Request.Url.AbsoluteUri.Split('?')[0];
            Response.Redirect(_CleanUrl);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            SalaVo salaVo = new SalaVo();
            //tipoSalaVo.id = txtId.Text;
            //tipoSalaVo.dscTipoSala = txtDscTipoSala.Text;
            //tipoSalaVo.inativo = chkDatInativo.Checked;

            if ("".Equals(salaVo.codSala))
            {
                getSalaDao().Create(salaVo);
            }
            else
            {
                getSalaDao().Update(salaVo);
            }

            this.Cancelar();

        }



        public BaseVo salaVo { get; set; }
    }
}


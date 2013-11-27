using br.senac.sp.mapaaula.ado;
using br.senac.sp.mapaaula.ado.Vo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace br.senac.sp.mapaaula.web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUsuario.Text = "admin@senacmapaula.com.br";
                txtSenha.Text = "admin";

                Session["user"] = null;
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MembroVo membroVo = getMembroDao().ValidatePassword(txtUsuario.Text, txtSenha.Text);

            if (membroVo != null)
            {
                Session["user"] = membroVo;
                Server.Transfer("~/Default.aspx");
            }
            else
            {
                lblErro.Text = "Usuário ou  Senha inválidos.";
            }
        }


        /*
         * Retorna o Dao utilizado pela Select/Insert/Update 
         */
        protected static MembroDao getMembroDao()
        {
            return new MembroDao(ConfigurationManager.ConnectionStrings["br.senac.sp.mapaaula.dao.config"].ConnectionString);
        }

    }
}
using Ecourbis.FormularioNFRemRet.Business;
using Ecourbis.FormularioNFRemRet.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecourbis.FormularioNFRemRet.UI.Web.View
{
    public partial class baixarControle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int numControl = Convert.ToInt32(Request.QueryString["controle"].ToString());
                controle.Text = numControl.ToString("00000000");
            }
        }

        protected void btnBaixar_Click(object sender, EventArgs e)
        {
            HeaderBUS negocio = new HeaderBUS();
            HeaderForMOD header = new HeaderForMOD();

            if (baixar.Checked)
            {
                try
                {
                    header = negocio.visualizaForm(controle.Text);

                    negocio.baixarControle(header);

                    lblMensagem.Text = "Baixa realizada com sucesso";
                    lblMensagem.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = "Não foi possível baixar este controle:" + ex.Message;
                    lblMensagem.ForeColor = Color.Red;
                }
            }

        }
    }
}
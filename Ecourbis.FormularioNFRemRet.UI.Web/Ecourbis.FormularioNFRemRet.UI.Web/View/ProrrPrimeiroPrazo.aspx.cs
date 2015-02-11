using Ecourbis.FormularioNFRemRet.Business;
using Ecourbis.FormularioNFRemRet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

namespace Ecourbis.FormularioNFRemRet.UI.Web.View
{
    public partial class ProrrPrimeiroPrazo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string item = Request.QueryString["recno"].ToString();

                carregaItem(item);
            }
        }

        private void carregaItem(string recno)
        {
            ProdutoBUS prodMod = new ProdutoBUS();

            ProdutMOD produto = prodMod.GetItemProd(recno);

            Utilitario util = new Utilitario();

            if (produto != null)
            {
                lblItem.Text = produto.Item.ToString("000");
                lblCod.Text = produto.Codigo.Trim();
                lblDesc.Text = produto.Descricao.Trim();
                lblUniMed.Text = produto.UnidMedida;
                lblQtd.Text = produto.Quantidade;
                lblControl.Text = produto.Controle;
                txtPrazoRe.Value = produto.prazoRetorno;

                hdfData.Value = produto.prazoRetorno;
                hdfRecno.Value = produto.recno.ToString();
            }
        }

        protected void ibtnAlterar_Click(object sender, ImageClickEventArgs e)
        {
            Utilitario util = new Utilitario();
            ProdutoBUS prodMod = new ProdutoBUS();
            ProdutMOD p = new ProdutMOD();

            HeaderBUS negocioHd = new HeaderBUS();

            HeaderForMOD header = new HeaderForMOD();

            header = negocioHd.visualizaForm(lblControl.Text);

            //bool lAlterar = util.ComparaData(hdfData.Value, txtPrazoRe.Value);
            bool lAlterar = util.ComparaData(DateTime.Now.Date, txtPrazoRe.Value);

            if (lAlterar)
            {
                try
                {
                    p.recno = Convert.ToInt32(hdfRecno.Value);
                    p.Item = Convert.ToInt32(lblItem.Text);
                    p.Codigo = lblCod.Text;
                    p.Descricao = lblDesc.Text;
                    p.UnidMedida = lblUniMed.Text;
                    p.Quantidade = lblQtd.Text;
                    p.Controle = lblControl.Text;
                    p.prazoRetorno = txtPrazoRe.Value;

                    prodMod.ProrrogPUm(p);

                    lblMensagem.Text = "Prazo prorrogado com sucesso!";
                    lblMensagem.ForeColor = Color.Green;
                }
                catch (Exception)
                {
                    lblMensagem.Text = "Não foi possivel realizar esta alteração!";
                    lblMensagem.ForeColor = Color.Red;
                }

                
            }
            else
            {
                lblMensagem.Text = "A data informada deve ser maior que a data inicial do prazo!";
                lblMensagem.ForeColor = Color.Red;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ecourbis.FormularioNFRemRet.Business;
using Ecourbis.FormularioNFRemRet.Model;

namespace Ecourbis.FormularioNFRemRet.UI.Web.View
{
    public partial class VisualizarForme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((Request.QueryString["controle"])))
            {
                if (!IsPostBack)
                {
                    string numControl = Request.QueryString["controle"].ToString();

                    carregaDadosTela(numControl);
                }
            }
            else
            {
                Request.QueryString["controle"] = null;
            }

        }

        private void carregaDadosTela(string numControl)
        {
            HeaderBUS negocioHd = new HeaderBUS();
            ProdutoBUS negocioPd = new ProdutoBUS();
            HeaderForMOD header = new HeaderForMOD();
            Utilitario util = new Utilitario();

            List<ProdutMOD> list = new List<ProdutMOD>();

            header = negocioHd.visualizaForm(numControl);
            list = negocioPd.listItens(numControl);

            if (header != null)
            {
                lblDataSolict.Text = header.dtSolicit.ToString("dd/MM/yyyy");
                lblDataPrazo.Text = header.prazo.ToString("dd/MM/yyyy");
                lblControle.Text = header.numControl.ToString("00000000");
                lblNomeUser.Text = header.numUser;
                lblNomDep.Text = header.depUser;
                lblNumFuncao.Text = header.funUSer;
                lblEmailUser.Text = header.emalUser;
                //lblGestor.Text = header.codGestor;
                lblTextRetira.Text = util.localRet(header.retirada);
                lbltxtUnidade.Text = util.unidadeResp(header.unidade);
                lbltxtTipo.Text = util.nfTipo(header.tipo);
                lbltxtJstif.Text = header.justificativa;
                lbltxtFornece.Text = header.codCliFor + " - " + header.nomeCliFor;
                lbltxtLoja.Text = header.loja;
                lbltxtCodForn.Text = header.codCliFor;
                lbltxtRsocial.Text = header.nomeCliFor;
                lbbtxtCnpj.Text = util.masckDados(header.cnpj, 2);
                lbltxtEndereco.Text = header.endereco;
                lbltxtTelefone.Text = header.telefone;
                lbltxtEmail.Text = header.email;


                if (header.tipo.Equals("1"))
                {
                    nfOri.Visible = false;
                    terceiro.Visible = false;
                    retorno.Visible = false;
                    tpNf.Text = "Tipo de Remessa";


                    if (header.nfRem.Equals("1"))
                    {
                        rdbConsertoRem.Checked = true;
                    }
                    else if (header.nfRem.Equals("2"))
                    {

                        rdbBenefRem.Checked = true;
                    }
                    else
                    {
                        rdbOutRem.Checked = true;
                    }
                }
                else if (header.tipo.Equals("2"))
                {
                    nfOri.Visible = false;
                    remessa.Visible = false;
                    retorno.Visible = false;
                    tpNf.Text = "Tipo Bens em pode de Terceiros";

                    if (header.nfTerc.Equals("1"))
                    {
                        rddLocTer.Checked = true;
                    }
                    else if (header.nfTerc.Equals("2"))
                    {
                        rdbEmpTer.Checked = true;
                    }
                    else
                    {
                        rdbOutTer.Checked = true;
                    }
                }
                else
                {
                    lbltxtnfOri.Text = header.nfOrigem;
                    nfOri.Visible = true;
                    retorno.Visible = true;
                    tpNf.Text = "Tipo Retorno";

                    remessa.Visible = false;
                    terceiro.Visible = false;

                    if (header.nfRet.Equals("1"))
                    {
                        rdbLocRet.Checked = true;
                    }
                    else if (header.nfRet.Equals("2"))
                    {
                        rdbEmpRet.Checked = true;
                    }
                    else
                    {
                        rdbOutRet.Checked = true;
                    }
                }

                ItensGridView.DataSource = list;
                ItensGridView.DataBind();

            }
            else
            {
                Response.Redirect("../Erros/ErroGenerico.aspx");
            }
        }

        protected void btnNovoForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("../View/Formulario.aspx");
        }

        protected void btnReEnvia_Click(object sender, EventArgs e)
        {
            HeaderBUS negocioHd = new HeaderBUS();
            ProdutoBUS negocioPd = new ProdutoBUS();
            HeaderForMOD header = new HeaderForMOD();
            Utilitario util = new Utilitario();
            EnvioEmail envia = new EnvioEmail();

            List<ProdutMOD> list = new List<ProdutMOD>();

            //objetos utilizados para carregar javascript na tela
            //------------------------------\\
            String csname1 = "PopupScript";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            //------------------------------\\

            string numControl = lblControle.Text;

            header = negocioHd.visualizaForm(numControl);
            list = negocioPd.listItens(numControl);

            try
            {
                envia.carregaHtml(header, list);

                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext1 = "alert('Email enviado com sucesso!');";

                    cs.RegisterStartupScript(cstype, csname1, cstext1, true);
                }
            }
            catch (Exception ex)
            {
                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext1 = "alert('Ocorreu um erro no envio do e-mail. \nErro (" + ex.Message + ")!');";

                    cs.RegisterStartupScript(cstype, csname1, cstext1, true);
                }
            }
        }
    }
}
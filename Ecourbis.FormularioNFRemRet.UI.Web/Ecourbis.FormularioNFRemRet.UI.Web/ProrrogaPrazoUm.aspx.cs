using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ecourbis.FormularioNFRemRet.Business;
using Ecourbis.FormularioNFRemRet.Model;

namespace Ecourbis.FormularioNFRemRet.UI.Web
{
    public partial class ProrrogaPrazoUm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string numControl = Request.QueryString["controle"].ToString();

                ProdutoBUS negocioPd = new ProdutoBUS();
                List<ProdutMOD> list = new List<ProdutMOD>();

                list = negocioPd.listItens(numControl);
                carregaItens(list);

                carregaDadosTela(numControl);
            }

        }

        private void carregaDadosTela(string numControl)
        {
            HeaderBUS negocioHd = new HeaderBUS();

            HeaderForMOD header = new HeaderForMOD();
            Utilitario util = new Utilitario();

            header = negocioHd.visualizaForm(numControl);


            if (header != null)
            {
                lblDataSolict.Text = header.dtSolicit.ToString("dd/MM/yyyy");
                lblDataPrazo.Text = header.prazo.ToString("dd/MM/yyyy");
                lblControle.Text = header.numControl.ToString("00000000");
                lblNomeUser.Text = header.numUser;
                lblNomDep.Text = header.depUser;
                lblNumFuncao.Text = header.funUSer;
                lblEmailUser.Text = header.emalUser;
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
                        rdbConcertoRem.Checked = true;
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

            }
            else
            {
                Response.Redirect("../Erros/ErroGenerico.aspx");
            }
        }

        private void carregaItens(List<ProdutMOD> list)
        {
            tbPrincipal.InnerHtml = "\n<table id='example' class='table table-responsive display'>";
            tbPrincipal.InnerHtml += "   <thead>\n";
            tbPrincipal.InnerHtml += "       <tr'>";
            tbPrincipal.InnerHtml += "          <th class='tableInith'>Item</th>\n";
            tbPrincipal.InnerHtml += "          <th class='tableInith'>Código</th>\n";
            tbPrincipal.InnerHtml += "          <th class='tableInith'>Descrição</th>\n";
            tbPrincipal.InnerHtml += "          <th class='tableInith'>Und. Méd.</th>\n";
            tbPrincipal.InnerHtml += "          <th class='tableInith'>Quant.</th>\n";
            tbPrincipal.InnerHtml += "          <th class='tableInith'>Controle</th>\n";
            tbPrincipal.InnerHtml += "          <th class='tableInith'>Prazo Ret.</th>\n";
            tbPrincipal.InnerHtml += "          <th class='tableInith'>Prorroga</th>\n";
            tbPrincipal.InnerHtml += "      </tr>";
            tbPrincipal.InnerHtml += "   </thead>\n";

            foreach (var item in list)
            {
                tbPrincipal.InnerHtml += "  <tr>\n";
                tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.Item + "</td>\n";
                tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.Codigo + "</td>\n";
                tbPrincipal.InnerHtml += "      <td class='tableInitd text-left'>" + item.Descricao + "</td>\n";
                tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.UnidMedida + "</td>\n";
                tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.Quantidade + "</td>\n";
                tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.Controle + "</td>\n";
                tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.prazoRetorno + "</td>\n";

                if (item.log == 0)
                {
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'><a href='../View/ProrrPrimeiroPrazo.aspx?recno=" + item.recno + "' class='edit' data-fancybox-type='iframe'>Prorroga</a></td>\n";
                }
                else
                {
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'><a href='../View/msgPrazoProrrogado.aspx' class='edit prazoumProrrog' data-fancybox-type='iframe'>Prorroga</a></td>\n";                    
                }

                

                tbPrincipal.InnerHtml += "  </tr>\n";
            }

            tbPrincipal.InnerHtml += "   </table>\n";
        }

    }
}
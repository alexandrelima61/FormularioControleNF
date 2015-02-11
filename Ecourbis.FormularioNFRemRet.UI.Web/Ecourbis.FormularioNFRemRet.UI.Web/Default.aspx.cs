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
    public partial class Default : System.Web.UI.Page
    {
        ProdutoBUS prod;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaTable();
            }
        }

        public void carregaTable()
        {
            Utilitario util = new Utilitario();
            HeaderBUS negocio = new HeaderBUS();
            string cUser = util.GetUser();
            string cDepUser = util.GetDepartamento(cUser);

            List<HeaderForMOD> header = new List<HeaderForMOD>();



            if ((cDepUser.Contains("Contabilidade")) || (cDepUser.Contains("Almoxarifado")) || (cDepUser.Contains("Tecnologia da Informação")))
            {
                header = negocio.ListaControle();

                telaUSerAlmoxarifContabil(header);
            }
            else
            {
                header = negocio.ListaControleDep(cDepUser);

                telaUSerComun(header);
            }

        }
        //Funcionários do Almoxarifado e da Contabilidade podeream acessar todos os controles
        private void telaUSerAlmoxarifContabil(List<HeaderForMOD> header)
        {
            prod = new ProdutoBUS();
            int prazo = 0;

            if (header.Count > 0)
            {
                tbPrincipal.InnerHtml = "\n<table id='example' class='table table-responsive display'>";
                tbPrincipal.InnerHtml += "   <thead>\n";
                tbPrincipal.InnerHtml += "       <tr'>";
                tbPrincipal.InnerHtml += "          <th class='tableInith'></th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Controle</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Solicitante</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Dt Solicitação</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Fornecedor</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Prazo Retorno</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>1ª Prorr. de Prazo</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>2ª Prorr. de Prazo</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Visualizar</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Baixar</th>\n";
                tbPrincipal.InnerHtml += "      </tr>";
                tbPrincipal.InnerHtml += "   </thead>\n";

                foreach (var item in header)
                {

                    prazo = prod.CaontItemProrrog(item.numControl.ToString("00000000"));

                    tbPrincipal.InnerHtml += "  <tr>\n";
                    tbPrincipal.InnerHtml += item.baixa.Trim().Equals("T") ? "<td class='tableInitd'><img src='Imagens/Status_Missing.png' title='Controle lançado no Protheus' style='width:15px;height:15px;'/></td>\n" : "<td class='tableInitd'><img src='Imagens/Status_OK.png' title='Controle ainda não lançado no Protheus' style='width:15px;height:15px;'/></td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.numControl.ToString("00000000") + "</td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.numUser + "</td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.dtSolicit.ToString("dd/MM/yyyy") + "</td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.codCliFor + "-" + item.nomeCliFor + "</td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.prazo.ToString("dd/MM/yyyy") + "</td>\n";

                    if (prazo == 1)
                    {
                        tbPrincipal.InnerHtml += "      <td class='tableInitd'> <a href='ProrrogaPrazoUm.aspx?controle=" + item.numControl.ToString() + "' class='edit'>1ª prorrogação</a> </td>\n";
                        tbPrincipal.InnerHtml += "      <td class='tableInitd'> <a href='../View/msgPrazoProrrogado.aspx' class='edit prazoumProrrog' data-fancybox-type='iframe'>2ª prorrogação</a> </td>\n";
                    }
                    else
                    {
                        tbPrincipal.InnerHtml += "      <td class='tableInitd'><a href='../View/msgPrazoProrrogado.aspx' class='edit prazoumProrrog' data-fancybox-type='iframe'>1ª prorrogação</a></td>\n";
                        tbPrincipal.InnerHtml += "      <td class='tableInitd'> <a href='../View/ProrrPrimeiroPrazo.aspx' class='edit' data-fancybox-type='iframe'>2ª prorrogação</a> </td>\n";
                    }

                    tbPrincipal.InnerHtml += "      <td class='tableInitd'> <a href='../View/VisualizarForme.aspx?controle=" + item.numControl.ToString() + "' >Visualizar</a> </td>\n";
                    tbPrincipal.InnerHtml += item.baixa.Trim().Equals("F") ? "     <td class='tableInitd text-center'> <a href='../View/baixarControle.aspx?controle=" + item.numControl.ToString() + "' class='edit' data-fancybox-type='iframe'><img src='Imagens/baixar.png' alt='Baixar controler' style='width:15px;height:15px;'/></a></td>\n" : "<td class='tableInitd text-center'><img src='Imagens/baixado.png' alt='Baixar controler' style='width:15px;height:15px;'/></td>\n";

                    tbPrincipal.InnerHtml += "  </tr>\n";
                }
                tbPrincipal.InnerHtml += "</table>\n";
            }
            else
            {
                tbPrincipal.InnerHtml = "<h1 class='text-center'>Não há formulário cadastros para este <b>DEPARTAMENTO</b>.</h1>";
            }
        }
        //Funcionários dos demais departamentos, só poderam acessar os controles 
        //no qual pertença ao seus respectivos departamentos
        private void telaUSerComun(List<HeaderForMOD> header)
        {
            prod = new ProdutoBUS();
            int prazo = 0;

            if (header.Count > 0)
            {
                tbPrincipal.InnerHtml = "\n<table id='example' class='table table-responsive display'>";
                tbPrincipal.InnerHtml += "   <thead>\n";
                tbPrincipal.InnerHtml += "       <tr'>";
                tbPrincipal.InnerHtml += "          <th class='tableInith'></th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Controle</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Solicitante</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Dt Solicitação</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Fornecedor</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Prazo Retorno</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>1ª Prorr. de Prazo</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>2ª Prorr. de Prazo</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Visualizar</th>\n";
                tbPrincipal.InnerHtml += "          <th class='tableInith'>Baixar</th>\n";
                tbPrincipal.InnerHtml += "      </tr>";
                tbPrincipal.InnerHtml += "   </thead>\n";

                foreach (var item in header)
                {

                    prazo = prod.CaontItemProrrog(item.numControl.ToString("00000000"));

                    tbPrincipal.InnerHtml += "  <tr>\n";
                    tbPrincipal.InnerHtml += item.baixa.Trim().Equals("T") ? "<td class='tableInitd'><img src='Imagens/Status_Missing.png' alt='Controle Lançado no Protheus' style='width:15px;height:15px;'/></td>\n" : "<td class='tableInitd'><img src='Imagens/Status_OK.png' alt='Controle Lançado no Protheus' style='width:15px;height:15px;'/></td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.numControl.ToString("00000000") + "</td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.numUser + "</td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.dtSolicit.ToString("dd/MM/yyyy") + "</td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.codCliFor + "-" + item.nomeCliFor + "</td>\n";
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'>" + item.prazo.ToString("dd/MM/yyyy") + "</td>\n";

                    if (prazo == 1)
                    {
                        tbPrincipal.InnerHtml += "      <td class='tableInitd'> <a href='ProrrogaPrazoUm.aspx?controle=" + item.numControl.ToString() + "' class='edit'>1ª prorrogação</a> </td>\n";
                        tbPrincipal.InnerHtml += "      <td class='tableInitd'> <a href='../View/msgPrazoProrrogado.aspx' class='edit prazoumProrrog' data-fancybox-type='iframe'>2ª prorrogação</a> </td>\n";
                    }
                    else
                    {
                        tbPrincipal.InnerHtml += "      <td class='tableInitd'><a href='../View/msgPrazoProrrogado.aspx' class='edit prazoumProrrog' data-fancybox-type='iframe'>1ª prorrogação</a></td>\n";
                        tbPrincipal.InnerHtml += "      <td class='tableInitd'> <a href='../View/ProrrPrimeiroPrazo.aspx' class='edit' data-fancybox-type='iframe'>2ª prorrogação</a> </td>\n";
                    }
                    
                    tbPrincipal.InnerHtml += "      <td class='tableInitd'> <a href='../View/VisualizarForme.aspx?controle=" + item.numControl.ToString() + "' >Visualizar</a> </td>\n";
                    tbPrincipal.InnerHtml += item.baixa.Trim().Equals("F") ? "     <td class='tableInitd text-center'> <a href='../View/baixarControle.aspx?controle=" + item.numControl.ToString() + "' class='edit' data-fancybox-type='iframe'><img src='Imagens/baixar.png' alt='Baixar controler' style='width:15px;height:15px;'/></a></td>\n" : "<td class='tableInitd text-center'><img src='Imagens/baixado.png' alt='Baixar controler' style='width:15px;height:15px;'/></td>\n";

                    tbPrincipal.InnerHtml += "  </tr>\n";
                }
                tbPrincipal.InnerHtml += "</table>\n";
            }
            else
            {
                tbPrincipal.InnerHtml = "<h1 class='text-center'>Não há formulário cadastros para este <b>DEPARTAMENTO</b>.</h1>";
            }
        }
    }
}
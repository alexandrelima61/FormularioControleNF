using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Services;
using System.Web.Services;
using System.Windows.Forms;

using Ecourbis.FormularioNFRemRet.Business;
using Ecourbis.FormularioNFRemRet.Model;
using System.Data;
using System.Collections;
using System.Drawing;

namespace Ecourbis.FormularioNFRemRet.UI.Web.View
{
    public partial class Formulario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Utilitario util = new Utilitario();
                FormBUS negocio = new FormBUS();
                GestorBuss gestorBuss = new GestorBuss();

                string user = util.GetUser();
                int matUserLogado = gestorBuss.GetMatUserLogado(user);

                lblGestor.Text = gestorBuss.GetCodGestor(matUserLogado);
                lblData.Text = DateTime.Now.ToString("dd/MM/yyyyy");
                lblNomeUser.Text = util.GetNameCompletAD();
                lblNomDep.Text = util.GetDepartamento(user);
                lblEmailUser.Text = util.GetEmail(user);

                lblNumFuncao.Text = negocio.GetFuncaoFunc(user);

                terceiro.Visible = false;
                retorno.Visible = false;
                remessa.Visible = false;
                nfOri.Visible = false;

                btnNovoForm.Visible = false;
                btnEnvia.Visible = false;

                GetNumFormulario();

                preencheGrid();
            }
        }

        private void preencheGrid()
        {
            ItensGridView.DataSource = iTens;
            ItensGridView.DataBind();

        }

        private void GetNumFormulario()
        {
            FormBUS negocio = new FormBUS();

            //lblControle.Text = negocio.GetNumForm();
            lblControle.Text = "00000001";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetUnidadeMed(string pre)
        {
            UnidMedBUS negocio = new UnidMedBUS();
            List<string> liUnidMed = negocio.GetUnidMed(pre);

            return liUnidMed;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetDescProd(string pre)
        {
            ProdutoBUS negocio = new ProdutoBUS();
            List<string> allDescProd = negocio.GetDescProd(pre);

            return allDescProd;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetCodProd(string pre)
        {
            ProdutoBUS negocio = new ProdutoBUS();

            List<string> allProdutCod = negocio.GetProduto(pre);

            return allProdutCod;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetFornecName(string pre)
        {
            FoneceBuss negocio = new FoneceBuss();

            List<string> allCompanyName = negocio.GetFornece(pre);

            return allCompanyName;
        }

        protected void btnIncItem_Click(object sender, EventArgs e)
        {
            if (txtData.Value != String.Empty)
            {
                if (Convert.ToDateTime(txtData.Value) <= DateTime.Now)
                {
                    lblMensagem.Text = "A data do prazo de retorno deve ser maior que a data de hoje!";
                    lblMensagem.ForeColor = Color.Red;
                }
                else
                {
                    if (txtQtd.Text != String.Empty)
                    {

                        ProdutMOD pdMOD = new ProdutMOD();
                        ArrayList lista = new ArrayList();

                        //pdMOD.Item = 1;
                        pdMOD.Codigo = txtcodP.Text;
                        pdMOD.Descricao = txtDescP.Text;
                        pdMOD.Quantidade = txtQtd.Text;
                        pdMOD.Controle = lblControle.Text;
                        pdMOD.prazoRetorno = txtData.Value;
                        pdMOD.UnidMedida = txtUniMed.Text.ToUpper();

                        lista.Add(pdMOD);

                        for (int i = 0; i < (iTens.Count - 1); i++)
                        {
                            ProdutMOD pMod = (ProdutMOD)iTens[i];
                            if (pdMOD.Codigo.Equals(pMod.Codigo))
                            {
                                lista.Clear();
                                break;
                            }
                        }

                        if (lista.Count != 0)
                        {
                            iTens.Add(pdMOD);
                            preencheGrid();
                        }
                        else
                        {
                            String _message = "window.alerte('Este produto já foi adicionado');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", _message, true);
                        }

                        txtcodP.Text = String.Empty;
                        txtDescP.Text = String.Empty;
                        txtQtd.Text = String.Empty;
                        txtUniMed.Text = String.Empty;
                        txtcodP.Focus();
                    }
                    else
                    {
                        String _message = "window.alerte('Por favor, preencha o campo quantidade!');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", _message, true);
                    }
                }
            }
            else
            {
                lblMensagem.Text = "Pro favor, preencga o campo prazo de retorno!";
                lblMensagem.ForeColor = Color.Red;
            }

        }

        protected void inputName_TextChanged(object sender, EventArgs e)
        {
            FoneceBuss negocio = new FoneceBuss();
            Utilitario ultil = new Utilitario();
            FornecMOD forne = new FornecMOD();

            try
            {
                forne = negocio.GetDadosFornece(txtFornec.Text);

                txtRsocial.Text = forne.nome;
                txtCodForn.Text = forne.Cod;
                txtEndereco.Text = forne.endereco;
                txtEmail.Text = forne.email;
                txtLoja.Text = forne.loja;

                txtTelefone.Value = ultil.masckDados(forne.tel, 1);
                txtCnpj.Value = ultil.masckDados(forne.cgc, 2);

                txtJstif.Focus();
            }
            catch (Exception)
            {
                txtFornec.Text = "Fornecedor inválido!";
                txtFornec.Focus();
            }

        }

        protected void txtcodP_TextChanged(object sender, EventArgs e)
        {
            string descricao;
            if (txtcodP.Text != String.Empty)
            {
                if (txtcodP.Text.Length > 12)
                {
                    txtcodP.Text.Replace("-", "");
                    descricao = txtcodP.Text.Substring(13, txtcodP.Text.Length - 13);
                    txtcodP.Text = txtcodP.Text.Substring(0, 12);

                    txtDescP.Text = descricao;

                    txtUniMed.Focus();
                }
            }
        }

        protected void txtDescP_TextChanged(object sender, EventArgs e)
        {
            string descricao;
            string cDescVal;
            ProdutoBUS negocio = new ProdutoBUS();
            if (txtDescP.Text != String.Empty)
            {
                cDescVal = negocio.GetDescProdVal(txtDescP.Text.Substring(13, txtDescP.Text.Length - 13));

                if (!cDescVal.Equals(""))
                {
                    if (txtDescP.Text.Length > 12)
                    {
                        txtDescP.Text.Replace("-", "");

                        txtcodP.Text = txtDescP.Text.Substring(0, 12);
                        descricao = txtDescP.Text.Substring(13, txtDescP.Text.Length - 13);
                        txtDescP.Text = descricao;

                        txtUniMed.Focus();
                    }
                }
            }
        }

        protected void ddlTipo_TextChanged(object sender, EventArgs e)
        {

            if (ddlTipo.SelectedValue.Equals("1"))
            {
                remessa.Visible = true;
                retorno.Visible = false;
                terceiro.Visible = false;
                nfOri.Visible = false;
                tpNf.Text = "Tipo de Remessa";
            }
            else if (ddlTipo.SelectedValue.Equals("2"))
            {
                terceiro.Visible = true;
                remessa.Visible = false;
                retorno.Visible = false;
                nfOri.Visible = false;
                tpNf.Text = "Tipo Bens em pode de Terceiros";
            }
            else if (ddlTipo.SelectedValue.Equals("3"))
            {
                retorno.Visible = true;
                remessa.Visible = false;
                terceiro.Visible = false;
                nfOri.Visible = true;
                tpNf.Text = "Tipo Retorno";
                txtNFOri.Focus();
            }
        }

        protected void ItensGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void ItensGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //removo os item selecionado no grid
            iTens.RemoveAt(e.RowIndex);
            preencheGrid();
        }

        protected void ItensGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void ItensGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void ItensGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            Utilitario util = new Utilitario();

            ProdutoBUS negocioAcols = new ProdutoBUS();

            HeaderForMOD headerformMOD = new HeaderForMOD();

            HeaderBUS negocioHeader = new HeaderBUS();

            string user = util.GetUser();

            try
            {
                //Valorizo objeto header para salvar no banco
                headerformMOD.numControl = int.Parse(lblControle.Text);
                headerformMOD.dtSolicit = Convert.ToDateTime(lblData.Text);
                headerformMOD.prazo = Convert.ToDateTime(txtData.Value);
                headerformMOD.user = user;
                headerformMOD.codGestor = lblGestor.Text;
                headerformMOD.numUser = lblNomeUser.Text;
                headerformMOD.depUser = lblNomDep.Text;
                headerformMOD.funUSer = lblNumFuncao.Text;
                headerformMOD.emalUser = lblEmailUser.Text;
                headerformMOD.retirada = ddlRet.SelectedValue;
                headerformMOD.unidade = ddlUnid.SelectedValue;
                headerformMOD.tipo = ddlTipo.SelectedValue;

                //verifica qual o tipo da nota para receber os checkbox correto
                if (ddlTipo.SelectedValue.Equals("1"))
                {
                    if (rdbConsertoRem.Checked)
                    {
                        headerformMOD.nfRem = "1";
                    }
                    else if (rdbBenefRem.Checked)
                    {
                        headerformMOD.nfRem = "2";
                    }
                    else if (rdbOutRem.Checked)
                    {
                        headerformMOD.nfRem = "3";

                    }
                }
                else if (ddlTipo.SelectedValue.Equals("2"))
                {

                    if (rddLocTer.Checked)
                    {
                        headerformMOD.nfTerc = "1";
                    }
                    else if (rdbEmpTer.Checked)
                    {
                        headerformMOD.nfTerc = "2";
                    }
                    else if (rdbOutTer.Checked)
                    {
                        headerformMOD.nfTerc = "3";
                    }
                }
                else if (ddlTipo.SelectedValue.Equals("3"))
                {

                    if (rdbLocRet.Checked)
                    {
                        headerformMOD.nfRet = "1";
                    }
                    else if (rdbEmpRet.Checked)
                    {
                        headerformMOD.nfRet = "2";
                    }
                    else if (rdbOutRet.Checked)
                    {
                        headerformMOD.nfRet = "3";
                    }
                }

                headerformMOD.nfOrigem = txtNFOri.Text.Trim();
                headerformMOD.justificativa = txtJstif.Text.Trim();

                headerformMOD.codCliFor = txtCodForn.Text;
                headerformMOD.loja = txtLoja.Text;
                headerformMOD.nomeCliFor = txtRsocial.Text;
                headerformMOD.cnpj = txtCnpj.Value;
                headerformMOD.endereco = txtEndereco.Text;
                headerformMOD.telefone = txtTelefone.Value;
                headerformMOD.email = txtEmail.Text;
                headerformMOD.baixa = "F";

                //valida os dados digitados na tela
                util.validaCamposHeader(headerformMOD);
                //Salva as informações do header no banco
                negocioHeader.SalvaHeader(headerformMOD);

                //Inicia laço para salvar os itens
                for (int i = 0; i < iTens.Count; i++)
                {
                    ProdutMOD acolsMOD = (ProdutMOD)iTens[i];

                    if (acolsMOD != null)
                    {   //chama função para salvar no banco os itens
                        acolsMOD.Item = i + 1;
                        negocioAcols.salvaItens(acolsMOD);
                    }

                }

                lblMensagem.Text = "Controle cadastrado com sucesso.";
                lblMensagem.ForeColor = Color.Green;
                lblMensagem.Focus();

                btnSalvar.Visible = false;
                btnNovoForm.Visible = true;
                btnEnvia.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Não foi possível cadastrar este controle (" + ex.Message + " ).";
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Focus();
            }
        }

        protected void txtUniMed_TextChanged(object sender, EventArgs e)
        {
            UnidMedBUS negocio = new UnidMedBUS();
            Utilitario util = new Utilitario();

            //objetos utilizados para carregar javascript na tela
            //------------------------------\\
            String csname1 = "PopupScript";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            //------------------------------\\

            string str = util.frmStr(txtUniMed.Text);

            string UnidMed = negocio.GetUnidMedInd(str);

            if (UnidMed != String.Empty)
            {
                txtUniMed.Text = str;
                txtQtd.Focus();
            }
            else
            {
                txtUniMed.Text = String.Empty;

                txtUniMed.Focus();

                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext1 = "alert('Unidade de Medida inválida!');";

                    cs.RegisterStartupScript(cstype, csname1, cstext1, true);
                }
            }
        }

        protected void btnNovoForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("../View/Formulario.aspx");
        }

        private ArrayList iTens
        {
            get
            {
                Object value = this.ViewState["iTens"];

                if (value == null)
                {
                    value = new ArrayList();
                    this.ViewState["iTens"] = value;
                }
                return (ArrayList)this.ViewState["iTens"];
            }
            set
            {
                this.ViewState["iTens"] = value;
            }
        }

        protected void btnEnvia_Click(object sender, EventArgs e)
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

            header = negocioHd.visualizaForm(lblControle.Text);
            list = negocioPd.listItens(lblControle.Text);

            try
            {
                envia.carregaHtml(header, list);

                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext = "alert('Email enviado com sucesso!');";

                    cs.RegisterStartupScript(cstype, csname1, cstext, true);
                }
            }
            catch (Exception ex)
            {
                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext = "alert('Ocorreu um erro no envio do e-mail. \nErro (" + ex.Message + ")!');";

                    cs.RegisterStartupScript(cstype, csname1, cstext, true);
                }
            }
        }

    }
}
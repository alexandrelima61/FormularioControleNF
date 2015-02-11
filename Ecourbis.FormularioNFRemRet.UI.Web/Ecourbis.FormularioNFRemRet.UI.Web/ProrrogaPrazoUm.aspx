<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutPadrao.Master" AutoEventWireup="true" CodeBehind="ProrrogaPrazoUm.aspx.cs" Inherits="Ecourbis.FormularioNFRemRet.UI.Web.ProrrogaPrazoUm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../Content/css/pages.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />

    <link href="ScriptsCssJs/DataTables/media/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="fancybox/jquery.fancybox.css" rel="stylesheet" />

    <script src="ScriptsCssJs/DataTables/media/js/jquery.js"></script>
    <script src="ScriptsCssJs/DataTables/media/js/jquery.dataTables.min.js"></script>

    <script src="fancybox/jquery.fancybox.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            oTable = $('#example').dataTable({
                "bPaginate": true,
                "bJQueryUI": false,
                "sPaginationType": "full_numbers"
            });
        });

        $(function () {
            $(".edit").fancybox({
                afterClose: function () {
                    location.reload();
                    return;
                }
            });
        });
    </script>

    <div runat="server" id="frmSlNfRmeRet">
        <div class="row">

            <div class="col-md-3">
                <div class="input-group">
                    <asp:Label runat="server" ID="lblTxtData" Text="Data da Solicitação:" CssClass="input-group-addon rotulo" />

                    <asp:Label runat="server" ID="lblDataSolict" CssClass="inputText form-control" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="input-group">
                    <asp:Label ID="lbltxtPrazo" Text="Prazo Retorno:" CssClass="input-group-addon rotulo" runat="server" />

                    <asp:Label ID="lblDataPrazo" runat="server" CssClass="inputText form-control" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="input-group">
                    <asp:Label ID="lblGestor" Text="Gestor:" CssClass="input-group-addon rotulo" runat="server" />

                    <asp:Label ID="lblTxtGestor" runat="server" CssClass="inputText form-control" />
                </div>
            </div>

            <div class="col-md-3">
                <div class="input-group">
                    <asp:Label runat="server" ID="lblTxtControl" Text="Cotrole:" CssClass="input-group-addon rotulo" />

                    <asp:Label runat="server" ID="lblControle" CssClass="inputText form-control" />
                </div>
            </div>

        </div>

        <hr class="csshr" />

        <div class="row" style="margin-bottom: 15px;">
            <div class="container">
                <div class="col-md-12">
                    <div class="col-md-3">
                        <div class="input-group">
                            <asp:Label ID="lblUser" runat="server" Text="Usuário:" CssClass="rotuloUser input-group-addon" />

                            <asp:Label ID="lblNomeUser" runat="server" CssClass="infoUSer form-control" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="input-group">
                            <asp:Label ID="lblDep" runat="server" Text="Departamento:" CssClass="rotuloUser input-group-addon" />

                            <asp:Label ID="lblNomDep" runat="server" Text="Tecnologia da Informação" CssClass="infoUSer form-control" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="input-group">
                            <asp:Label ID="lblFuncao" runat="server" Text="Função:" CssClass="rotuloUser input-group-addon" />

                            <asp:Label ID="lblNumFuncao" runat="server" CssClass="infoUSer form-control" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="input-group">
                            <asp:Label ID="lblEmailUs" runat="server" Text="Email:" CssClass="rotuloUser input-group-addon" />

                            <asp:Label ID="lblEmailUser" runat="server" CssClass="infoUSer form-control" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">

                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblRet" Text="Retirada:" runat="server" CssClass="rotulo input-group-addon" />

                        <asp:Label runat="server" ID="lblTextRetira" CssClass="inputText form-control" />
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblTxtUni" Text="Unidade:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbltxtUnidade" CssClass="infoUSer form-control" />
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblTipo" Text="Tipo:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbltxtTipo" CssClass="infoUSer form-control" />
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="col-md-12" id="nfOri" runat="server">
                        <div class="input-group">
                            <asp:Label ID="lblNfOri" Text="NF Origem:" CssClass="rotulo input-group-addon" runat="server" />

                            <asp:Label ID="lbltxtnfOri" CssClass="inputText form-control" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-10">
                    <div class="input-group">
                        <asp:Label ID="lblForn" Text="Fornecedor:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label class="inputText form-control" ID="lbltxtFornece" runat="server" />
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="input-group">
                        <asp:Label ID="lblLojaFor" Text="Loja:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbltxtLoja" CssClass="inputText form-control" />
                    </div>
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblCodForn" Text="Código de Cadastro:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbltxtCodForn" CssClass="inputText form-control" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <asp:Label ID="lblRSoci" Text="Razão Social:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbltxtRsocial" CssClass=" inputText form-control" />
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblCnpj" Text="CNPJ:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbbtxtCnpj" CssClass="inputText form-control" />
                    </div>
                </div>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-12">
                    <div class="input-group">
                        <asp:Label ID="lblEndereco" Text="Endereço:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbltxtEndereco" CssClass="inputText form-control" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 15px;">
            <div class="col-md-12">
                <div class="col-md-5">
                    <div class="input-group">
                        <asp:Label ID="lblTelefone" Text="Telefone:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label ID="lbltxtTelefone" runat="server" CssClass="inputText form-control" />
                    </div>
                </div>
                <div class="col-md-7">
                    <div class="input-group">
                        <asp:Label ID="lblEmail" Text="Email:" CssClass="rotulo input-group-addon" runat="server" type="email" />

                        <asp:Label runat="server" ID="lbltxtEmail" CssClass="inputText form-control" />
                    </div>
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">
                <div id="tbPrincipal" runat="server" class="col-md-12 text-center">
                </div>
            </div>
        </div>

        <hr class="csshr" />


        <div class="row">
            <div class="col-md-12">
                <div class="col-md-12 text-center">
                    <p class="rotulo" style="font-weight: bold; text-decoration: underline;">
                        <asp:Label ID="tpNf" runat="server" />
                    </p>
                </div>
            </div>
        </div>

        <div class="row" id="divRadionButton" runat="server">

            <div class='col-md-12' id="remessa" runat="server">
                <div class="col-md-12">
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rdbConcertoRem' runat='server' Text='Concerto' GroupName='tipo' />
                    </div>
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rdbBenefRem' runat='server' Text='Beneficiamento' GroupName='tipo' />
                    </div>
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rdbOutRem' runat='server' Text='Outros: especificar' GroupName='tipo' />
                    </div>
                </div>
            </div>

            <div class='col-md-12' id="terceiro" runat="server">
                <div class="col-md-12">
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rddLocTer' runat='server' Text='Locação' GroupName='tipo' />
                    </div>
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rdbEmpTer' runat='server' Text='Empréstimo' GroupName='tipo' />
                    </div>
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rdbOutTer' runat='server' Text='Outros: especificar' GroupName='tipo' />
                    </div>
                </div>
            </div>

            <div class='col-md-12' id="retorno" runat="server">
                <div class="col-md-12">
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rdbLocRet' runat='server' Text='Locação' GroupName='tipo' />
                    </div>
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rdbEmpRet' runat='server' Text='Empréstimo' GroupName='tipo' />
                    </div>
                    <div class='col-md-4 text-center rotulo'>
                        <asp:RadioButton ID='rdbOutRet' runat='server' Text='Outros: especificar' GroupName='tipo' />
                    </div>
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-12">
                    <asp:Label ID="lbltxtJstif" runat="server" CssClass="inputText" />
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-8 ">
                    <asp:Label ID="lblMensagen" runat="server" Style="border: 0!important;" />
                </div>
                <div class="col-md-2 ">
                    <asp:Button ID="btnNovoForm" Text="Novo Formulário" runat="server" CssClass="form-control btnPage" />
                </div>
                <div class="col-md-2 ">
                    <asp:Button ID="btnReEnvia" Text="Re Enviar" runat="server" type="reset" CssClass="form-control btnPageLimpa" />
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-12">
                    <asp:Label ID="lblMensagem" runat="server" CssClass="text-success form-control text-center" ForeColor="Red" />
                </div>
            </div>
        </div>

        <hr class="csshr" />
        <br />

    </div>


</asp:Content>

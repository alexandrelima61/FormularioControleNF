<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutPadrao.Master" AutoEventWireup="true" CodeBehind="VisualizarForme.aspx.cs" Inherits="Ecourbis.FormularioNFRemRet.UI.Web.View.VisualizarForme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <link href="../Content/themes/start/theme.css" rel="stylesheet" />

    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <div runat="server" id="frmSlNfRmeRet">
        <div class="row">
            <div class="col-md-12">
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
                        <span class="input-group-addon rotulo">Gestor:</span>
                        <asp:Label runat="server" ID="lblGestor" CssClass="inputText form-control" />
                    </div>
                </div>

                <div class="col-md-3 rotulo">
                    <div class="input-group">
                        <asp:Label runat="server" ID="lblTxtControl" Text="Cotrole:" CssClass="input-group-addon rotulo" />

                        <asp:Label runat="server" ID="lblControle" CssClass="inputText form-control" />
                    </div>
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
                    <div class="col-md-3 rotulo">
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

                        <asp:Label runat="server" ID="lblTextRetira" CssClass="infoUSer form-control"/>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblTxtUni" Text="Unidade:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbltxtUnidade" CssClass="infoUSer form-control"/>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblTipo" Text="Tipo:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label runat="server" ID="lbltxtTipo" CssClass="form-control infoUSer" />
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

        <div class="row" style="margin-top: 15px;">
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

                <div class="col-md-4">
                    <div class="input-group">
                        <asp:Label ID="lblTelefone" Text="Telefone:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:Label ID="lbltxtTelefone" runat="server" CssClass="inputText form-control" />
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="input-group">
                        <asp:Label ID="lblEmail" Text="Email:" CssClass="rotulo input-group-addon" runat="server" type="email" />

                        <asp:Label runat="server" ID="lbltxtEmail" CssClass="inputText form-control" />
                    </div>
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row" style="margin-top: 15px;">
            <div class="col-md-12">
                <div class="col-md-12">
                    <div id="itens" runat="server" class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="ItensGridView" runat="server" AutoGenerateColumns="False" CssClass="table"
                                Width="1127px" BackColor="White" 
                                BorderColor="#0c6ab6" BorderStyle="Solid" 
                                BorderWidth="3px" CellPadding="4" GridLines="Horizontal">

                                <Columns>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate><%#Container.DataItemIndex+1 %>    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Codigo">
                                        <ItemTemplate><%#Eval("Codigo") %>    </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtnome" runat="server" Text='<%#Eval("Codigo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descrição">
                                        <ItemTemplate><%#Eval("Descricao") %>    </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtendereco" runat="server" Text='<%#Eval("Descricao") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unid Med">
                                        <ItemTemplate><%#Eval("UnidMedida") %>    </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("UnidMedida") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantidade">
                                        <ItemTemplate><%#Eval("Quantidade") %>    </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtemail" runat="server" Text='<%#Eval("Quantidade") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Controle">
                                        <ItemTemplate><%#Eval("Controle") %>    </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("Quantidade") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prazo Ret">
                                        <ItemTemplate><%#Eval("prazoRetorno") %>    </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("prazoRetorno") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="#0c6ab6" Font-Bold="True" ForeColor="#ffffff" />
                                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>

                        </div>
                    </div>
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
                        <asp:RadioButton ID='rdbConsertoRem' runat='server' Text='Conserto' GroupName='tipo' />
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
                    <asp:Button ID="btnNovoForm" Text="Novo Formulário" runat="server" CssClass="form-control btnPage" OnClick="btnNovoForm_Click" />
                </div>
                <div class="col-md-2 ">
                    <asp:Button ID="btnReEnvia" Text="Re Enviar" runat="server" type="reset" CssClass="form-control btnPageLimpa" OnClick="btnReEnvia_Click" />
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

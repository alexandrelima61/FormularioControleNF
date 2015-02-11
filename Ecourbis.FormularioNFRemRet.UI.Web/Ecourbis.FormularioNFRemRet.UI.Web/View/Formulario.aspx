﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutPadrao.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Ecourbis.FormularioNFRemRet.UI.Web.View.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <link href="../Content/themes/start/theme.css" rel="stylesheet" />

    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="../Content/js/mayJavaScript.js"></script>

    <div runat="server" id="frmSlNfRmeRet">
        <div class="row">
            <div class="col-md-12">

                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label runat="server" ID="lblTxtData" Text="Data da Solicitação:" class="input-group-addon rotulo" />
                        <asp:Label runat="server" ID="lblData" CssClass="inputText form-control" />
                    </div>
                </div>

                <div class="col-md-3 rotulo">
                    <div class="input-group">
                        <span class="input-group-addon rotulo">Prazo Retorno:</span>
                        <input type="text" id="txtData" runat="server" class="form-control inputText rotulo" name="data" required="required"
                            maxlength="10" onkeydown="Mascara(this,Data);" onkeypress="Mascara(this,Data);" onkeyup="Mascara(this,Data);" onblur="VerificaData(this.value);" />
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon rotulo">Gestor:</span>
                        <asp:Label runat="server" ID="lblGestor" CssClass="form-control inputText" />
                    </div>
                </div>

                <div class="col-md-3 rotulo">
                    <div class="input-group">
                        <span class="input-group-addon rotulo">Cotrole:</span>
                        <asp:Label runat="server" ID="lblControle" CssClass="form-control inputText" placeholder="Informe o Gestor" />
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

                        <asp:DropDownList ID="ddlRet" runat="server" CssClass="dplBox inputText form-control" required="required">
                            <asp:ListItem Text="Selecione" Value="" />
                            <asp:ListItem Text="ALMOXARIFADO" Value="1" />
                            <asp:ListItem Text="SOLICITANTE" Value="2" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblTxtUni" Text="Unidade:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:DropDownList ID="ddlUnid" runat="server" CssClass="dplBox inputText form-control" required="required">
                            <asp:ListItem Text="Selecione" Value="" />
                            <asp:ListItem Text="SUL" Value="1" />
                            <asp:ListItem Text="LESTE" Value="2" />
                            <asp:ListItem Text="TRANSB. STO. AMARO" Value="3" />
                            <asp:ListItem Text="TRANSB. VERGUEIRO" Value="4" />
                            <asp:ListItem Text="CENTRAL MECAN. TRIAGEM" Value="5" />
                            <asp:ListItem Text="ATERRO CTL" Value="6" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblTipo" Text="Tipo:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="dplBox inputText form-control" required="required"
                            OnTextChanged="ddlTipo_TextChanged" AutoPostBack="true">
                            <asp:ListItem Text="Selecione" Value="" />
                            <asp:ListItem Text="NOTA FISCAL REMESSA" Value="1" />
                            <asp:ListItem Text="RECB. DE BEM DE TERCEUROS" Value="2" />
                            <asp:ListItem Text="NOTA FISCAL DE RETORNO" Value="3" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="col-md-12" id="nfOri" runat="server">
                        <div class="input-group">
                            <asp:Label ID="lblNfOri" Text="NF Origem:" CssClass="rotulo input-group-addon" runat="server" />

                            <asp:TextBox ID="txtNFOri" CssClass="form-control inputText" runat="server" />
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

                        <asp:TextBox class="form-control inputText"
                            ID="txtFornec" placeholder="Informe o codigo ou o nome do fornecedor"
                            runat="server" AutoPostBack="true"
                            OnTextChanged="inputName_TextChanged" onblur="doPostBack(this)" />

                    </div>
                </div>
                <div class="col-md-2">
                    <div class="input-group">
                        <asp:Label ID="lblLojaFor" Text="Loja:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:TextBox runat="server" ID="txtLoja" CssClass="form-control inputText" />
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

                        <asp:TextBox runat="server" ID="txtCodForn" CssClass="form-control inputText" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <asp:Label ID="lblRSoci" Text="Razão Social:" CssClass="rotulo input-group-addon" runat="server" />

                        <asp:TextBox runat="server" ID="txtRsocial" CssClass="form-control inputText" />
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblCnpj" Text="CNPJ:" CssClass="rotulo input-group-addon" runat="server" />

                        <input type="text" id="txtCnpj" runat="server" class="form-control inputText"
                            name="cnpj" maxlength="18" onkeydown="Mascara(this,Cnpj);" onkeypress="Mascara(this,Cnpj);" onkeyup="Mascara(this,Cnpj);" />
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
                        <asp:TextBox runat="server" ID="txtEndereco" CssClass="form-control inputText" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 15px;">
            <div class="col-md-12">
                <div class="col-md-4">
                    <div class="input-group">
                        <asp:Label ID="lblTelefone" Text="Telefone:" CssClass="rotulo input-group-addon" runat="server" />

                        <input type="text" id="txtTelefone" runat="server" class="form-control inputText"
                            onkeydown="Mascara(this,Telefone);" onkeypress="Mascara(this,Telefone);" onkeyup="Mascara(this,Telefone);" maxlength="15" />
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="input-group">
                        <asp:Label ID="lblEmail" Text="Email:" CssClass="rotulo input-group-addon" runat="server" type="email" />

                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control inputText" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 15px;">
            <div class="col-md-12">
                <div class="col-md-12">
                    <asp:Label ID="lblObs" Text="Obs: Se Informar o código do cadastro, não e necessário informar os outros dados." Style="font-weight: bold;" runat="server" />

                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label runat="server" ID="lblProduto" Text="Produto:" CssClass="rotulo input-group-addon" />

                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                        <asp:TextBox runat="server" ID="txtcodP" CssClass="form-control textboxAuto inputText"
                            placeholder="Codigo do produto"
                            AutoPostBack="true" OnTextChanged="txtcodP_TextChanged" onblur="doPostBack(this)" />

                    </div>
                </div>
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label runat="server" ID="lblDescP" Text="Descrição:" CssClass="rotulo input-group-addon" />

                        <asp:TextBox runat="server" ID="txtDescP" CssClass="form-control textboxAuto inputText"
                            placeholder="Descrição do produto"
                            AutoPostBack="true" OnTextChanged="txtDescP_TextChanged" onblur="doPostBack(this)" />

                    </div>
                </div>
                <div class="col-md-2">
                    <div class="input-group">
                        <asp:Label runat="server" ID="Label1" Text="Un. Med:" CssClass="rotulo input-group-addon" />

                        <asp:TextBox ID="txtUniMed" runat="server" CssClass="form-control inputText"
                            AutoPostBack="true" OnTextChanged="txtUniMed_TextChanged" onblur="doPostBack(this)" />

                    </div>
                </div>

                <div class="col-md-2">
                    <div class="input-group">
                        <asp:Label runat="server" ID="Quantidade" Text="Quantidade:" for="txtQtd" CssClass="rotulo input-group-addon" />

                        <asp:TextBox runat="server" ID="txtQtd" CssClass="form-control inputText" MaxLength="10"
                            onkeydown="Mascara(this,mskDigitos);" onkeypress="Mascara(this,mskDigitos);" onkeyup="Mascara(this,mskDigitos);" />
                    </div>

                </div>
                <div class="col-md-2">
                    <div class="col-md-12">
                        <asp:Button ID="Button1" runat="server" Text="Incluir" CssClass="form-control btnPage" OnClick="btnIncItem_Click" OnClientClick="return valEnvio();" />
                    </div>
                </div>
            </div>
        </div>
        <hr class="csshr" />

        <div id="itens" runat="server" class="row">
            <div class="col-md-12">
                <div class="col-md-12">
                    <asp:GridView ID="ItensGridView" runat="server" AutoGenerateColumns="False" CssClass="table"
                        OnRowCancelingEdit="ItensGridView_RowCancelingEdit" OnRowDataBound="ItensGridView_RowDataBound"
                        OnRowDeleting="ItensGridView_RowDeleting" OnRowEditing="ItensGridView_RowEditing"
                        OnRowUpdating="ItensGridView_RowUpdating"
                        Width="1127px" BackColor="White" BorderColor="#0c6ab6" BorderStyle="Solid"
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
                            <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/Imagens/delete.png" HeaderText="Deletar" />
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
                    <asp:TextBox ID="txtJstif" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

        <hr class="csshr" />

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-6 ">
                    <asp:Label ID="lblMensagen" runat="server" Style="border: 0!important;" />
                </div>
                <div class="col-md-2 ">
                    <asp:Button ID="btnNovoForm" Text="Novo Formulário" runat="server" CssClass="form-control btnPage" OnClick="btnNovoForm_Click" />
                </div>
                <div class="col-md-2 ">
                    <asp:Button ID="btnEnvia" Text="Enviar" runat="server" type="reset" CssClass="form-control btnPageLimpa" OnClick="btnEnvia_Click" />
                </div>
                <div class="col-md-2 ">
                    <asp:Button ID="btnSalvar" Text="Salvar" runat="server" CssClass="form-control btnPage" OnClick="btnSalvar_Click" />
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
    </div>

    <script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtFornec.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "Formulario.aspx/GetFornecName",
                        data: "{ 'pre':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });

        $(function () {
            $('#<%=txtUniMed.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "Formulario.aspx/GetUnidadeMed",
                        data: "{ 'pre':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });

        $(function () {
            $('#<%=txtcodP.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "Formulario.aspx/GetCodProd",
                        data: "{ 'pre':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });
        $(function () {
            $('#<%=txtDescP.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "Formulario.aspx/GetDescProd",
                        data: "{ 'pre':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });


        $(function () {
            $('#ContentPlaceHolder1_txtData').datepicker({
                dateFormat: "dd/mm/yy",
                closeText: 'Fechar',
                prevText: 'Anterior',
                nextText: 'Próximo',
                currentText: 'Começo',
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
                weekHeader: 'Semana',
                firstDay: 0,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: '',
                timeOnlyTitle: 'Só Horas',
                timeText: 'Tempo',
                hourText: 'Hora',
                minuteText: 'Minuto',
                secondText: 'Segundo',
                ampm: false,
                month: 'Mês',
                week: 'Semana',
                day: 'Dia',
                allDayText: 'Todo o Dia'
            });
        });

        function doPostBack(t) {
            if (t.value != "") {
                __doPostBack(t.name, "");
            }
        }
    </script>

</asp:Content>

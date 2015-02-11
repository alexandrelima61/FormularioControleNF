<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProrrPrimeiroPrazo.aspx.cs" Inherits="Ecourbis.FormularioNFRemRet.UI.Web.View.ProrrPrimeiroPrazo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <link href="../Content/themes/start/theme.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/css/pages.css" rel="stylesheet" />

    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="../Content/js/mayJavaScript.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="jumbotron alert alert-success text-center" style="margin-top: 10px;">
                    <h3>FORMULÁRIO DE SOLICITAÇÃO DE NOTA FISCAL DE REMESSA OU RETORNO DE BENS EM GERAL E DE CONTROLE DE RECEBIMENTO DE BENS DE TERCEIROS</h3>
                </div>
                <hr class="csshr" />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-12" >
                            <table id='example' class='table table-responsive display'>
                                   <thead>
                                       <tr'> 
                                           <th class='tableInith'>Item</th>
                                          <th class='tableInith'>Código</th>
                                          <th class='tableInith'>Descrição</th>
                                          <th class='tableInith'>Und. Méd.</th>
                                          <th class='tableInith'>Quant.</th>
                                          <th class='tableInith'>Controle</th>
                                          <th class='tableInith'>Prazo Ret.</th>
                                          <th class='tableInith'>Prorrogar</th>
                                      </tr>
                                   </thead>
                              <tr>
                                  <td class='tableInitd'>
                                      <asp:Label ID="lblItem" runat="server"></asp:Label>
                                  </td>
                                  <td class='tableInitd'>
                                      <asp:Label ID="lblCod" runat="server"></asp:Label>
                                  </td>
                                  <td class='tableInitd'>
                                      <asp:Label ID="lblDesc" runat="server"></asp:Label>
                                  </td>
                                  <td class='tableInitd'>
                                      <asp:Label ID="lblUniMed" runat="server"></asp:Label>
                                  </td>
                                  <td class='tableInitd'>
                                      <asp:Label ID="lblQtd" runat="server"></asp:Label>
                                  </td>
                                  <td class='tableInitd'>
                                      <asp:Label ID="lblControl" runat="server" ></asp:Label>
                                  </td>
                                  <td class='tableInitd' >
                                      <input type="text" id="txtPrazoRe" runat="server" name="data" required="required" style="padding-left:5px;width:80px;border-radius:3px;"
                                        maxlength="10" onkeydown="Mascara(this,Data);" onkeypress="Mascara(this,Data);" onkeyup="Mascara(this,Data);" onblur="VerificaData(this.value);" />

                                  </td>
                                  <td class='tableInitd text-center'>
                                      <asp:ImageButton ID="ibtnAlterar" runat="server" ImageUrl="~/Imagens/aceitar.jpg" Height="16px" OnClick="ibtnAlterar_Click" />
                                  </td>
                              </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:Label runat="server" ID="lblMensagem" CssClass="text-center"/>
                                    </td>
                                </tr>
                               </table>
                          </div>
                    </div>
                    <asp:HiddenField ID="hdfRecno" runat="server" />
                    <asp:HiddenField ID="hdfData" runat="server" />
                </div>
                <hr class="csshr" />
                <div class="alert alert-success text-right" style="margin-top: 15px;">
                    <h3>A ECOURBIS S/A detem de todos os direitos <%: DateTime.Now.Month %>/<%: DateTime.Now.Year %></h3>
                </div>

            </div>
        </div>

        <script>
            //Iniciando o Jquery
            $(function () {

                $('#txtPrazoRe').datepicker({
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

    </script>

    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baixarControle.aspx.cs" Inherits="Ecourbis.FormularioNFRemRet.UI.Web.View.baixarControle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baixar controle</title>
    <link href="../Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/css/pages.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-md-12 text-center">
                <table class="table">
                    <tr>
                        <td class="text-left">
                            <div class="input-group" style="width: 200px;">
                                <label class="input-group-addon" for="controle">Controle</label>
                                <asp:Label ID="controle" name="controle" runat="server" class="form-control" />
                            </div>
                        </td>
                        <td class="text-left">
                            <span>
                                <input type='radio' name='baixar' value="T" id="baixar" runat="server" />&nbsp;<label for="baixar">Baixar Controle</label>
                            </span>
                        </td>
                        <td class="text-left">
                            <asp:Button ID="btnBaixar" runat="server" CssClass="form-control btnPage" Text="Baixar" OnClick="btnBaixar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMensagem" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

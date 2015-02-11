<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Erro404.aspx.cs" Inherits="Impacta.Aula2.UI.Web.Erros.Erro404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina Padrao Erro 404</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 154px;
        }
        .auto-style3 {
            font-weight: bold;
            font-size: x-large;
        }
        .auto-style4 {
            width: 128px;
            height: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" rowspan="6">
                    <img alt="" class="auto-style4" src="../Erros/Imagens/erro.png" /></td>
                <td>
                    <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-size: x-large; color: #FF3300" Text="A página que você tentou acessar não EXISTE!!!"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblIp" runat="server" CssClass="auto-style3" Text="IP:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style3" Text="Usuário:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPagina" runat="server" CssClass="auto-style3" Text="Página:"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

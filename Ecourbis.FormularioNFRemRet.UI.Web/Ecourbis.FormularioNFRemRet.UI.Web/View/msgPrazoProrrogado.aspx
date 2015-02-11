<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msgPrazoProrrogado.aspx.cs" Inherits="Ecourbis.FormularioNFRemRet.UI.Web.View.msgPrazoProrrogado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="padding:10% 10%;">
            <div class="text-center">
                <asp:Label runat="server" ID="lblMensagem1" ForeColor="Red">O prazo deste item já foi prorrogado uma vez!</asp:Label>
                <br />
                <asp:Label runat="server" ID="lblMensagem2" ForeColor="Red">A segunda vez só o <b>Gestor</b> tem permissão!</asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

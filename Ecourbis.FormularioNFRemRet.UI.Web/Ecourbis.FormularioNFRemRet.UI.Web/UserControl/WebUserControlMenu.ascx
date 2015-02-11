<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlMenu.ascx.cs" Inherits="Ecourbis.FormularioNFRemRet.UI.Web.UserControl.WebUserControlMenu" %>

<link href="Content/css/jquery-ui.css" rel="stylesheet" />
<link href="../Content/css/pages.css" rel="stylesheet" />
<script src="Content/js/jquery-1.9.1.js"></script>
<script src="Content/js/jquery-ui.js"></script>

<nav class="navbar navbar-inverse boxShadow bordas" role="navigation">
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bar1">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand navPage meuLink" href="../Default.aspx" ><b>Pagina Inicial</b></a>
    </div>
    <div class="collapse navbar-collapse" id="bar1">
        <ul class="nav navbar-nav">
            <li><a href="http://portal.ecourbis.com.br/Pages/index_New.htm" class="navPage meuLink"><b>Portal Ecourbis</b></a></li>
            <li><a href="../View/Formulario.aspx" class="navPage meuLink"><b>Formulário</b></a></li>
        </ul>
    </div>
</nav>

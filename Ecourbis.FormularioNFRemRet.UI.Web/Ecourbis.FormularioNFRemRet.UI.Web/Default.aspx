<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutPadrao.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ecourbis.FormularioNFRemRet.UI.Web.View.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../Content/css/pages.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />

    <link href="ScriptsCssJs/DataTables/media/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="fancybox/jquery.fancybox.css" rel="stylesheet" />

    <%--<script src="ScriptsCssJs/DataTables/media/js/jquery.js"></script>--%>
    <script src="ScriptsCssJs/DataTables/media/js/jquery.dataTables.min.js"></script>

    <script src="fancybox/jquery.fancybox.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            oTable = $('#example').dataTable({
                "bPaginate": true,
                "bJQueryUI": false,
                "sPaginationType": "full_numbers",
                "dom": 'Rlfrtip'
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

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div id="tbPrincipal" runat="server" class="col-md-12">
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>

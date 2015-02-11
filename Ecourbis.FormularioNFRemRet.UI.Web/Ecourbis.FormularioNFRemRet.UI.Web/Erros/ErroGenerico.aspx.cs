using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ecourbis.FormularioNFRemRet.Business;

namespace Impacta.Aula2.UI.Web.Erros
{
    public partial class ErroGenerico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitario util = new Utilitario();

            //Pegamos o nome do Usuário
            lblUsuario.Text += util.GetUser().ToUpper();
            //Pegamos o IP
            lblIp.Text += util.GetIp();

            //Pegamos o valor da variavel
            //de URl(aspxerrorpath)
            //lblPagina.Text += " " + Request.QueryString["aspxerrorpath"];
            lblPagina.Text += " " + Request.RawUrl;

            //Pegamos a mensagem de erro

            lblErro.Text = Server.GetLastError().InnerException.Message;
        }
    }
}
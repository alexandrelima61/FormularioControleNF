using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ecourbis.FormularioNFRemRet.Business;

namespace Impacta.Aula2.UI.Web.Erros
{
    public partial class Erro404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitario util = new Utilitario();

            //Subiu para memória pegamos algumas
            //Informações para o Suporte

            //Pegamos o nome do Usuário
            lblUsuario.Text += " " + util.GetUser().ToUpper();
            //Pegamos o IP
            lblIp.Text += " " + util.GetIp();

            //Pegamos o valor da variavel
            lblPagina.Text += " " + Request.RawUrl; 
 
        }
    }
}
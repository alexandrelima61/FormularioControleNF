using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using System.Security.Principal;
using System.DirectoryServices;

using Ecourbis.FormularioNFRemRet.Business.br.com.ecourbis.webservice;
using Ecourbis.FormularioNFRemRet.Model;

namespace Ecourbis.FormularioNFRemRet.Business
{
    public class Utilitario
    {
        public string masckDados(string str, int opcao)
        {
            string dado = str;

            if (opcao == 1)
            {
                if (str.Length > 9)
                {
                    if (str.Length == 10)
                    {
                        dado = "(" + str.Substring(0, 2) + ") " + str.Substring(2, 4) + "-" + str.Substring(6, 4);
                    }
                    else if (str.Length == 11)
                    {
                        dado = "(" + str.Substring(0, 3) + ") " + str.Substring(3, 4) + "-" + str.Substring(7, 4);
                    }
                    else if (str.Length == 13)
                    {
                        dado = "(" + str.Substring(0, 3) + ") " + str.Substring(3, 4) + "-" + str.Substring(7, 6);
                    }
                    else if (str.Length == 14)
                    {
                        dado = "(" + str.Substring(0, 3) + ") " + str.Substring(3, 4) + "-" + str.Substring(7, 7);
                    }
                    else
                    {
                        dado = "(" + str.Substring(0, 3) + ") " + str.Substring(3, 4) + "-" + str.Substring(7, 9);
                    }
                }
            }
            else if (opcao == 2)
            {
                if (str.Length > 11)
                {
                    dado = str.Substring(0, 2) + "." + str.Substring(2, 3) + "." + str.Substring(5, 3) + "/" + str.Substring(8, 4) + "-" + str.Substring(12, 2);
                }
            }

            return dado;
        }

        public String GetIp()
        {
            string Host = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostAddresses(Host);

            return ip[1].ToString();
        }

        public string GetUser()//Usuário logado + domínio
        {
            string UsName = WindowsIdentity.GetCurrent().Name;//Domínio + Login
            //var x = new System.Web.UI.Page();
            //string usName = x.Page.User.Identity.Name.ToString();

            //return usName.Replace(@"ECOURBIS\", "").ToLower();
            return UsName.Replace(@"ECOURBIS\", "").ToLower();
        }

        public string GetNameCompletAD()
        {
            DirectoryEntry directoryEntry = new DirectoryEntry("WinNT://" + Environment.UserDomainName + "/" + Environment.UserName);
            string nomeCompleto = directoryEntry.Properties["fullName"].Value.ToString();

            return nomeCompleto;
        }

        public string GetDepartamento(string user)
        {
            string dpartUser;
            WSusername obj = new WSusername();

            dpartUser = obj.wsDepartment(user).ToString();

            return dpartUser;
        }

        public string GetEmail(string user)
        {
            string emailUser;
            WSusername obj = new WSusername();

            emailUser = obj.wsEmailRequestor(user).ToString();

            return emailUser;
        }

        public void validaCamposHeader(HeaderForMOD headerformMOD)
        {
            //verifica se a data informada e menor ou igual a hj
            if (headerformMOD.prazo <= DateTime.Now)
                throw new Exception("Por favor, o campo Prazo de retorno deve ser mair que a data de hoje!");

            //verifica se o prazo de retorno esta preenchido
            if (headerformMOD.prazo.ToString() == String.Empty)
                throw new Exception("Por favor, preencha o campo Prazo Retorno!");

            //verifica se o tipo da origem e retorno e se o campo nf de origem esta preenchido
            if (headerformMOD.tipo.Equals("3") && headerformMOD.nfOrigem == String.Empty)
                throw new Exception("Por favor, preencha o campo NF Origem!");

            //verifica se alguns do chequebox nf retorno foram marcados
            if (headerformMOD.tipo.Equals("3"))
            {
                if (headerformMOD.nfRet == null)
                {
                    throw new Exception("Por favor, informe o tipo do retorno!");
                }
                else  //verifica se a opção do chequebox foi outros e verifica se o campo justif. foi preenchido
                    if (headerformMOD.nfRet.Equals("3") && (headerformMOD.justificativa == String.Empty))
                        throw new Exception("Por favor, preencha o campo Justificativa do retorno!");
            }


            //verifica se alguns do chequebox nf terceiro foram marcados
            if (headerformMOD.tipo.Equals("2"))
            {
                if (headerformMOD.nfTerc == null)
                {
                    throw new Exception("Por favor, informe o tipo do Terceiro!");
                }
                else //verifica se a opção do chequebox foi outros e verifica se o campo justif. foi preenchido
                    if (headerformMOD.nfTerc.Equals("3") && (headerformMOD.justificativa == String.Empty))
                        throw new Exception("Por favor, preencha o campo Justificativa do Terceiro!");
            }


            //verifica se alguns do chequebox nf remessa foram marcados
            if (headerformMOD.tipo.Equals("1"))
            {
                if (headerformMOD.nfRem == null)
                {
                    throw new Exception("Por favor, informe o tipo do Remessa!");
                }
                else
                    //verifica se a opção do chequebox foi outros e verifica se o campo justif. foi preenchido
                    if (headerformMOD.nfRem.Equals("3") && (headerformMOD.justificativa == String.Empty))
                        throw new Exception("Por favor, preencha o campo Justificativa do Remessa!");
            }


        }

        public string localRet(string lcRet)
        {
            if (lcRet.Equals("1"))
            {
                return "ALMOXARIFADO";
            }
            else
            {
                return "SOLICITANTE";
            }
        }

        public string unidadeResp(string undResp)
        {
            if (undResp.Equals("1"))
            {
                return "SUL";
            }
            else if (undResp.Equals("2"))
            {
                return "LESTE";
            }
            else if (undResp.Equals("3"))
            {
                return "TRANSB. STO. AMARO";
            }
            else if (undResp.Equals("4"))
            {
                return "TRANSB. VERGUEIRO";
            }
            else if (undResp.Equals("5"))
            {
                return "CENTRAL MECAN. TRIAGEM";
            }
            else
            {
                return "ATERRO CTL";
            }
        }

        public string nfTipo(string nfTp)
        {
            if (nfTp.Equals("1"))
            {
                return "Nota Fiscal Remessa";
            }
            else if (nfTp.Equals("2"))
            {
                return "Recb. de Bem de Terceiros";
            }
            else
            {
                return "Nota Fiscal de Retorno";
            }
        }


        public bool ComparaData(DateTime p1, string p2)
        {
            //if (Convert.ToDateTime(p1) >= Convert.ToDateTime(p2))
            if (p1 >= Convert.ToDateTime(p2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string frmStr(string str)
        {
            string s = "";

            for (int i = 0; i < (str.Length + 1); i++)
            {
                if (i != 0)
                {
                    if (str.Substring(0, i).Contains(" "))
                    {
                        break;
                    }
                    s = str.Substring(0, i).Trim().ToUpper();
                }
            }
            return s;
        }
    }
}

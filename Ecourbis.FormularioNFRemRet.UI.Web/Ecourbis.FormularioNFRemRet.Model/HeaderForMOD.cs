using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecourbis.FormularioNFRemRet.Model
{
    public class HeaderForMOD
    {
        public int recno { get; set; }
        public int numControl { get; set; }
        public string filial { get; set; }
        public string retirada { get; set; }
        public string user { get; set; }
        public string numUser { get; set; }
        public string depUser { get; set; }
        public string funUSer { get; set; }
        public string emalUser { get; set; }
        public DateTime dtSolicit { get; set; }
        public DateTime prazo { get; set; }
        public DateTime proPrazoUm { get; set; }
        public DateTime proPrazoDois { get; set; }
        public string unidade { get; set; }
        public string tipo { get; set; }
        public string nfOrigem { get; set; }
        public string codCliFor { get; set; }
        public string nomeCliFor { get; set; }
        public string loja { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string cnpj { get; set; }
        public string nfRem { get; set; }
        public string nfTerc { get; set; }
        public string nfRet { get; set; }
        public string justificativa { get; set; }
        public string baixa { get; set; }
        public string codGestor { get; set; }
    }

}

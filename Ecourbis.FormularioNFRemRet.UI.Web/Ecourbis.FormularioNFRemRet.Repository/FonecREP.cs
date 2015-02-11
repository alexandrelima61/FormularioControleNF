using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.Model;
using Ecourbis.FormularioNFRemRet.DataAccess;

namespace Ecourbis.FormularioNFRemRet.Repository
{
    public class FonecREP
    {
        public List<string> listaFornec(string pref)
        {
            var ListaFornec = new List<string>();

            using (var con = new DADOSADVEntities())
            {
                var fornecedores = from c in con.viewForne
                                   where (c.A2_COD.Contains(pref) || c.A2_NOME.ToUpper().Contains(pref))
                                   select new
                                   {
                                       Fornec = c.A2_COD + " - " + c.A2_NOME
                                   };
                foreach (var fornecedor in fornecedores)
                {
                    ListaFornec.Add(fornecedor.Fornec.Trim());
                }

            }

            return ListaFornec;
        }

        public FornecMOD GetDadosForn(string codigo)
        {
            FornecMOD dadosFornec = new FornecMOD();

            using (var con = new DADOSADVEntities())
            {
                try
                {
                    var dados = con.viewForne.Single(x => x.A2_COD == codigo);

                    dadosFornec.Cod = dados.A2_COD.Trim();
                    dadosFornec.nome = dados.A2_NOME.Trim();
                    dadosFornec.loja = dados.A2_LOJA.Trim();
                    dadosFornec.endereco = dados.A2_END.Trim();
                    dadosFornec.email = dados.A2_EMAIL.Trim();
                    dadosFornec.tel = dados.A2_DDD.Trim() + dados.A2_TEL.Replace("-", "").Trim();
                    dadosFornec.cgc = dados.A2_CGC.Trim();
                }
                catch (Exception)
                {
                }
            }

            return dadosFornec;
        }
        
    }
}

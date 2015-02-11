using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.DataAccess;

namespace Ecourbis.FormularioNFRemRet.Repository
{
    public class UnidMedREP
    {
        public List<string> GetUnidadeMedida(string unid)
        {
            List<string> liUnidadeMed = new List<string>();

            using (var conn = new DADOSADVEntities())
            {
                var unidade = from u in conn.viewUnidMed
                              where u.AH_UNIMED.ToUpper().Contains(unid.ToUpper())
                              select u;

                foreach (var item in unidade)
                {
                    liUnidadeMed.Add(item.AH_UNIMED.ToString() + " - " + item.AH_UMRES.ToString());
                }
            }
            return liUnidadeMed;
        }

        public string GetUnidadeMedidaValida(string str)
        {
            string unMed = "";

            using (var conn = new DADOSADVEntities())
            {
                try
                {
                    var unidade = conn.viewUnidMed.Single(x => x.AH_UNIMED == str);

                        unMed = unidade.AH_UNIMED;
                }
                catch (Exception)
                {
                }
            }

            return unMed;
        }
    }
}

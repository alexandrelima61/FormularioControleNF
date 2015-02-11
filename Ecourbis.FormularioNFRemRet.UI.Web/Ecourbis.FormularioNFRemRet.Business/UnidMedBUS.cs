using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.Repository;

namespace Ecourbis.FormularioNFRemRet.Business
{
    public class UnidMedBUS
    {
        UnidMedREP repositorio;


        public List<string> GetUnidMed(string unidade)
        {
            repositorio = new UnidMedREP();

            List<string> listUni = new List<string>();
            listUni = repositorio.GetUnidadeMedida(unidade);


            return listUni;
        }

        public string GetUnidMedInd(string str)
        {
            repositorio = new UnidMedREP();
            string uniMed;

            uniMed = repositorio.GetUnidadeMedidaValida(str);


            return uniMed;
        }
    }
}

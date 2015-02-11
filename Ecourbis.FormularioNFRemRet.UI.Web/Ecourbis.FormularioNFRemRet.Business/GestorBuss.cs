using Ecourbis.FormularioNFRemRet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecourbis.FormularioNFRemRet.Business
{
    public class GestorBuss
    {
        private GestorRep repositoryGest;

        public int GetMatUserLogado(string userLogado)
        {
            repositoryGest = new GestorRep();

            return repositoryGest.GetMatUserLogado(userLogado);
        }

        public string GetCodGestor(int matUserLogado)
        {
            repositoryGest = new GestorRep();

            return repositoryGest.GetCodGestorUserLog(matUserLogado);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.Repository;
using Ecourbis.FormularioNFRemRet.Model;

namespace Ecourbis.FormularioNFRemRet.Business
{
    public class FoneceBuss
    {

        public FonecREP repositoryFor;

        public List<string> GetFornece(string codForn)
        {
            repositoryFor = new FonecREP();

            var fornecedores = repositoryFor.listaFornec(codForn.ToUpper());

            return fornecedores;
        }

        public FornecMOD GetDadosFornece(string forn)
        {
            string cdForne;
            FornecMOD frnc = new FornecMOD();
            repositoryFor = new FonecREP();


            if (forn.Length > 5)
            {
                cdForne = forn.Substring(0, 6);

                frnc = repositoryFor.GetDadosForn(cdForne);
            }

            return frnc;
        }        

    }
}

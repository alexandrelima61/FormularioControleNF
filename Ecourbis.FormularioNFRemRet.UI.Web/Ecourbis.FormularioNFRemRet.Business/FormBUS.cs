using Ecourbis.FormularioNFRemRet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecourbis.FormularioNFRemRet.Business
{
    public class FormBUS
    {
        FormREP repositorio;

        public string GetNumForm()
        {
            string numForm;
            repositorio = new FormREP();

            numForm = repositorio.NumForm();

            return numForm;
        }

        public string GetFuncaoFunc(string user)
        {
            repositorio = new FormREP();

            return repositorio.GetFuncaoFun(user);
        }
    }
}

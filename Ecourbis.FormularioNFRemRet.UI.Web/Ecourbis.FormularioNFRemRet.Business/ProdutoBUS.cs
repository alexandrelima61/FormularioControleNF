using Ecourbis.FormularioNFRemRet.Model;
using Ecourbis.FormularioNFRemRet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecourbis.FormularioNFRemRet.Business
{
    public class ProdutoBUS
    {
        public ProdutREP repositoryProd;

        public void salvaItens(ProdutMOD item)
        {
            repositoryProd = new ProdutREP();
            repositoryProd.gardaAcols(item);
        }

        public List<string> GetProduto(string codProd)
        {
            repositoryProd = new ProdutREP();
            var produtos = repositoryProd.listaProduto(codProd);

            return produtos;
        }

        public List<string> GetDescProd(string descProd)
        {
            repositoryProd = new ProdutREP();

            var descProduto = repositoryProd.listaDescProd(descProd);

            return descProduto;
        }

        public List<Model.ProdutMOD> listItens(string numControl)
        {
            int numCtrl = Convert.ToInt32(numControl);
            List<ProdutMOD> lstProduto = new List<ProdutMOD>();
            repositoryProd = new ProdutREP();

            lstProduto = repositoryProd.ListProduto(numCtrl.ToString("00000000"));

            return lstProduto;
        }

        public ProdutMOD GetItemProd(string recno)
        {
            repositoryProd = new ProdutREP();
            ProdutMOD prodBus = new ProdutMOD();

            prodBus = repositoryProd.GetItemProd(recno);

            return prodBus;
        }

        public void ProrrogPUm(ProdutMOD p)
        {
            repositoryProd = new ProdutREP();
            repositoryProd.ProrrgP(p);
        }

        public string GetDescProdVal(string descProdVal)
        {
            repositoryProd = new ProdutREP();

            string descProduto = repositoryProd.DescProd(descProdVal);

            return descProduto;
        }

        public int CaontItemProrrog(string control)
        {
            repositoryProd = new ProdutREP();

            return repositoryProd.countItensProrr(control.ToString());
        }
    }
}

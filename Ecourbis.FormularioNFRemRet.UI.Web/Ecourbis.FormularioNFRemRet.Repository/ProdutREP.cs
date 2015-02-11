using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.DataAccess;
using Ecourbis.FormularioNFRemRet.Model;
using System.Data.Entity.Validation;

namespace Ecourbis.FormularioNFRemRet.Repository
{
    public class ProdutREP
    {
        public List<string> listaProduto(string produt)
        {
            List<string> listarP = new List<string>();

            using (var con = new DADOSADVEntities())
            {
                var produtos = from p in con.viewProd
                               where p.B1_COD.ToUpper().Contains(produt.ToUpper())
                               select new
                               {
                                   prodDesc = p.B1_COD.Trim() + "-" + p.B1_DESC.Trim()
                               };
                foreach (var produto in produtos)
                {
                    listarP.Add(produto.prodDesc.Trim());
                }

            }

            return listarP;
        }

        public List<string> listaDescProd(string descProd)
        {
            List<string> listDescP = new List<string>();

            using (var con = new DADOSADVEntities())
            {
                var descricoes = from p in con.viewProd
                                 where p.B1_DESC.ToUpper().Contains(descProd.ToUpper())
                                 select new
                                 {
                                     descProd = p.B1_COD.Trim() + "-" + p.B1_DESC.Trim()
                                 };

                foreach (var descicao in descricoes)
                {
                    listDescP.Add(descicao.descProd.ToUpper().Trim());
                }

            }

            return listDescP;
        }

        public List<ProdutMOD> ListProduto(string numCtrl)
        {
            List<ProdutMOD> list = new List<ProdutMOD>();

            using (var conn = new DADOSADVEntities())
            {
                var itens = from p in conn.PAI010
                            where p.PAI_CONTRO.Equals(numCtrl)
                                && p.D_E_L_E_T_.Equals(" ")
                            select p;

                foreach (var item in itens)
                {
                    ProdutMOD prod = new ProdutMOD();
                    prod.Item = Convert.ToInt32(item.PAI_ITEM);
                    prod.Codigo = item.PAI_CODP;
                    prod.Descricao = item.PAI_DESC;
                    prod.UnidMedida = item.PAI_UNMED;
                    prod.Quantidade = item.PAI_QTD;
                    prod.prazoRetorno = convertDt(item.PAI_PRAZO);
                    prod.Controle = item.PAI_CONTRO;
                    prod.recno = item.R_E_C_N_O_;
                    prod.log = Convert.ToInt32(item.PAI_LOGPRA);

                    list.Add(prod);
                }
            }

            return list;
        }

        public void gardaAcols(ProdutMOD acols)
        {
            DateTime date = Convert.ToDateTime(acols.prazoRetorno).Date;

            using (var con = new DADOSADVEntities())
            {
                var item = new PAI010();

                try
                {
                    item.PAI_FILIAL = "  ";
                    item.PAI_ITEM = acols.Item;
                    item.PAI_CONTRO = acols.Controle;
                    item.PAI_CODP = acols.Codigo;
                    item.PAI_DESC = acols.Descricao.ToUpper();
                    item.PAI_QTD = acols.Quantidade;
                    item.PAI_PRAZO = date.ToString("yyyyMMdd");
                    item.PAI_UNMED = acols.UnidMedida;
                    item.PAI_LOGPRA = 0;

                    item.D_E_L_E_T_ = " ";
                    //item.R_E_C_N_O_ = GetRecnoPai();

                    con.PAI010.Add(item);
                    con.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }

        public string convertDt(string str)
        {
            string data = str;

            if (!str.Equals(""))//20140511
            {
                data = str.Substring(6, 2) + "/" + str.Substring(4, 2) + "/" + str.Substring(0, 4);
            }

            return data;
        }

        public string convertCaracterDt(string str)
        {
            string data = str;

            if (!str.Equals(""))//31/08/2014
            {
                data = str.Substring(6, 4) + str.Substring(3, 2) + str.Substring(0, 2);
            }

            return data;
        }

        public ProdutMOD GetItemProd(string recno)
        {
            ProdutMOD p = new ProdutMOD();

            ProdutREP acols = new ProdutREP();

            int rc = int.Parse(recno);

            using (var conn = new DADOSADVEntities())
            {
                try
                {
                    var produto = conn.PAI010.Single(x => x.R_E_C_N_O_ == rc);

                    p.Item = Convert.ToInt32(produto.PAI_ITEM);
                    p.Codigo = produto.PAI_CODP;
                    p.Descricao = produto.PAI_DESC;
                    p.UnidMedida = produto.PAI_UNMED;
                    p.Quantidade = produto.PAI_QTD;
                    p.prazoRetorno = convertDt(produto.PAI_PRAZO);
                    p.Controle = produto.PAI_CONTRO;
                    p.recno = Convert.ToInt32(produto.R_E_C_N_O_);

                }
                catch (Exception )
                {
                }
            }
            return p;
        }
        //prorroga prazo
        public void ProrrgP(ProdutMOD p)
        {

            using (var conn = new DADOSADVEntities())
            {
                try
                {
                    var produto = conn.PAI010.Single(x => x.R_E_C_N_O_ == p.recno);

                    produto.PAI_ITEM = p.Item;
                    produto.PAI_CODP = p.Codigo;
                    produto.PAI_DESC = p.Descricao;
                    produto.PAI_UNMED = p.UnidMedida;
                    produto.PAI_QTD = p.Quantidade;
                    produto.PAI_PRAZO = convertCaracterDt(p.prazoRetorno);
                    produto.PAI_CONTRO = p.Controle;
                    produto.PAI_LOGPRA = 1;//log de 1ª prorrogação

                    conn.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }

        public string DescProd(string descProdVal)
        {
            using (var conn = new DADOSADVEntities())
            {
                try
                {
                    var cDescri = conn.viewProd.Single(x => x.B1_DESC.Trim().Equals(descProdVal.Trim()));

                    return cDescri.B1_DESC.Trim();
                }
                catch (Exception)
                {
                    return "";
                }

                
            }
        }

        public int countItensProrr(string control)
        {
            int nVal = 0;

            using (var conn = new DADOSADVEntities())
            {
                var itens = from i in conn.PAI010
                            where i.PAI_CONTRO.Equals(control)
                            select i;

                foreach (var item in itens)
                {
                    if (Convert.ToInt32(item.PAI_LOGPRA) == 0)
                    {
                        nVal = 1;
                    }
                }

            }

            return nVal;
        }
    }
}

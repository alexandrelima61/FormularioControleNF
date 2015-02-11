using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.Model;
using Ecourbis.FormularioNFRemRet.DataAccess;

using System.Data.Entity.Validation;

namespace Ecourbis.FormularioNFRemRet.Repository
{
    public class headerREP
    {
        public void GuardaHeader(HeaderForMOD headerformMOD)
        {
            using (var conn = new DADOSADVEntities())
            {
                var header = new PAH010();

                try
                {
                    header.PAH_FILIAL = "  ";
                    header.PAH_CONTRO = headerformMOD.numControl;
                    header.PAH_RETIRA = headerformMOD.retirada;
                    header.PAH_USER = headerformMOD.user;
                    header.PAH_NUMUSE = headerformMOD.numUser;
                    header.PAH_DEPUSE = headerformMOD.depUser;
                    header.PAH_EMAIL = headerformMOD.emalUser;

                    header.PAH_DTSOLI = headerformMOD.dtSolicit.ToString("yyyyMMdd");
                    header.PAH_PRAZO = headerformMOD.prazo.ToString("yyyyMMdd");

                    header.PAH_PRAZOU = "";
                    header.PAH_PRAZOS = "";

                    header.PAH_FUNUSE = headerformMOD.funUSer;

                    header.PAH_UNIDAD = headerformMOD.unidade;
                    header.PAH_TIPO = headerformMOD.tipo;

                    header.PAH_NFORI = headerformMOD.nfOrigem;

                    header.PAH_NFREM = headerformMOD.nfRem == null ? "0" : headerformMOD.nfRem;
                    header.PAH_NFTERC = headerformMOD.nfTerc == null ? "0" : headerformMOD.nfTerc;
                    header.PAH_NFRET = headerformMOD.nfRet == null ? "0" : headerformMOD.nfRet;
                    header.PAH_JUST = headerformMOD.justificativa;

                    header.PAH_CLIFOR = headerformMOD.codCliFor;
                    header.PAH_LOJA = headerformMOD.loja;
                    header.PAH_NOME = headerformMOD.nomeCliFor;
                    header.PAH_CGC = headerformMOD.cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
                    header.PAH_END = headerformMOD.endereco;
                    header.PAH_TEL = headerformMOD.telefone;
                    header.PAH_EMAILF = headerformMOD.email;
                    header.PAH_BAIXAD = headerformMOD.baixa;
                    //header.PAH_CODGES = headerformMOD.codGestor;

                    header.D_E_L_E_T_ = " ";
                    //header.R_E_C_N_O_ = GetRecnoPah();

                    conn.PAH010.Add(header);
                    conn.SaveChanges();
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

        public List<HeaderForMOD> ListaContDepart(string cDepUser)
        {
            List<HeaderForMOD> listaDepControls = new List<HeaderForMOD>();

            using (var conn = new DADOSADVEntities())
            {
                try
                {
                    var controlDep = from h in conn.PAH010
                                     where h.PAH_DEPUSE.ToUpper().Equals(cDepUser.ToUpper())
                                     select h;

                    foreach (var control in controlDep)
                    {
                        var listaDepControl = new HeaderForMOD();

                        listaDepControl.recno = control.R_E_C_N_O_;
                        listaDepControl.filial = control.PAH_FILIAL;
                        listaDepControl.numControl = Convert.ToInt32(control.PAH_CONTRO);
                        listaDepControl.retirada = control.PAH_RETIRA;
                        listaDepControl.user = control.PAH_USER;
                        listaDepControl.numUser = control.PAH_NUMUSE;
                        listaDepControl.depUser = control.PAH_DEPUSE;
                        listaDepControl.funUSer = control.PAH_FUNUSE;
                        listaDepControl.emalUser = control.PAH_EMAIL;
                        listaDepControl.dtSolicit = convertDt(control.PAH_DTSOLI);
                        listaDepControl.prazo = convertDt(control.PAH_PRAZO);
                        listaDepControl.proPrazoUm = convertDt(control.PAH_PRAZOU);
                        listaDepControl.proPrazoDois = convertDt(control.PAH_PRAZOS);
                        listaDepControl.unidade = control.PAH_UNIDAD;
                        listaDepControl.tipo = control.PAH_TIPO;
                        listaDepControl.nfOrigem = control.PAH_NFORI;
                        listaDepControl.codCliFor = control.PAH_CLIFOR;
                        listaDepControl.nomeCliFor = control.PAH_NOME;
                        listaDepControl.loja = control.PAH_LOJA;
                        listaDepControl.endereco = control.PAH_END;
                        listaDepControl.telefone = control.PAH_TEL;
                        listaDepControl.email = control.PAH_EMAILF;
                        listaDepControl.cnpj = control.PAH_CGC;
                        listaDepControl.nfRem = control.PAH_NFREM;
                        listaDepControl.nfTerc = control.PAH_NFRET;
                        listaDepControl.nfRet = control.PAH_NFRET;
                        listaDepControl.justificativa = control.PAH_JUST;
                        listaDepControl.baixa = control.PAH_BAIXAD;
                        //listaDepControl.codGestor = control.PAH_CODGES;

                        listaDepControls.Add(listaDepControl);

                    }

                }
                catch (Exception)
                {
                }
            }

            return listaDepControls;
        }

        public List<HeaderForMOD> ListaCont()
        {
            List<HeaderForMOD> listaDepControls = new List<HeaderForMOD>();

            using (var conn = new DADOSADVEntities())
            {
                try
                {
                    var controlDep = from h in conn.PAH010
                                     select h;

                    foreach (var control in controlDep)
                    {
                        var listaDepControl = new HeaderForMOD();

                        listaDepControl.recno = control.R_E_C_N_O_;
                        listaDepControl.filial = control.PAH_FILIAL;
                        listaDepControl.numControl = Convert.ToInt32(control.PAH_CONTRO);
                        listaDepControl.retirada = control.PAH_RETIRA;
                        listaDepControl.user = control.PAH_USER;
                        listaDepControl.numUser = control.PAH_NUMUSE;
                        listaDepControl.depUser = control.PAH_DEPUSE;
                        listaDepControl.funUSer = control.PAH_FUNUSE;
                        listaDepControl.emalUser = control.PAH_EMAIL;
                        listaDepControl.dtSolicit = convertDt(control.PAH_DTSOLI);
                        listaDepControl.prazo = convertDt(control.PAH_PRAZO);
                        listaDepControl.proPrazoUm = convertDt(control.PAH_PRAZOU);
                        listaDepControl.proPrazoDois = convertDt(control.PAH_PRAZOS);
                        listaDepControl.unidade = control.PAH_UNIDAD;
                        listaDepControl.tipo = control.PAH_TIPO;
                        listaDepControl.nfOrigem = control.PAH_NFORI;
                        listaDepControl.codCliFor = control.PAH_CLIFOR;
                        listaDepControl.nomeCliFor = control.PAH_NOME;
                        listaDepControl.loja = control.PAH_LOJA;
                        listaDepControl.endereco = control.PAH_END;
                        listaDepControl.telefone = control.PAH_TEL;
                        listaDepControl.email = control.PAH_EMAILF;
                        listaDepControl.cnpj = control.PAH_CGC;
                        listaDepControl.nfRem = control.PAH_NFREM;
                        listaDepControl.nfTerc = control.PAH_NFRET;
                        listaDepControl.nfRet = control.PAH_NFRET;
                        listaDepControl.justificativa = control.PAH_JUST;
                        listaDepControl.baixa = control.PAH_BAIXAD;

                        listaDepControls.Add(listaDepControl);

                    }

                }
                catch (Exception)
                {
                }
            }

            return listaDepControls;
        }

        public DateTime convertDt(string str)
        {
            DateTime data = new DateTime();

            if (!str.Equals(""))//20140511
            {
                data = Convert.ToDateTime(str.Substring(6, 2) + "/" + str.Substring(4, 2) + "/" + str.Substring(0, 4)).Date;
            }

            return data;
        }

        public HeaderForMOD GetDadosControl(int numCtrl)
        {
            HeaderForMOD header = new HeaderForMOD();

            using (var conn = new DADOSADVEntities())
            {
                try
                {
                    var control = conn.PAH010.Single(x => x.PAH_CONTRO == numCtrl);

                    header.recno = control.R_E_C_N_O_;
                    header.filial = control.PAH_FILIAL;
                    header.numControl = Convert.ToInt32(control.PAH_CONTRO);
                    header.retirada = control.PAH_RETIRA;
                    header.user = control.PAH_USER;
                    header.numUser = control.PAH_NUMUSE;
                    header.depUser = control.PAH_DEPUSE;
                    header.funUSer = control.PAH_FUNUSE;
                    header.emalUser = control.PAH_EMAIL;
                    header.dtSolicit = convertDt(control.PAH_DTSOLI);
                    header.prazo = convertDt(control.PAH_PRAZO);
                    header.proPrazoUm = convertDt(control.PAH_PRAZOU);
                    header.proPrazoDois = convertDt(control.PAH_PRAZOS);
                    header.unidade = control.PAH_UNIDAD;
                    header.tipo = control.PAH_TIPO;
                    header.nfOrigem = control.PAH_NFORI;
                    header.codCliFor = control.PAH_CLIFOR;
                    header.nomeCliFor = control.PAH_NOME;
                    header.loja = control.PAH_LOJA;
                    header.endereco = control.PAH_END;
                    header.telefone = control.PAH_TEL;
                    header.email = control.PAH_EMAILF;
                    header.cnpj = control.PAH_CGC;
                    header.nfRem = control.PAH_NFREM;
                    header.nfTerc = control.PAH_NFTERC;
                    header.nfRet = control.PAH_NFRET;
                    header.justificativa = control.PAH_JUST;
                    header.baixa = control.PAH_BAIXAD;
                    //header.codGestor = control.PAH_CODGES;
                }
                catch (Exception)
                {
                }
            }

            return header;
        }

        public void baixaCtrl(HeaderForMOD header)
        {
            using (var conn = new DADOSADVEntities())
            {
                var baixa = conn.PAH010.Single(x => x.PAH_CONTRO == header.numControl);

                baixa.PAH_FILIAL = header.filial;
                baixa.PAH_CONTRO = header.numControl;
                baixa.PAH_RETIRA = header.retirada;
                baixa.PAH_USER = header.user;
                baixa.PAH_NUMUSE = header.numUser;
                baixa.PAH_DEPUSE = header.depUser;
                baixa.PAH_FUNUSE = header.funUSer;
                baixa.PAH_EMAIL = header.emalUser;
                baixa.PAH_DTSOLI = header.dtSolicit.ToString("yyyyMMdd");
                baixa.PAH_PRAZO = header.prazo.ToString("yyyyMMdd");
                baixa.PAH_PRAZOU = header.proPrazoUm.ToString("yyyyMMdd");
                baixa.PAH_PRAZOS = header.proPrazoDois.ToString("yyyyMMdd");
                baixa.PAH_UNIDAD = header.unidade;
                baixa.PAH_TIPO = header.tipo;
                baixa.PAH_NFORI = header.nfOrigem;
                baixa.PAH_CLIFOR = header.codCliFor;
                baixa.PAH_NOME = header.nomeCliFor;
                baixa.PAH_LOJA = header.loja;
                baixa.PAH_END = header.endereco;
                baixa.PAH_TEL = header.telefone;
                baixa.PAH_EMAILF = header.email;
                baixa.PAH_CGC = header.cnpj;
                baixa.PAH_NFREM = header.nfRem;
                baixa.PAH_NFRET = header.nfTerc;
                baixa.PAH_NFRET = header.nfRet;
                baixa.PAH_JUST = header.justificativa;
                baixa.PAH_BAIXAD = "T";
                //baixa.PAH_CODGES = header.codGestor;

                conn.SaveChanges();

            }
        }

    }
}

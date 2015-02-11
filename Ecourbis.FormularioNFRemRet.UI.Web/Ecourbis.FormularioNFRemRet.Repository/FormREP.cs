using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.DataAccess;
using System.Data.Entity.Validation;

namespace Ecourbis.FormularioNFRemRet.Repository
{
    public class FormREP
    {
        Int32 numFormulario = 0;

        public string NumForm()
        {
            using (var conn = new DADOSADVEntities())
            {
                var numFormu = conn.PAG010.OrderByDescending(i => i.PAG_COD).FirstOrDefault();

                if (numFormu != null)
                {
                    numFormulario = Convert.ToInt32(numFormu.PAG_COD);
                    numFormulario++;
                }
                else
                {
                    numFormulario++;
                }

                GuardaNum(numFormulario);

                return numFormulario.ToString("00000000");
            }
        }

        public void GuardaNum(Int32 num)
        {
            using (var conn = new DADOSADVEntities())
            {
                var nmForm = new PAG010();

                try
                {
                    nmForm.PAG_FILIAL = "  ";
                    nmForm.PAG_COD = num;
                    nmForm.D_E_L_E_T_ = " ";
                    //nmForm.R_E_C_N_O_ = num;

                    conn.PAG010.Add(nmForm);
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

        public string GetFuncaoFun(string user)
        {
            string funcao = "";
            using (var con = new DADOSADVEntities())
            {
                var FuncFun = con.viewFuncao.Single(x => x.Login.ToLower() == user.ToLower());

                funcao = FuncFun.Funcao.Trim();
            }

            return funcao;
        }
    }
}

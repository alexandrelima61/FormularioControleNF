using Ecourbis.FormularioNFRemRet.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecourbis.FormularioNFRemRet.Repository
{
    public class GestorRep
    {
        public int GetMatUserLogado(string LoginUser)
        {
            int matUserLog = 0;

            using (var conn = new DADOSADVEntities())
            {
                var cMatUser = conn.viewMatUser.SingleOrDefault(x => x.Login_User == LoginUser);

                matUserLog = Int32.Parse(cMatUser.Matricula.Trim());
            }

            return matUserLog;
        }

        public string GetCodGestorUserLog(int matUser)
        {
            string getorUserLog = String.Empty;

            using (var conn = new DADOSADVEntities())
            {
                var gestorUserLog = conn.viewGstEco.SingleOrDefault(x => x.Matricula == matUser);

                getorUserLog = gestorUserLog.CodGestor;
            }

            return getorUserLog;
        }

    }
}

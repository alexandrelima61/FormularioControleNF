using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.Model;
using Ecourbis.FormularioNFRemRet.Repository;

namespace Ecourbis.FormularioNFRemRet.Business
{
    public class HeaderBUS
    {
        headerREP repositorio;
        public void SalvaHeader(HeaderForMOD headerformMOD)
        {
            repositorio = new headerREP();
            repositorio.GuardaHeader(headerformMOD);            
        }

        public List<HeaderForMOD> ListaControleDep(string cDepUser)
        {
            
            List<HeaderForMOD> lista = new List<HeaderForMOD>();

            repositorio = new headerREP();

            lista = repositorio.ListaContDepart(cDepUser);

            return lista;
        }

        public HeaderForMOD visualizaForm(string numControl)
        {
            int numCtrl = Convert.ToInt32(numControl);
            HeaderForMOD header = new HeaderForMOD();

            repositorio = new headerREP();

            header = repositorio.GetDadosControl(numCtrl);

            return header;

        }

        public void baixarControle(HeaderForMOD header)
        {
            repositorio = new headerREP();

            repositorio.baixaCtrl(header);
        }

        public List<HeaderForMOD> ListaControle()
        {
            List<HeaderForMOD> lista = new List<HeaderForMOD>();
            repositorio = new headerREP();

            lista = repositorio.ListaCont();

            return lista;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecourbis.FormularioNFRemRet.Model
{
    [Serializable]
    public class ProdutMOD
    {
        public int Item { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
        public string Controle { get; set; }
        public string prazoRetorno { get; set; }
        public string UnidMedida { get; set; }
        public int recno { get; set; }
        public int log { get; set; }
    }
}

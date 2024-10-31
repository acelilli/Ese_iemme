using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Batch.Models;

namespace Task_Batch.Repo
{
    class CodFisRepo : IRepoLettura<CodiceFiscale>
    {
        private static CodFisRepo instance;
        public static CodFisRepo GetInstance()
        {
            if (instance == null)
                instance = new CodFisRepo();

            return instance;
        }
        private CodFisRepo() { }
        public List<CodiceFiscale> GetAll()
        {
            List<CodiceFiscale> elenco = new List<CodiceFiscale>();
            using (var ctx = new TaskBatchContext())
                elenco = ctx.CodiceFiscales.ToList();

            return elenco;
        }
    }
}

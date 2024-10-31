using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Batch.Repo
{
    internal interface IRepoLettura<T>
    {
        List<T> GetAll();
    }
}

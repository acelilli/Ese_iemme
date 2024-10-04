using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett03_Ese01.Models.DAL
{
    internal interface IDao<T>
    {
        List<T> GetAll();
        T GetById(int t);
    }
}

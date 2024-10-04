using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett03_Ese01.Models.DAL
{
    internal class UtenteDAO : IDao<Utente>
    {
        private static UtenteDAO? instance;
        public static UtenteDAO GetInstance()
        {
            if (instance == null)
                instance = new UtenteDAO();
            return instance;
        }
        public UtenteDAO() { }
        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente GetById(int t)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett03_Ese01.Models.DAL
{
    internal class LibroDAO : IDao<Libro>
    {
        private static LibroDAO? instance;
        public static LibroDAO GetInstance() 
        {
            if (instance == null)
                instance = new LibroDAO();
            return instance; 
        }
        public LibroDAO() { }
        public List<Libro> GetAll()
        {

            using (var ctx = new TaskPrestitoLibriContext())
            {
                var tuttLibri = ctx.Libros.ToList();

                foreach (var lib in tuttLibri)
                {
                    Console.WriteLine(lib);
                }
                return tuttLibri;
            }
        }

        public Libro? GetById(int libroId)
        {
                Libro? lib;
                using (var ctx = new TaskPrestitoLibriContext())
                {
                    lib = ctx.Libros.FirstOrDefault(l => l.LibroId.Equals(libroId));
                    Console.WriteLine(lib);
                }
                return lib; 
        }

        


    }

}

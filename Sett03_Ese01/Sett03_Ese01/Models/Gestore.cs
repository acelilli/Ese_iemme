using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett03_Ese01.Models
{
    class Gestore
    {
        #region CREATE
        public static bool AggiungiLibro(string titolo, string autore, int anno, bool dispo)
        {
            bool inserimento = false;

            Libro lib = new Libro()
                            {
                                Titolo = titolo,
                                Autore = autore,
                                Anno = anno,
                                Disponinile = dispo
                            };

            using (var ctx = new TaskPrestitoLibriContext())
            {
                
                try
                {
                    ctx.Libros.Add(lib);
                    ctx.SaveChanges();
                    inserimento = true;

                    Console.WriteLine("Inserimento effettuato con successo");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return inserimento;
        }


        #endregion
        #region READ
        /// <summary>
        /// Stampa di tutti i prestiti nel db (stampa anche i libri e gli utenti a cui si fa riferimento)
        /// </summary>
        public static void StampaTuttiPrestiti() 
        {
            using (var ctx = new TaskPrestitoLibriContext())
            {
                var tuttiPrestiti = ctx.Prestitos.ToList();

                foreach (var pre in tuttiPrestiti)
                {
                    // LINQ funzione
                    pre.UtenteRifNavigation = ctx.Utentes.Single(u => u.UtenteId == pre.UtenteRif);
                    pre.LibroRifNavigation = ctx.Libros.Single(l => l.LibroId == pre.LibroRif);
                    Console.WriteLine(pre);
                }
            }
        }

        /// <summary>
        /// Stampa di tutti i libri presenti nel db
        /// </summary>
        public static void StampaTuttiLibri()
        {
            using (var ctx = new TaskPrestitoLibriContext())
            {
                var tuttLibri = ctx.Libros.ToList();

                foreach (var lib in tuttLibri)
                {
                    Console.WriteLine(lib);
                }
            }
        }

        public static void StampaTuttiUtenti()
        {
            using (var ctx = new TaskPrestitoLibriContext())
            {
                var tuttiUtenti = ctx.Utentes.ToList();

                foreach (var ut in tuttiUtenti)
                {
                    Console.WriteLine(ut);
                }
            }
        }
        #endregion
    }
}

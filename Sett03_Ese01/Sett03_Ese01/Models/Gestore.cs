using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sett03_Ese01.Models
{
    class Gestore
    {
        #region CREATE
       
        /// <summary>
        /// Aggiunge un nuovo libro al db
        /// </summary>
        /// <param name="titolo"></param>
        /// <param name="autore"></param>
        /// <param name="anno"></param>
        /// <param name="dispo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Aggiunge un nuovo utente al db
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool AggiungiUtente(string nome, string cognome, string email)
        {
            bool inserimento = false;

            Utente ut = new Utente()
            {
                Nome = nome,
                Cognome = cognome,
                Email = email,
            };

            using (var ctx = new TaskPrestitoLibriContext())
            {

                try
                {
                    ctx.Utentes.Add(ut);
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
        /// Stampa tutti i prestiti di un dato utente
        /// </summary>
        /// <param name="userid"></param>
        public static void StampaPrestitoPerUtente(int userid) 
        {
            using (var ctx = new TaskPrestitoLibriContext())
            {
                var elencoPres = ctx.Prestitos.ToList();
                var risultato = from pres in elencoPres
                                where pres.UtenteRif == userid
                                select pres;

                foreach (var pres in risultato)
                {
                    Console.WriteLine(pres);
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

        /// <summary>
        /// Stampa tutti i libri che sono disponibili
        /// </summary>
        public static void StampaLibDispo()
        {
            using(var ctx = new TaskPrestitoLibriContext())
            {
                var elencoLibri = ctx.Libros.ToList();
                var risultato = from lib in elencoLibri
                                where  lib.Disponinile == true
                                select lib;

                foreach (var lib in risultato)
                {
                    Console.WriteLine(lib);
                }
            }
        }

        /// <summary>
        /// Stampa tutti i libri dato un codice univoco
        /// </summary>
        /// <param name="codice"></param>
        public static void StampaPerCodice(string codice)
        {
            using (var ctx = new TaskPrestitoLibriContext())
            {
                Libro? lib = ctx.Libros.FirstOrDefault(l => l.CodiceUni.Equals(codice));
                Console.WriteLine(lib);
            } 
        }

        /// <summary>
        /// Stampa tutti gli utenti nel db
        /// </summary>
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

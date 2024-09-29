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

                    Console.WriteLine("Inserimento del libro effettuato con successo");
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

                    Console.WriteLine("Inserimento del nuovo utente effettuato con successo");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return inserimento;
        }

        /// <summary>
        /// Aggiunge un nuovo prestito al db
        /// -> Stampa una lista di utenti da cui prendere il nome per scegliere a chi è legato il prestito
        ///    Se l'utente non esiste, ne aggiunge uno nuovo
        /// -> Stampa la lista di libri DISPONIBILI al prestito
        ///    Cambia lo stato del libro da disponibile (true) a non disponibile (false)
        /// -> Inserisce una data di ritorno del libro a 30 giorni dalla date del prestito
        /// </summary>
        /// <param name="dataPre"></param>
        /// <param name="dataRit"></param>
        /// <param name="utenteId"></param>
        /// <param name="libroId"></param>
        /// <returns></returns>
        public static bool AggiungiPrestito(DateOnly dataPre, int utenteId, int libroId)
        { bool inserimento = false;

            Prestito pre = new Prestito()
            {
                DataPrestito = dataPre,
                DataRitorno = dataPre.AddDays(30),
                UtenteRif = utenteId,
                LibroRif = libroId,
            };

            using (var ctx = new TaskPrestitoLibriContext())
            {
                Libro? lib = ctx.Libros.FirstOrDefault(l => l.LibroId.Equals(libroId));
                Utente? ut = ctx.Utentes.FirstOrDefault(u=> u.UtenteId.Equals(utenteId));
                if (lib == null && ut == null)
                {
                    Console.WriteLine("Il libro o l'utente selezionato non esiste.\n" +
                        "Impossibile aggiungere un nuovo prestito.");
                }
                else
                {
                    try
                    {
                        ctx.Prestitos.Add(pre);
                        lib.Disponinile = false;
                        ctx.SaveChanges();
                        inserimento = true;

                        Console.WriteLine("Inserimento del prestito effettuato con successo");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    

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

        /// <summary>
        /// Stampa un singolo utente partendo dal suo id
        /// </summary>
        /// <param name="utenteId"></param>
        public static void StampaUtentePerId(int utenteId)
        {
            using (var ctx = new TaskPrestitoLibriContext())
            {
                Utente? ute = ctx.Utentes.FirstOrDefault(u => u.UtenteId.Equals(utenteId));
                Console.WriteLine(ute);
            }
        }

        public static void StampaLibroPerId(int libroId)
        {
            using (var ctx = new TaskPrestitoLibriContext())
            {
                Libro? lib = ctx.Libros.FirstOrDefault(l => l.LibroId.Equals(libroId));
                Console.WriteLine(lib);
            }
        }

        public static void StampaPrestitoPerId(int prestitoId)
        {
            using (var ctx = new TaskPrestitoLibriContext())
            {
                Prestito? pre = ctx.Prestitos.FirstOrDefault(p => p.PrestitoId.Equals(prestitoId));
                Console.WriteLine(pre);
            }
        }
        #endregion
        #region UPDATE

        /// <summary>
        /// Modifica un utente già presente nel db
        /// </summary>
        /// <param name="utenteid"></param>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ModificaUtente(int utenteid, string nome, string cognome, string email)
        {
            bool inserimento = false;

            using (var ctx = new TaskPrestitoLibriContext())
            {
                var utenteEsistente = ctx.Utentes.Find(utenteid);

                if(utenteEsistente == null)
                {
                    Console.WriteLine("L'utente inserito non esiste.\n" +
                        "Vuoi inserire un nuovo utente?");
                }
                else { 

                  try
                  {
                        utenteEsistente.Nome = nome;
                        utenteEsistente.Cognome = cognome;
                        utenteEsistente.Email = email;
                        
                        ctx.SaveChanges();
                        inserimento = true;

                     Console.WriteLine("Modifica dell'utente effettuata con successo");
                  }
                  catch (Exception ex)
                  {
                     Console.WriteLine(ex.Message);
                  }
                }
            }

            return inserimento;
        }

        /// <summary>
        /// Modifica un libro già presente nel db
        /// </summary>
        /// <param name="libroid"></param>
        /// <param name="titolo"></param>
        /// <param name="autore"></param>
        /// <param name="anno"></param>
        /// <returns></returns>
        public static bool ModificaLibro(int libroid, string titolo, string autore, int anno)
        {
            bool inserimento = false;

            using (var ctx = new TaskPrestitoLibriContext())
            {
                var libroEsistente = ctx.Libros.Find(libroid);

                if (libroEsistente == null)
                {
                    Console.WriteLine("Il libro inserito non esiste.\n" +
                        "Vuoi inserire un nuovo libro?");
                }
                else
                {

                    try
                    {
                        libroEsistente.Titolo = titolo;
                        libroEsistente.Autore = autore;
                        libroEsistente.Anno = anno;

                        ctx.SaveChanges();
                        inserimento = true;

                        Console.WriteLine("Modifica del libro effettuata con successo");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return inserimento;
        }

        /// <summary>
        /// Modifica un prestito già presente nel db
        /// </summary>
        /// <param name="prestitoId"></param>
        /// <param name="utenteId"></param>
        /// <param name="libroId"></param>
        /// <param name="dataRitorno"></param>
        /// <returns></returns>
        public static bool ModificaPrestito(int prestitoId, int utenteId, int libroId, DateOnly dataRitorno)
        {
            bool inserimento = false;

            using (var ctx = new TaskPrestitoLibriContext())
            {
                var prestitoEsistente = ctx.Prestitos.Find(prestitoId);

                if (prestitoEsistente == null)
                {
                    Console.WriteLine("Il prestito inserito non esiste.\n" +
                        "Vuoi inserire un nuovo prestito?");
                }
                else
                {
                    try
                    {
                        Libro? lib = ctx.Libros.FirstOrDefault(l => l.LibroId.Equals(libroId));
                        if (lib != null) {
                            prestitoEsistente.UtenteRif = utenteId;
                            prestitoEsistente.LibroRif = libroId;
                            prestitoEsistente.DataRitorno = dataRitorno;

                            // se la data di ritorno è maggiore a quella odierna, il libro non è disponibile
                            // se la data di ritrno è uguale o minore a quella odierna, il libro è disp
                                if (dataRitorno > DateOnly.FromDateTime(DateTime.Now))
                                {
                                    lib.Disponinile = false;
                                } else if (dataRitorno <= DateOnly.FromDateTime(DateTime.Now))
                                {
                                    lib.Disponinile = true;
                                }

                            ctx.SaveChanges();
                            inserimento = true;

                            Console.WriteLine("Prestito aggiornato con successo");
                                }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return inserimento;
        }
        #endregion
    }
}

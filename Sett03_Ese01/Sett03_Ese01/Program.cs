using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sett03_Ese01.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Sett03_Ese01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Requisiti Funzionali
            // 1. -------------- CRUD ------------------
            // X -> CREATE per Libri
            // X -> CREATE per Utenti
            // X -> CREATE per Prestito
            //-----------------------
            // X -> READ per Libri
            // X -> READ per Utenti
            // X -> READ per Prestiti
            //----------------------------------
            // X -> UPDATE per Utenti
            // X -> UPDATE per Libri
            // X -> UPDATE per Prestiti

            // 2. -------------- LINQ ------------------
            // X -> READ per libri disponibili
            // X -> READ per libri tramite codice
            // X -> READ dei prestiti dato un utente
            // -> READ per gli utenti con il maggior numero di prestiti

            // 2.Ricerche Avanzate con LINQ
            // L'applicazione dovrà permettere ricerche avanzate sui dati, 
            //   - identificare gli utenti con il maggior numero di prestiti attivi.
            //   Queste ricerche
            //   dovranno essere effettuate utilizzando LINQ per manipolare i dati caricati in memoria
            //   dall'applicazione.
            // 3.Gestione dei Prestiti:
            //  X - Implementare una logica per gestire il prestito dei libri agli utenti, 
            //  X - assicurandosi di aggiornare lo stato di disponibilità del libro
            //  X - registrare adeguatamente il prestito nel sistema


            #region Stampe
            // Gestore.StampaTuttiPrestiti();
            // Gestore.StampaTuttiLibri();
            // Gestore.StampaTuttiUtenti();

            // stampa SOLO libri disponibili
            // Gestore.StampaLibDispo();

            // Stampa libro per codice
            //Gestore.StampaPerCodice("7A9D41F6-944E-48DA-A5BA-918D7FEF1139");

            // Stampa  i prestiti di un dato utente
            // Gestore.StampaPrestitoPerUtente(1);
            // Gestore.StampaPrestitoPerUtente(5);

            // Stampa l'utente con il maggior numero di prestiti ATTIVI (non ancora scaduti)
            #endregion

            #region Inserimento libro
            //Console.WriteLine("Inserisci Titolo:");
            //string titolo = Console.ReadLine();
            //Console.WriteLine("Inserisci Autore:");
            //string autore = Console.ReadLine();
            //Console.WriteLine("Inserisci Anno uscita:");
            //int anno = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Premi 1 se disponibile, premi 0 se non disponibile");
            //bool disp = Convert.ToBoolean(Console.ReadLine());

            //Gestore.AggiungiLibro(titolo, autore, anno, disp);
            #endregion

            #region inserimento Utente

            //Console.WriteLine("Inserisci il nome:");
            //string nome = Console.ReadLine();
            //Console.WriteLine("Inserisci cognome:");
            //string cognome = Console.ReadLine();
            //Console.WriteLine("Inserisci l'e-mail:");
            //string mail = Console.ReadLine();

            //Gestore.AggiungiUtente(nome, cognome, mail);

            #endregion

            #region inserimento Prestito

            //Console.WriteLine("Inserisci la data del prestito:");
            //DateOnly dataPre = DateOnly.Parse(Console.ReadLine());
            //Console.WriteLine("Inserisci l'indice dell'utente scelto:");
            //int utenteId = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Inserisci l'indice del libro scelto:");
            //int libroId = Convert.ToInt32(Console.ReadLine());

            //Gestore.AggiungiPrestito(dataPre, utenteId, libroId);

            #endregion

            #region modifica Utente

            //Console.WriteLine("Ecco l'elenco degli utenti che puoi modificare:");
            //Gestore.StampaTuttiUtenti();
            //Console.WriteLine("Inserisci il numero di indice dell'utente che vuoi modificare:");
            //int utenteId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Stai modificando l'utente ");
            //Gestore.StampaUtentePerId(utenteId);
            //Console.WriteLine("Procedura di modifica iniziata.\n" +
            //    "Inserisci il nuovo nome:");
            //string nome = Console.ReadLine();
            //Console.WriteLine("Inserisci il nuovo cognome:");
            //string cognome = Console.ReadLine();
            //Console.WriteLine("Inserisci la nuova e-mail:");
            //string mail = Console.ReadLine();

            //Gestore.ModificaUtente(utenteId, nome, cognome, mail);

            #endregion

            #region modifica Libro

            //Console.WriteLine("Ecco l'elenco dei libri che puoi modificare:");
            //Gestore.StampaTuttiLibri();
            //Console.WriteLine("Inserisci il numero di indice del libro che vuoi modificare:");
            //int libroid = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Stai modificando il libro:");
            //Gestore.StampaLibroPerId(libroid);
            //Console.WriteLine("Procedura di modifica iniziata.\n" +
            //    "Inserisci il nuovo titolo:");
            //string titolo = Console.ReadLine();
            //Console.WriteLine("Inserisci il nuovo autore:");
            //string autore = Console.ReadLine();
            //Console.WriteLine("Inserisci il nuovo anno:");
            //int anno = Convert.ToInt32(Console.ReadLine());

            //Gestore.ModificaLibro(libroid, titolo, autore, anno);

            #endregion

            #region modifica Prestito
            ////-- Fase 1: elenco dei prestiti, selezione del prestito da modificare
            //Console.WriteLine("Ecco l'elenco dei prestiti che puoi modificare:");
            //Gestore.StampaTuttiPrestiti();
            //Console.WriteLine("Inserisci il numero di indice del prestito che vuoi modificare:");
            //int prestitoId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Stai modificando il prestito: ");
            //Gestore.StampaPrestitoPerId(prestitoId);
            //// Fase 2: elenco degli utenti, selezione dell'utente da associare
            //Console.WriteLine("Ecco l'elenco degli utenti che puoi associare al prestito:");
            //Gestore.StampaTuttiUtenti();
            //Console.WriteLine("Inserisci il numero di indice dell'utente che vuoi associare al prestito:");
            //int utenteId = Convert.ToInt32(Console.ReadLine());
            //// Fase 3: elenco dei libri, selezione del libro da associare
            //Console.WriteLine("Ecco l'elenco dei libri disponibili che puoi associare al prestito:");
            //Gestore.StampaLibDispo();
            //Console.WriteLine("Inserisci il numero di indice del libro che vuoi associare al prestito:");
            //int libroId = Convert.ToInt32(Console.ReadLine());
            
            
            //// Fase 4: aggiornare la data di restituzione del libro
            //Console.WriteLine("Procedura di modifica iniziata.\n" +
            //    "Inserisci la data di restituizione del libro aggiornata:");
            //DateOnly dataRitorno = DateOnly.Parse(Console.ReadLine());

            //Gestore.ModificaPrestito(prestitoId, utenteId, libroId, dataRitorno);

            #endregion

            #region elimina Utente
            #endregion

            #region elimina Libro
            #endregion
        }
    }
}

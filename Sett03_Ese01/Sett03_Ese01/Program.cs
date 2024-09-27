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
            //  1.Operazioni CRUD per ogni Entità
                // -> CREATE per Libri
                // -> CREATE per Utenti
                // -> READ per Libri
                // -> READ per Utenti
                // -> READ per Prestiti
                //----------------------------------
                // -> READ per libri disponibili
                // -> READ per libri tramite codice

            // 2.Ricerche Avanzate con LINQ
            // L'applicazione dovrà permettere ricerche avanzate sui dati, 
            //   X - trovare tutti i libri disponibili per il prestito,
            //   - elencare i prestiti in corso per un dato utente,
            //   - identificare gli utenti con il maggior numero di prestiti attivi.
            //   Queste ricerche
            //   dovranno essere effettuate utilizzando LINQ per manipolare i dati caricati in memoria
            //   dall'applicazione.
            // 3.Gestione dei Prestiti:
            //  - Implementare una logica per gestire il prestito dei libri agli utenti, 
            //  - assicurandosi di aggiornare lo stato di disponibilità del libro
            //  - registrare adeguatamente il prestito nel sistema


            #region Stampe
            // Gestore.StampaTuttiPrestiti();
            // Gestore.StampaTuttiLibri();
            // Gestore.StampaTuttiUtenti();

            // stampa SOLO libri disponibili
            // Gestore.StampaLibDispo();

            //Gestore.StampaPerCodice("7A9D41F6-944E-48DA-A5BA-918D7FEF1139");

            Gestore.StampaPrestitoPerUtente(5);
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
            #endregion
        }
    }
}

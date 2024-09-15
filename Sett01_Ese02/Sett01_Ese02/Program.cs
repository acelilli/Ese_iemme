using Sett01_Ese02.classes;

namespace Sett01_Ese02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // APPLICAZIONE STUDENTI
            // CLASSE STUDENTE 
            //       Nome
            //       Cognome
            //       Voto
            // ----- Inserimento nuovo studente in LISTA ARRAY
            // ----- Visualizzare tutti gli stuenti
            // ----- Modificare i dati di uno studente esistente
            // ----- Filtrare e isualizzare gli studenti in base ai voti
            //             -> Voto massimo e voto minimo
            // ----- Eliminare uno studente
            //           -> in base al nome

            bool insStudente = true;

            // List<Studente> elencoStudenti = new List<Studente>();

            while (insStudente) {
                Console.WriteLine("------------- GESTIONE STUDENTI ------------- ");
                Console.WriteLine("Cosa vuoi fare?\n> Premi INS per inserire un nuovo studente\n> Premi LI per visualizzare tutti gli studenti" +
                    "\n> Premi MOD per modificare i dati di uno studente esistente\n> Premi FI per filtrare gli studenti per voti" +
                    "\n> Premi DEL per eliminare uno studente\n> Premi Q per uscire");
                string? inputUtente = Console.ReadLine();
                switch (inputUtente.ToUpper()) {
                    case "INS":
                        #region INSERIMENTO
                        Console.WriteLine("------------- Inserisci un nuovo studente -------------");
                        Console.Write("Inserisci nome: ");
                        string? inputNome = Console.ReadLine();
                        Console.Write("Inserisci cognome: ");
                        string? inputCognome = Console.ReadLine();
                        Console.Write("Inserisci voto: ");
                        //double inputVoto = Convert.ToDouble(Console.ReadLine());
                        string? inputVoto = Console.ReadLine();
                        double doubleVoto = 0d;
                        if(inputNome == ""|| inputCognome == "" || inputVoto == null) 
                        { 
                            
                            Console.WriteLine("Uno o più valori inseriti non erano validi.\n" +
                                "Il menù verrà riavviato.");
                        } else
                        {
                            try
                            {
                                doubleVoto = Convert.ToDouble(inputVoto);
                                if(doubleVoto >= 0 && doubleVoto <= 10) 
                                { 
                                    Studente stu = new Studente();
                                    stu.Nome = inputNome;
                                    stu.Cognome = inputCognome;
                                    stu.Voto = doubleVoto;
                                    stu.AggiungiStudente(stu);
                                } else
                                {
                                    Console.WriteLine("ATTENZIONE! Il valore del voto deve essere un valore compreso tra 0 e 10.");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Valore voto non valido.\n" +
                                    "Il menù verrà riavviato.");
                            }
                        }
                        #endregion
                        break;
                        case "LI":
                        Studente.StampaElenco();
                        // metodo STATICO all'interno di Studente
                        break;
                        case "MOD":
                        Studente.ModificaStudente();
                        break;
                        case "FI":
                        // Metodo STATICO all'interno di Studente che prende come parametri due stringhe (i voti)
                        // non funziona
                        //Console.WriteLine("Filtra gli studenti per il valore dei voti.");
                        //string? inputVotoA = Console.ReadLine();
                        //string? inputVotoB = Console.ReadLine();
                        //Studente.FiltroVoti(inputVotoA, inputVotoB);
                        break;
                        case "DEL":
                        Studente.EliminaStudente();
                        break;
                    case "Q":
                        Console.WriteLine("Il programma verrà chiuso.");
                        insStudente = !insStudente;
                        break;
                    default:
                        Console.WriteLine("ATTENZIONE! Non è un carattere valido.");
                        break;
                }
            }


        }
    }
}

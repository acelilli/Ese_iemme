using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sett01_Ese02.classes
{
    internal class Studente
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public double Voto { get; set; } = 0;
        public static List<Studente> ElencoStudenti { get; set; } = new List<Studente>(); // AGGREGAZIONE => esiste anche senza elementi al suo interno
                                                                                          // statico => accessibile anche senza avere una istanza della clasese

        #region CRUD

        //Create
        // Passo come parametro objStu e lo aggiunge ad ElencoStudenti
        public void AggiungiStudente(Studente objStu)
        {
            ElencoStudenti.Add(objStu);
        }

        //Read
        // No parametri, metodo statico (non ha bisogno si una nuova istanza di studenti)
        // Se il numero di oggetti in lista è diverso da zero allora stampa la lista degli studenti con un ciclo forEach
        // altrimenti messaggio di errore
        public static void StampaElenco() {
            if (ElencoStudenti.Count != 0)
            {
                int i = 1;
                Console.WriteLine("Ecco la lista degli studenti:");
                foreach (Studente stu in ElencoStudenti)
                {
                    Console.WriteLine($"{i++}. Studente {stu.Nome} {stu.Cognome}, con votazione {stu.Voto}");
                }
            }
            else
            {
                Console.WriteLine("Non è stato salvato alcuno studente.");
            }
        }

        //Update
        // no parametri
        // Più o meno come la lista: se il numero di oggetti dentro ElencoStudenti è diverso da zero allora chiede input del num. di elenco che si vuole modificare
        // Prova a trasformare l'input in int, se riesce allora ciclo for sulla lista
        // Controlla se il num passato in input -1  corrisponde all'indice nella lista e chiede conferma
        // Sì modifica ciascun campo
        // No e default ricomincia il menù
        public static void ModificaStudente()
        {
            if (ElencoStudenti.Count != 0)
            {
                Console.WriteLine("Quale studente vuoi modificare?\n Digita il numero corrispondente all'elenco.");
                StampaElenco();
                string? inputIndice = Console.ReadLine();
                // invece di passare objStu come paramentro di ModificaStudenti dico che objStu è il primo(0) dell'indice di ElencoStudenti
                Studente objStu = ElencoStudenti[0];
                try
                {
                    int numStu = Convert.ToInt32(inputIndice);
                    for (int i = 0; i < ElencoStudenti.Count; i++)
                    {
                        if (i == numStu - 1)
                        {
                            Console.WriteLine($"Vuoi modificare lo studente {objStu.Nome} {objStu.Cognome}? Y/N");
                            string? inputConferma = Console.ReadLine();
                            if (inputConferma != null)
                            {
                                switch (inputConferma.ToUpper())
                                {
                                    case "Y":
                                        string? nuovoNome = null!;
                                        string? nuovoCognome = null!;
                                        string? nuovoVoto = null!;
                                        Console.Write("Modifica nome:");
                                        nuovoNome = Console.ReadLine();
                                        Console.Write("Modifica cognome:");
                                        nuovoCognome = Console.ReadLine();
                                        Console.Write("Modifica voto:");
                                        nuovoVoto = Console.ReadLine();
                                        double modVoto = 0;
                                        try
                                        {
                                            modVoto = Convert.ToDouble(nuovoVoto);
                                            objStu.Nome = nuovoNome;
                                            objStu.Cognome = nuovoCognome;
                                            objStu.Voto = modVoto;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("ATTENZIONE! Valore voto non valido.\n il programma verrà riavviato.");
                                        }
                                        break;
                                    case "N":
                                        Console.WriteLine("Il menù verrà riavviato.");
                                        break;
                                    default:
                                        Console.WriteLine("Carattere non valido.");
                                        break;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("ATTENZIONE! Il valore inserito non è corretto");
                } 
            }
            else
            {
                Console.WriteLine("Non sono stati registrati degli studenti.");

            }
        }

        //Delete per NOME
        // Input utente che ricerca un nome nell'Elenco Studenti
        // Input utente che ricerca ANCHE il cognome nella ricerca utenti
        // SE uno studente STU CON QUEL NOME E COGNOME ESISTE ALLORA
        // CHiede conferma se vuoi modificare studente stu
        // Altrimenti esce
        public static void EliminaStudente()
        {
            if(ElencoStudenti.Count > 0) { 
            Console.WriteLine("Quale studente vuoi cancellare?\nInizia digitando il nome.");
            string? inputNome = Console.ReadLine();
            Console.WriteLine("Digita anche il cognome:");
            string? inputCognome = Console.ReadLine();
            if (ElencoStudenti.Count > 0 && !string.IsNullOrEmpty(inputNome) && !string.IsNullOrEmpty(inputCognome)) 
            { 
                foreach (Studente stu in ElencoStudenti)
                {
                    if(stu.Nome == inputNome && stu.Cognome == inputCognome)
                    {
                        string? inputConferma;
                        Console.WriteLine($"Stai per eliminare {stu.Nome} {stu.Cognome}.\nConfermi? Y/N"); 
                        inputConferma = Console.ReadLine();
                            if (!string.IsNullOrEmpty(inputConferma)) { 
                        switch (inputConferma.ToUpper()) 
                        {
                            case "Y":
                                ElencoStudenti.Remove(stu);
                                Console.WriteLine("Studente eliminato con successo.\nIl menù verrà riavviato.");
                                    break;
                                case "N":
                                Console.WriteLine("Il menù verrà riavviato.");
                                break;
                            default:
                                Console.WriteLine("Carattere non valido.\nIl menù verrà riavviato.");
                                break;
                        }
                        break;
                    } else 
                        {
                            Console.WriteLine("Non esistono studenti con il nome e cognome inseriti.\n");
                        }
                        }
                }
            } 
            else 
            {
                Console.WriteLine("I caratteri digitati non sono validi.");
            }
            } else
            {
                Console.WriteLine("Non è stato registrato nessuno studente in elenco.");
            }
        }
        #endregion

        #region FILTRI
        // Filtro per voto minimo e massimo 
        //public static void FiltroVoti(string? inputVotoA, string? inputVotoB)
        //{
        //    if (string.IsNullOrEmpty(inputVotoA) || string.IsNullOrEmpty(inputVotoB)) 
        //    {
        //        Console.WriteLine("ATTENZIONE! I valori inseriti non sono validi.\nIl programma verrà riavviato.");
        //    } else
        //    {
        //        try 
        //        {
        //            double votoA = Convert.ToDouble(inputVotoA);
        //            double votoB = Convert.ToDouble(inputVotoB);
        //            if (ElencoStudenti.Count > 0) 
        //            {
        //                // lista cheandrò a popolare con gli studenti filtrati
        //                List<Studente> studentiFiltrati = new List<Studente>();
        //                foreach(Studente stu in ElencoStudenti)
        //                {
        //                    if (stu.Voto >= votoA && stu.Voto <= votoB)
        //                    {
        //                        studentiFiltrati.Add(stu);

        //                        if (studentiFiltrati.Count > 0) {
        //                        Console.WriteLine("Studenti filtrati per voto: ");
        //                            studentiFiltrati.Sort();

        //                        foreach (Studente fil in studentiFiltrati)
        //                        {
        //                            Console.WriteLine($"{fil.Voto} - {fil.Nome} {fil.Cognome}");
        //                        }
        //                        } else
        //                        {
        //                            Console.WriteLine("Non è stato possibile filtrare gli studenti.\n" +
        //                                "Controlla che siano stati registrati degli studenti o di aver inserito dei valori validi.");
        //                        }
        //                    }
        //                    else 
        //                    {
        //                        Console.WriteLine("Impossibile filtrare gli studenti.");
        //                    }
        //                }

        //            }
        //        } catch 
        //        {
        //            Console.WriteLine("Impossibile filtrare gli studenti.\nControlla che ci siano studenti in lista.");
        //                };
        //    }
        //}

            // Ricerca per nome o cognome

        #endregion
    }
}

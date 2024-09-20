namespace Set01_Ese01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MENU -> Benvenuto
            // Che vuoi fare? INSERIRE VALORI
            //                         Scegliere operazione
            //                                             Somma, sottrazione, moltiplicazione, divisione
            //                                             RETURN => Risultato
            //                 QUIT
            //  GESTIONE ERRORI:
            //                  - Inserimenti non validi (caratteri)
            //                  - Divisione per zero
            //  OPERAZIONI AGGIUNTIVE:
            //                  - Potenza e radice quadrata 
            // ----------------------------------------------------------------------------------
            
            bool insAttivo = true;

            // int num = Convert.ToInt32(Console.ReadLine());

            while (insAttivo) {
                Console.WriteLine("-------------- CALCOLATRICE --------------");
                Console.WriteLine("Benvenuto, cosa vuoi fare? \nA> Inserisci valori & Esegui operazioni \nQ> Esci");
                string? inputUtente = Console.ReadLine();
               
                // SWITCH MENU PRINCIPALE
                switch (inputUtente.ToUpper()) {
                    
                    case "A":
                        Console.Write("Inserisci il primo valore: ");
                        string? inputX = Console.ReadLine();
                        int x = 0;
                        
                        Console.Write("Inserisci il secondo valore: ");
                        string? inputY = Console.ReadLine();
                        int y = 0;
                        // Prova a convertire i inputX e inputY in INT 
                        // se riesce a convertirli -> start menù operazioni
                        try
                        {
                            x = Convert.ToInt32(inputX);
                            y = Convert.ToInt32(inputY);

                            // SWITCH CASE -> Menù operazioni ---
                            Console.WriteLine("Che operazione vuoi eseguire? \nS> Somma\nZ> Sottrazione\nM> Moltiplicazione\nD> Divisione\nP> Potenza\nR> Radice");
                            string? inputOp = Console.ReadLine().ToUpper();
                            // --- variabili double per radice e potenza
                            double doubleX = (int)Convert.ToDouble(x);
                            double doubleY = (int)Convert.ToDouble(y);

                            switch (inputOp)
                            {
                                case "S":
                                    Console.WriteLine("Calcolo somma in corso...");
                                    Console.WriteLine($"Il risultato della tua operazione {x} + {y} = " + (x + y));
                                    break;
                                case "Z":
                                    Console.WriteLine("Calcolo sottrazione in corso...");
                                    Console.WriteLine($"Il risultato della tua operazione {x} - {y} =" + (x - y));
                                    break;
                                case "M":
                                    Console.WriteLine("Calcolo moltiplicazione in corso...");
                                    Console.WriteLine($"Il risultato della tua operazione {x} * {y} =" + (x * y));
                                    break;
                                case "D":
                                    Console.WriteLine("Calcolo Divisione in corso...");

                                    if (x == 0 || y == 0)
                                    {
                                        Console.WriteLine("ATTENZIONE! Non è possibile eseguire l'operazione.");
                                        Console.WriteLine("Il programma verrà riavviato");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Il risultato della tua operazione {x} / {y} =" + (x / y));
                                    }
                                    break;
                                case "P":
                                    double potenza = Math.Pow(doubleX, doubleY);
                                    Console.WriteLine("Calcolo della potenza in corso...");
                                    Console.WriteLine($"La potenza di {x} per {y} = {potenza}");
                                    break;
                                case "R":
                                    double radiceX = Math.Sqrt(doubleX);
                                    double radiceY = Math.Sqrt(doubleY);
                                    Console.WriteLine("Calcolo radice quadrata dei tuoi valori in corso...");
                                    Console.WriteLine($"La radice quadrata di {x} è " + radiceX );
                                    Console.WriteLine($"La radice quadrata di {y} è " + radiceY);
                                    break;
                                default:
                                    Console.WriteLine("Carattere non valido");
                                    break;
                            }

                        } catch
                        {
                            Console.WriteLine("Uno dei tuoi input non era un valore numerico");
                            Console.WriteLine("Impossibile eseguire le operazioni.");
                        }
                       
                        break;
                    case "Q":
                        Console.WriteLine("Il programma verrà chiuso.");
                        insAttivo = !insAttivo;
                        break;
                    default:
                        Console.WriteLine("Carattere non valido.");
                        break;
                } 
                
            }
        }
    }
}

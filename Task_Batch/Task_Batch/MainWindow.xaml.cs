using Microsoft.Data.SqlClient;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task_Batch.Models;
using Task_Batch.Repo;
using Newtonsoft.Json.Bson;
using Path = System.IO.Path;
using JsonSerializer = System.Text.Json.JsonSerializer;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Task_Batch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo per prendere il get all dal repo
        /// </summary>
        /// <returns></returns>
        //private List<Persona> GetPersonas()
        //{
        //    return PersonaRepo.GetInstance().GetAll();
        //}

        /// <summary>
        /// Metodo per mostrare tutti i record di persona all'interno della tabella
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_mostra_Click(object sender, RoutedEventArgs e)
        {
            dgPersona.ItemsSource = PersonaRepo.GetInstance().GetAll();
        }

        /// <summary>
        /// Metodo per scrivere tutti i record di persona all'interno di un file csv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_scrivi_persona_Click(object sender, RoutedEventArgs e)
        {
            string path = "C:\\Users\\Utente\\Desktop\\persone.csv";
            //string? path = Path.GetDirectoryName(typeof(MainWindow).Assembly.Location);
            
            var persone = PersonaRepo.GetInstance().GetAll();
            string contenuto = JsonSerializer.Serialize(persone);

            try
            {
                if (path is not null) 
                {
                    using (StreamWriter sw = new StreamWriter(path)) 
                    { 
                        sw.WriteLine(contenuto);
                        sw.Close();
                    }
                }
                MessageBox.Show("Operazione eseguita con successo");

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Metodo per prendere il get all dal repo
        /// </summary>
        /// <returns></returns>
        //private List<CodiceFiscale> GetCF()
        //{
        //    return CodFisRepo.GetInstance().GetAll();
        //}

        /// <summary>
        /// Metodo per mostrare tutti i record di CodiceFiscale all'interno della tabella
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_mostra_CF_Click(object sender, RoutedEventArgs e)
        {
            dgCF.ItemsSource = CodFisRepo.GetInstance().GetAll();
        }

        private void btn_scrivi_cf_Click(object sender, RoutedEventArgs e)
        {
            string path = "C:\\Users\\Utente\\Desktop\\codice_fiscale.csv";
            //string? path = Path.GetDirectoryName(typeof(MainWindow).Assembly.Location);

            var codicif = CodFisRepo.GetInstance().GetAll();
            string contenuto = JsonSerializer.Serialize(codicif);

            try
            {
                if (path is not null)
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(contenuto);
                        sw.Close();
                    }
                }
                MessageBox.Show("Operazione eseguita con successo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_to_mongoDb_Click(object sender, RoutedEventArgs e)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("task_batch");
            var coll = database.GetCollection<BsonDocument>("Persone");

            //Lettura del file csv
            string Personepath = "C:\\Users\\Utente\\Desktop\\persone.csv";
            string CFpath = "C:\\Users\\Utente\\Desktop\\codice_fiscale.csv";

            try 
            {
                //string datiPersone;
                //string datiCF;
                //using (StreamReader psr = new StreamReader(Personepath)) 
                //{
                //    string? perLine;
                //    while ((perLine = psr.ReadLine()) != null) 
                //    {
                //        datiPersone = perLine;
                //    }

                //};

                //using (StreamReader cfsr = new StreamReader(CFpath)) 
                //{
                //    string? cfLine;
                //    while ((cfLine = cfsr.ReadLine()) != null) 
                //    {
                //        datiCF = cfLine;
                //    }
                //};

                var jsonPersone = File.ReadAllText(Personepath);
                var persone = JsonConvert.DeserializeObject<List<Persona>>(jsonPersone);

                var jsonCF = File.ReadAllText(CFpath);
                var cf = JsonConvert.DeserializeObject<List<CodiceFiscale>>(jsonCF);

                //insermento dei dati in mongo
                if (persone is not null && cf is not null)
                {
                    foreach (var p in persone)
                    {
                        var codice = cf.FirstOrDefault(c => c.PersonaRif == p.PersonaId);
                        var documento = new BsonDocument
                        {
                            {"nome", p.Nome},
                            {"cognome", p.Cognome},
                            {"email", p.Email},
                            {"telefono", p.Telefono},
                            {"cod_fis", new BsonDocument
                                {
                                    {"codice", codice?.CodFis ?? string.Empty},
                                    { "data_emis", codice?.DataEmissione.ToString("yyyy-MM-dd") ?? string.Empty }, 
                                    { "data_scad", codice?.DataScadenza.ToString("yyyy-MM-dd") ?? string.Empty }
                                }
                            }
                        };
                        coll.InsertOne(documento);
                    }
                    MessageBox.Show("Dati inseriti correttamente");
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }

        }
    }
}
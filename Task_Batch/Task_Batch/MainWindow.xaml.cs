using Microsoft.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.Json;
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
using Path = System.IO.Path;

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
    }
}
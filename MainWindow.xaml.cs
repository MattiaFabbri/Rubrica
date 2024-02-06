using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Rubricawpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persona> Persone = new List<Persona>();
        List<Contatto> Contatti = new List<Contatto>();

        public MainWindow()
        {
            InitializeComponent();

            string[] dati = new string[3];
            StreamReader ReaderPersone = new StreamReader("Persone.csv");
            StreamReader ReaderContatti = new StreamReader("Contatti.csv");
            string stringPersona = ReaderPersone.ReadLine();
            string stringContatto = ReaderContatti.ReadLine();

            //creazione lista Persone
            do
            {

                dati = stringPersona.Split(";");
                Persone.Add(new Persona(Convert.ToInt32(dati[0]), dati[1], dati[2]));
                stringPersona = ReaderPersone.ReadLine();
            } while (!ReaderPersone.EndOfStream);

            //creazione lista contatti

            do
            {
                dati = stringContatto.Split(";");
                int idPersona;

                if (int.TryParse(dati[0], out idPersona))
                {
                    Contatti.Add(new Contatto(idPersona, dati[1], dati[2]));
                }
                else
                {
                    Console.WriteLine($"Errore di conversione per l'ID della persona nei contatti: {dati[0]}");
                }

                stringContatto = ReaderContatti.ReadLine();
            } while (!ReaderContatti.EndOfStream);
            dgPersone.ItemsSource = Persone;
            //dgContatti.ItemsSource = Contatti;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgPersone_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Persona p = e.Row.Item as Persona;
        }

        private void dgContatti_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Contatto c = e.Row.Item as Contatto;
        }

        private void dgContatti_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            List<Contatto> ContattiPersona = new List<Contatto>();
            Persona personaSelezionata = dgPersone.SelectedItem as Persona;
            foreach (Contatto a in Contatti)
            {
                if(a.GetId()== personaSelezionata.GetId())
                {
                    ContattiPersona.Add(a);
                }
            }
            dgContatti.ItemsSource = ContattiPersona;
        }
    }
}
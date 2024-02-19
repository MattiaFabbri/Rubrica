using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Rubricawpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Persone ElencoPersone;
        Contatti ElencoContatti;

        public MainWindow()
        {
            InitializeComponent();
            ElencoPersone = new Persone("Persone.csv");
            ElencoContatti = new Contatti("Contatti.csv");
            dgPersone.ItemsSource = ElencoPersone;
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

            foreach (Contatto contatto in ElencoContatti)
            {
                if (contatto.GetId() == personaSelezionata.idPersona)
                {
                    ContattiPersona.Add(contatto);
                }
            }

            dgContatti.ItemsSource = ContattiPersona;
        }
    }
}
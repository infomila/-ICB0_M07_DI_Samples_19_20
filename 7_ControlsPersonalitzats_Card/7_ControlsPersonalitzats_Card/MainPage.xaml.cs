using _7_ControlsPersonalitzats_Card.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _7_ControlsPersonalitzats_Card
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Persona p;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //p = new Persona(12, "Paco", "http://www.pokexperto.net/pokemongo/pokemon/charizard.png");
            //fitPersona.LaPersona = p;
            // Omplim la llista de persones
            lsvFitxes.ItemsSource = Persona.GetLlistaPersones();

            Persona.GetLlistaPersones()[2].Rate = 5;
            Persona.GetLlistaPersones()[1].Rate = 1;



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p.Id = 34;
            p.Nom = "XXXX";
            p.UrlFoto = "http://www.pokexperto.net/pokemongo/pokemon/source/pokemon_icon_006_00_shiny.png";
        }
    }
}

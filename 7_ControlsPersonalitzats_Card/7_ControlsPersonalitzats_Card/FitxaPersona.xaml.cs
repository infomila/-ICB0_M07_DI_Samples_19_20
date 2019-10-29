using _7_ControlsPersonalitzats_Card.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace _7_ControlsPersonalitzats_Card
{
    public sealed partial class FitxaPersona : UserControl
    {
        public FitxaPersona()
        {
            this.InitializeComponent();            
        }


        //----------------------------------------------------------

        public Persona LaPersona
        {
            get { return (Persona)GetValue(LaPersonaProperty); }
            set { SetValue(LaPersonaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LaPersona.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LaPersonaProperty =
            DependencyProperty.Register("LaPersona", typeof(Persona), typeof(FitxaPersona), 
                new PropertyMetadata(null, PersonaChangedCallback));

        private static void PersonaChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            // això es cridarà quan assignin una persona al control personalitzat
            FitxaPersona f = (FitxaPersona)d;

            for (int i = 0; i < f.LaPersona.Rate; i++)
            {
                //<Image Width="20" Height="20" Source="https://cdn2.iconfinder.com/data/icons/crystalproject/crystal_project_256x256/apps/keditbookmarks.png"></Image>

                Image im = new Image();
                im.Width = 20;
                im.Height = 20;

                Uri imageUri = new Uri("https://cdn2.iconfinder.com/data/icons/crystalproject/crystal_project_256x256/apps/keditbookmarks.png", UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                im.Source = imageBitmap;

                f.stpRating.Children.Add(im);
            }


        }




        /*
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(FitxaPersona), 
                new PropertyMetadata(0));



        public String Nom
        {
            get { return (String)GetValue(NomProperty); }
            set { SetValue(NomProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Nom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomProperty =
            DependencyProperty.Register("Nom", typeof(String), typeof(FitxaPersona), 
                new PropertyMetadata(""));



        public String Imatge
        {
            get { return (String)GetValue(ImatgeProperty); }
            set { SetValue(ImatgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Imatge.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImatgeProperty =
            DependencyProperty.Register("Imatge", typeof(String), typeof(FitxaPersona), 
                new PropertyMetadata(""));
        */




    }
}

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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _5_Creacio_Dinamica
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class LlistaTelefons : Page
    {
        public LlistaTelefons()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> telefons = (List<string>) e.Parameter;
            foreach (string t in telefons) {

                txbLlistaTelefons.Text += (t +"\n");
             }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.GoBack();
            this.Frame.Navigate(typeof (EdicioLlistaTelefons));
        }
    }
    
}

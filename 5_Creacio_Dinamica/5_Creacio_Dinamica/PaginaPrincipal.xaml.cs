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
    public sealed partial class PaginaPrincipal : Page
    {

        private List<String> telefons = new List<String>();



        public PaginaPrincipal()
        {
            this.InitializeComponent();

            telefons.Add("93 345 34 34 34");
            telefons.Add("93 567 78 78 78");
        }

        private void NavigationView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, 
                Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {

            /*
             * Dictionary<string, Type> pagines = new Dictionary<string, Type>();
            pagines.Add("View", typeof(LlistaTelefons));
            pagines.Add("Edit", typeof(EdicioLlistaTelefons));
            //pagines.Add("Edit", typeof(EdicioLlistaTelefons));
            
            frmPrincipal.Navigate(pagines[args.InvokedItem.ToString()], telefons);*/

            if (args.InvokedItem.Equals("View"))
            {
                frmPrincipal.Navigate(typeof(LlistaTelefons), telefons);
            } else
            {
                frmPrincipal.Navigate(typeof(EdicioLlistaTelefons), telefons);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            nvwMenu.SelectedItem = mviEdit;
            frmPrincipal.Navigate(typeof(EdicioLlistaTelefons), telefons);
        }
    }
}

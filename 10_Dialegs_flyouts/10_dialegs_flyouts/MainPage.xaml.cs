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

namespace _10_dialegs_flyouts
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog cd = new ContentDialog()
            {
                Title = "Títol",
                Content = "Vols sortir?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No"
            };

             ContentDialogResult resultat = await cd.ShowAsync();
            if( resultat == ContentDialogResult.Primary)
            {
                Application.Current.Exit();
            }            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ColorPickerDialog cp = new ColorPickerDialog();
            await cp.ShowAsync();
            if (cp.Result == ContentDialogResult.Primary)
            {
                btnColor.Background = new SolidColorBrush(cp.UnColor);
            }
        }
    }
}

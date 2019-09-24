using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _0_Strings
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
           this.InitializeComponent(); // don't touch me !
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //---------------------------------------------------
            // Conversions de número  a cadena
            double numero = 123000000.2;
            decimal preu = 123.99M;

            string numeroS = numero + "";//guarriconversion ! :-S
            string numeroS1 = numero.ToString("###,###,###.00");
            CultureInfo usCI = new CultureInfo("en-us");
            string numeroS1USA = numero.ToString("###,###,###.00", usCI);

            MostraLinia(numeroS1);
            MostraLinia(numeroS1USA);
            //---------------------------------------------------
            
            DateTime hora1 = new DateTime(2012, 12, 1, 12,30,0);
            DateTime hora2 = new DateTime(2012, 12, 1);//,0 ,0, 0)
            DateTime ara = DateTime.Now;
            DateTime avui = DateTime.Today;

            if (ara>avui)
            {
                // PASSO PER AQUÍ ?????????
            }

            TimeSpan s = hora1.Subtract(hora2);
            MostraLinia(s.Hours + "h" + s.Minutes+"'");
            MostraLinia(s.TotalMinutes + "'");

            MostraLinia(hora1.ToString());
            MostraLinia(hora1.ToString("hh:mm:ss - dddd - MMMM - dd/MM/yyyy"));
            
            //----------------------------------------



        }
       


        void MostraLinia(String text)
        {
            txbSortida.Text = txbSortida.Text + Environment.NewLine + text;
        }

        private void ButtonNumero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double f = Double.Parse(txbNumero.Text);
                txbNumeroConvertida.Text = f.ToString("#####.00");
            }
            catch (Exception)
            {

                txbNumeroConvertida.Text = "LLUÇ!!!";
            }

            
        }

        private void txbNumero_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            Boolean teComa = txbNumero.Text.Contains(",");

            if(!
                (
                    (e.Key == (VirtualKey) 188 && !teComa)
                    || 
                    ( e.Key>=VirtualKey.Number0 && e.Key <= VirtualKey.Number9)
                )
            )
            {
                e.Handled = true; // la tecla no ha d'arribar al textbox
            }
        }

        private void ButtonData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //DateTime d = DateTime.Parse(txbData.Text);
                DateTime d = DateTime.ParseExact(txbData.Text, "dd/MM/yyyy", new CultureInfo("ca-es"));
                txbDataConvertida.Text = d.ToString("dddd, dd/MMM/yyyy");
            }
            catch (Exception)
            {

                txbDataConvertida.Text = "LLUÇ!!!";
            }
        }

        private void txbNumero_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

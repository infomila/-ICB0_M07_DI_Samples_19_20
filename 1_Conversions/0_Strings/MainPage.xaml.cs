using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
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


        private void txbDataDia_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            txbDataParcial_KeyDown(sender, e);
        }

        private void txbDataMes_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            txbDataParcial_KeyDown(sender, e);
            TextBox txbMes = (TextBox)sender;
            if(txbMes.Text.Length==0 && e.Key == VirtualKey.Back)
            {
                txbDataDia.Focus(FocusState.Programmatic);
            }
        }
        private void txbDataAny_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            txbDataParcial_KeyDown(sender, e);
            TextBox txbAny = (TextBox)sender;
            if (txbAny.Text.Length == 0 && e.Key == VirtualKey.Back)
            {
                txbDataMes.Focus(FocusState.Programmatic);
            }
        }



        private void txbDataParcial_KeyDown(object sender, KeyRoutedEventArgs e)
        {
             if (!
                (
                       e.Key == VirtualKey.Tab ||
                      (e.Key >= VirtualKey.Number0 && e.Key <= VirtualKey.Number9)
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
        private void txbDataMes_TextChanged(object sender, TextChangedEventArgs e)
        {
            validaTotaLaData();
            GestionaTextBoxNumericAmbSalt(txbDataMes, txbDataAny, 1, 12);
        }

        private void txbDataDia_TextChanged(object sender, TextChangedEventArgs e)
        {
            validaTotaLaData();
            TextBox txbDia = (TextBox)sender;

            GestionaTextBoxNumericAmbSalt(txbDia, txbDataMes, 1, 31);
        }

        private void validaTotaLaData()
        {
            bool estaBe = true;
            try
            {
                DateTime d = new DateTime(
                                        Int32.Parse(txbDataAny.Text),
                                        Int32.Parse(txbDataMes.Text),
                                        Int32.Parse(txbDataDia.Text)
                                        );

                if (Int32.Parse(txbDataAny.Text) < 1900)
                {
                    estaBe = false;
                }
            }
            catch (Exception)
            {
                estaBe = false;
            }


            if (estaBe)
            {
                imgIsOk.Visibility = Visibility.Visible;
            }
            else
            {
                imgIsOk.Visibility = Visibility.Collapsed;
            }


        }



        void GestionaTextBoxNumericAmbSalt(TextBox origen, TextBox desti, int min, int max)
        {
            if (origen.Text.Length == 0) return;

            bool hiHaError = false;
            try
            {
                int dia = Int32.Parse(origen.Text);
                hiHaError = (dia < min || dia > max);
            }
            catch (Exception)
            {
                hiHaError = true;
            }
            //---------------------------------------
            if (hiHaError)
            {
                origen.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                // El número està bé
                if (/* hi ha dos caracters*/ origen.Text.Length == 2)
                {
                    desti.Focus(FocusState.Programmatic);
                }
                origen.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void txbDataAny_TextChanged(object sender, TextChangedEventArgs e)
        {
            validaTotaLaData();

        }

        private void txbDataDiaiMes_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                int dia = (Int32.Parse(t.Text));
                t.Text = dia.ToString("00");
            }
            catch (Exception)
            {

            }
        }
    } // tancament de la classe


} // tancament namespace

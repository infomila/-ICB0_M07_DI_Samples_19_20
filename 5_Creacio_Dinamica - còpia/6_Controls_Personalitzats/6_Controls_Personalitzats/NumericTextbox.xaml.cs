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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace _6_Controls_Personalitzats
{
    public sealed partial class NumericTextbox : UserControl
    {
        public NumericTextbox()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //---------------------------------
        // Dependency Properties
        //---------------------------------
        // Per a cada property, heu de posar:
        // propdp + TAB + TAB
        // i....
        //  - Definir el tipus de dades
        //  - Definir el nom de la propietat
        //  - Indicar el nom de la classe on estem ( NumericTextbox)
        //  - Indicar el valor per defecte ( dins de new PropertyMetadata() )
        #region Properties
        /*public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), 
                typeof(NumericTextbox),
                new PropertyMetadata("0", TextChangedCallback));

        private static void TextChangedCallback(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {


        }*/

    

        public int Valor
        {
            get { return (int)GetValue(ValorProperty); }
            set {
                SetValue(ValorProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Valor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorProperty =
            DependencyProperty.Register("Valor", typeof(int), typeof(NumericTextbox), 
                new PropertyMetadata(0, ValorChangedCallback));


        //Quan salta ValorChangedCallback vol dir que estan canviant la propietat "Valor"
        private static void ValorChangedCallback(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {            
            // SEMPRE s'agafa el primer paràmetre (DependencyObject) i es "casteja"
            //       a el tipus de dades de 
            NumericTextbox nt = (NumericTextbox)d;

            // Fem servir l'objecte castejat per accedir  als camps de control.
            nt.txbNumero.Text = e.NewValue+"";
        }


        #endregion

        private void txbNumero_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(!( e.Key >=Windows.System.VirtualKey.Number0 &&
                e.Key <= Windows.System.VirtualKey.Number9 ))
            {
                e.Handled = true;
            }
        }

        private void txbNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Valor = Int32.Parse(txbNumero.Text);
            }
            catch (Exception)
            {
                Valor = 0;
                txbNumero.Text = "0";
            }
        }
    }
}

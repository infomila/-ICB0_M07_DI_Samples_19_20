using _9_Cinema_UserControl.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace _9_Cinema_UserControl.View
{
    public sealed partial class UICadira : UserControl
    {
        // Declaració de l'event CadiraSelectionChanged
        public event EventHandler CadiraSelectionChanged;

        public UICadira()
        {
            this.InitializeComponent();
        }



        public Cadira LaCadira
        {
            get { return (Cadira)GetValue(cadiraProperty); }
            set { SetValue(cadiraProperty, value); }
        }

        // Using a DependencyProperty as the backing store for cadira.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty cadiraProperty =
            DependencyProperty.Register("LaCadira", typeof(Cadira), 
                typeof(UICadira), 
                new PropertyMetadata(null, PropCadiraChangedCallbackStatic));

        private static void PropCadiraChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UICadira c = (UICadira)d;
            c.PropCadiraChangedCallback();
        }

        private void PropCadiraChangedCallback()
        {

            MostrarColorCadira();

        }




        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(UICadira), 
                new PropertyMetadata(20));




        private void MostrarColorCadira()
        {
            Windows.UI.Color c;
            if (LaCadira.Estat == EnumEstat.OCUPADA)
            {
                c = Colors.Black;
            }
            else if (LaCadira.Estat == EnumEstat.SELECCIONADA) {
                c = Windows.UI.Color.FromArgb(
                    LaCadira.Cat.UnColor.A,
                    (byte)(LaCadira.Cat.UnColor.R *0.5),
                    (byte)(LaCadira.Cat.UnColor.G * 0.5),
                    (byte)(LaCadira.Cat.UnColor.B * 0.5));
           } else {
                c = LaCadira.Cat.UnColor;
            }
            eliEli.Fill = new SolidColorBrush(c);
        }

        private void eliEli_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(LaCadira.Estat !=EnumEstat.OCUPADA)
            {
                LaCadira.Estat = (LaCadira.Estat == EnumEstat.LLIURE) ? 
                                    EnumEstat.SELECCIONADA : EnumEstat.LLIURE ;

                MostrarColorCadira();
                // Com que la cadira ha canviat al seva selecció, invoquem
                // l'event CadiraSelectionChanged
                CadiraSelectionChanged?.Invoke(this, new EventArgs());
            }
            
        }
    }
}

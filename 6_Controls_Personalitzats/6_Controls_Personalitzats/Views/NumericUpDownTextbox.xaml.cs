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

namespace _6_Controls_Personalitzats.Views
{
    public sealed partial class NumericUpDownTextbox : UserControl
    {
        public NumericUpDownTextbox()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Event que indica que Valor ha canviat
        /// </summary>
        public event EventHandler ValorChanged;


        #region Propietats

        /// <summary>
        ///  Llegeix/modifica el valor actual mostrat en el control
        /// </summary>
        public int Valor
        {
            get { return (int)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorProperty =
            DependencyProperty.Register("Valor", typeof(int), typeof(NumericUpDownTextbox),
                new PropertyMetadata(0, ValorChangedCallback));

        private static void ValorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDownTextbox nud = (NumericUpDownTextbox)d;
            nud.ValorChanged?.Invoke(nud, new EventArgs());
        }



        /// <summary>
        /// Estableix/llegeix el Valor màxim admés del control. El valor està inclós en el rang vàlid.
        /// </summary>
        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(NumericUpDownTextbox), new PropertyMetadata(100));


        /// <summary>
        /// Estableix/llegeix el Valor mínim admés del control. El valor està inclós en el rang vàlid.
        /// </summary>

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(NumericUpDownTextbox), new PropertyMetadata(0));





        #endregion

        private void Button_Click_Up(object sender, RoutedEventArgs e)
        {
            if (numTexbox.Valor < this.Max)
            {
                numTexbox.Valor++;
            }
        }

        private void Button_Click_Down(object sender, RoutedEventArgs e)
        {
            if (numTexbox.Valor > this.Min)
            {
                numTexbox.Valor--;
            }
        }

        private void numTexbox_ValorChanged(object sender, EventArgs e)
        {
            if (numTexbox.Valor > this.Max)
            {
                numTexbox.Valor = this.Max;
            } else if (numTexbox.Valor < this.Min)
            {
                numTexbox.Valor = this.Min;
            }
        }
    }
}

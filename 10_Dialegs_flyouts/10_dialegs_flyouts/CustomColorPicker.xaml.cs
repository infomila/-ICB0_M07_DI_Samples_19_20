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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace _10_dialegs_flyouts
{
    public sealed partial class CustomColorPicker : UserControl
    {
        public event EventHandler ClosedEvent;
        public event EventHandler CanceledEvent;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Llancem l'event de tancament
            ClosedEvent?.Invoke(this, new EventArgs());
        }
        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            // Llancem l'event de tancament
            CanceledEvent?.Invoke(this, new EventArgs());
        }


        public CustomColorPicker()
        {
            this.InitializeComponent();
        }


        public Color UnColor
        {
            get { return (Color)GetValue(UnColorProperty); }
            set { SetValue(UnColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnColorProperty =
            DependencyProperty.Register("UnColor", typeof(Color),
                typeof(CustomColorPicker), 
                new PropertyMetadata(Colors.Blue));


    }
}

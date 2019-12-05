using AplicacioDM;
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

namespace AplicacioUI.View
{
    public sealed partial class UIFitxaEmp : UserControl
    {
        public UIFitxaEmp()
        {
            this.InitializeComponent();
        }        

        public Emp Empleat
        {
            get { return (Emp)GetValue(EmpresaProperty); }
            set { SetValue(EmpresaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Empresa.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmpresaProperty =
            DependencyProperty.Register("Empleat", typeof(Emp), typeof(UIFitxaEmp), 
                new PropertyMetadata(null));

        private void ucFitxa_Loaded(object sender, RoutedEventArgs e)
        {        
            cboDept.ItemsSource = DeptDB.getLlistaDepartaments();
            cboDept.DisplayMemberPath = "DNom";
            // Decidim quin dels camps és el que es fa servir
            // per la propietat "SelectedValue"
            cboDept.SelectedValuePath = "DeptNo";
        }
    }
}

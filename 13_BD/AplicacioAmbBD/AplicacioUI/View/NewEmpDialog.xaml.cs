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
    public sealed partial class NewEmpDialog : ContentDialog
    {
        public NewEmpDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Emp empBuit = new Emp();
            uiFitxa.Empleat = empBuit;
        }
        private void btnSave_click(object sender, RoutedEventArgs e)
        {
           // EmpDB.Insert(uiFitxa.Empleat);
            // manca validar
            this.Hide();
        }
        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}

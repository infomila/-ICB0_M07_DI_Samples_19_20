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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AplicacioUI
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtgEmpleats.ItemsSource = EmpDB.getLlistaEmpleats();
            cmbDept.ItemsSource = DeptDB.getLlistaDepartaments();
            cmbDept.DisplayMemberPath = "DNom";
            cboDept.ItemsSource = cmbDept.ItemsSource;
            cboDept.DisplayMemberPath = "DNom";
            // Decidim quin dels camps és el que es fa servir
            // per la propietat "SelectedValue"
            cboDept.SelectedValuePath = "DeptNo";
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {

            string cognom = txbCognom.Text;
            DateTimeOffset off = dpkData.Date;
            DateTime d = off.DateTime;
            // Recuperem el codi de departament, en el cas que el combo estigui buit, desem un -1.
            int numDept = cmbDept.SelectedItem!=null?
                ((Dept)cmbDept.SelectedItem).DeptNo: EmpDB.SENSE_DEPT;


            dtgEmpleats.ItemsSource = EmpDB.getLlistaEmpleats(cognom, d, numDept);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            cmbDept.SelectedIndex = -1;
            txbCognom.Text = "";
        }


        public bool EmpleatSeleccionat
        {
            get
            {
                return dtgEmpleats.SelectedItem != null;
            }
        }

        /*
        private void dtgEmpleats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dtgEmpleats.SelectedItem!=null)
            {
                Emp emp = ((Emp)dtgEmpleats.SelectedItem);
                txtCognom.Text = emp.Cognom;
            }
        }*/
    }
}

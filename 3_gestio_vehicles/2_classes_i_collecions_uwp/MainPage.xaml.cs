using _2_classes_i_collecions_uwp.model;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _2_classes_i_collecions_uwp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int indexVehicleActual = 0;
        private List<Vehicle> vehicles;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //----------------------------------------------------
            // precarreguem la llista de vehicles en un atribut de la classe
            // per disposa-la en qualsevol moment
            vehicles = Vehicle.GetVehicles();


            //----------------------------------------------------
            // Carreguem el combobox de marques
            cboMarca.ItemsSource = Marca.GetMarques();
            cboMarca.DisplayMemberPath = "Nom";

            //----------------------------------------------------
            // Mostrem el vehicle actual ( inicialment serà zero )
            MostrarVehicle(indexVehicleActual);
        }
        private void MostrarVehicle( int index )
        {
            //List<Vehicle> vehicles = Vehicle.GetVehicles();
            if(vehicles.Count> index && index>=0)
            {
                MostrarVehicle(vehicles[index]);
            }
        }


        private void MostrarVehicle(Vehicle v)
        {
            txbCodi.Text = v.Codi.ToString();
            txbMatricula.Text = v.Matricula;
            if (v.Tipus == EnumTipus.COTXE)
            {
                rdoCotxe.IsChecked = true;
            }
            else
            {
                rdoMoto.IsChecked = true;
            }
            //----------------------------------------
            string marca = v.Marca;
            cboMarca.SelectedValuePath = "Nom";
            cboMarca.SelectedValue = marca;

            cboModel.SelectedValue = v.Model;
        }

        private void cboMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int indexMarcaSeleccionada = cboMarca.SelectedIndex;
            //List<Marca> marques = Marca.GetMarques();
            //Marca seleccionada = marques[indexMarcaSeleccionada];
            Marca seleccionada = (Marca)cboMarca.SelectedItem;

            cboModel.ItemsSource = seleccionada.Models;

        }

        private void Button_Click_Endavant(object sender, RoutedEventArgs e)
        {
            this.indexVehicleActual = (this.indexVehicleActual + 1) % vehicles.Count;
            MostrarVehicle(indexVehicleActual);
        }

        private void Button_Click_Enrere
            (object sender, RoutedEventArgs e)
        {
            this.indexVehicleActual--;
            if (this.indexVehicleActual < 0)
            {
                this.indexVehicleActual = vehicles.Count - 1;
            }
            MostrarVehicle(indexVehicleActual);
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (ValidaCamps())
            {

                // Cerquem el vehicle actual
                Vehicle actual = vehicles[indexVehicleActual];
                // modifiquem la matrícula
                actual.Matricula = txbMatricula.Text;
                // modifiquem el tipus
                if (rdoCotxe.IsChecked == true)
                {
                    actual.Tipus = EnumTipus.COTXE;
                }
                else
                {
                    actual.Tipus = EnumTipus.MOTO;
                }
                //actual.Tipus = (rdoCotxe.IsChecked == true) ? EnumTipus.COTXE : EnumTipus.MOTO;
                Marca m = (Marca)cboMarca.SelectedItem;
                actual.Marca = m.Nom;

                actual.Model = cboModel.SelectedValue.ToString();

                //actual.Marca = cboMarca.SelectedValue.ToString();
            }


        }

        private bool ValidaCamps()
        {

            // si (txbMatricula.Text esta malament) 
            // 
            txbMatricula.Background = new SolidColorBrush(Colors.Red);
            return true;

        }
    }
}

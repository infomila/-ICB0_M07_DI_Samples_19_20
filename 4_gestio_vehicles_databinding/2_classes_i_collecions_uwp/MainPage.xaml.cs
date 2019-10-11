using _2_classes_i_collecions_uwp.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
   

    enum ModeEdicio
    {
        MODE_EDIT,
        MODE_NEW
    }

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



            lsvVehicles.ItemsSource = vehicles;

            //----------------------------------------------------
            // Carreguem el combobox de marques
            cboMarca.ItemsSource = Marca.GetMarques();
            //cboMarca.DisplayMemberPath = "Nom";

            //----------------------------------------------------
            // Mostrem el vehicle actual ( inicialment serà zero )
            MostrarVehicle(indexVehicleActual);
        }
        private void MostrarVehicle( int index )
        {
     
            //List<Vehicle> vehicles = Vehicle.GetVehicles();
            if (vehicles.Count> index && index>=0)
            {
                MostrarVehicle(vehicles[index]);
            }
   
      
        }


        private void DesactivaEvents()
        {
            txbMatricula.TextChanged -= txbMatricula_TextChanged;
            cboMarca.SelectionChanged -= cboMarca_SelectionChanged;
            cboModel.SelectionChanged -= cboModel_SelectionChanged;
            rdoCotxe.Checked -= rdoCotxe_Checked;
            rdoMoto.Unchecked -= rdoCotxe_Checked;
            rdoMoto.Checked -= rdoCotxe_Checked;
        }
        private void ActivaEvents()
        {
            txbMatricula.TextChanged  += txbMatricula_TextChanged;
            cboMarca.SelectionChanged += cboMarca_SelectionChanged;
            cboModel.SelectionChanged += cboModel_SelectionChanged;
            rdoCotxe.Checked  += rdoCotxe_Checked;
            rdoMoto.Unchecked += rdoCotxe_Checked;
            rdoMoto.Checked   += rdoCotxe_Checked;
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
            
            //cboMarca.SelectedValuePath = "Nom";
            cboMarca.SelectedItem = v.Marca;
            cboMarca_SelectionChanged(null, null);
            cboModel.SelectedValue = v.Model;
        }

        private void cboMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int indexMarcaSeleccionada = cboMarca.SelectedIndex;
            //List<Marca> marques = Marca.GetMarques();
            //Marca seleccionada = marques[indexMarcaSeleccionada];
            Marca seleccionada = (Marca)cboMarca.SelectedItem;
            if (seleccionada != null)
            {
                cboModel.ItemsSource = seleccionada.Models;
            } else
            {
                cboModel.ItemsSource = null;
            }


        }

        private async void Button_Click_Endavant(object sender, RoutedEventArgs e)
        {
             
            if (await verificaCanvisPendentsAsync())
            {
                this.indexVehicleActual = (this.indexVehicleActual + 1) % vehicles.Count;
                MostrarVehicle(indexVehicleActual);
            }
        }


        private async System.Threading.Tasks.Task<bool> verificaCanvisPendentsAsync()
        {

            try
            {
                Vehicle modificat = new Vehicle(
                    Int32.Parse(txbCodi.Text),
                    txbMatricula.Text,
                    (Marca)cboMarca.SelectedValue,
                    (string)cboModel.SelectedValue,
                    (rdoCotxe.IsChecked == true) ? EnumTipus.COTXE : EnumTipus.MOTO
                );
                Vehicle original = vehicles[indexVehicleActual];

                if (original.Equals(modificat)) return true;
            } catch(Exception ex)
            {

            }

            ContentDialog confirmaFileDialog = new ContentDialog
            {
                Title = "Atenció !",
                Content = "Hi ha canvis pendents, vol descartar canvis?",
                PrimaryButtonText = "Descartar",
                CloseButtonText = "Cancel·lar"
            };

            ContentDialogResult result = await confirmaFileDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        private async void Button_Click_Enrere
            (object sender, RoutedEventArgs e)
        {
            if (await verificaCanvisPendentsAsync())
            {

                this.indexVehicleActual--;
                if (this.indexVehicleActual < 0)
                {
                    this.indexVehicleActual = vehicles.Count - 1;
                }
                MostrarVehicle(indexVehicleActual);
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (ValidaCamps())
            {
                if(modeActual == ModeEdicio.MODE_NEW)
                {
                    Vehicle nou = new Vehicle(
                            Int32.Parse( txbCodi.Text ),
                            txbMatricula.Text,
                            (Marca)cboMarca.SelectedValue,
                            (string)cboModel.SelectedValue,
                            (rdoCotxe.IsChecked == true) ? EnumTipus.COTXE : EnumTipus.MOTO
                        );
                    vehicles.Add(nou);
                    indexVehicleActual = vehicles.Count - 1;
                    modeActual = ModeEdicio.MODE_EDIT;
                } 
                else if (modeActual == ModeEdicio.MODE_EDIT)
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
                    actual.Marca = m;

                    actual.Model = cboModel.SelectedValue.ToString();

                    //actual.Marca = cboMarca.SelectedValue.ToString();
                }
                // canvis desats, per tant no hi ha canvis pendents
          
            }


        }
        private bool MostraError(bool hiHaError, TextBlock t, bool estatActual)
        {
            bool esValid = estatActual;
            if (hiHaError)
            {
                t.Visibility = Visibility.Visible;
                esValid = false;
            }
            else
            {
                t.Visibility = Visibility.Collapsed;
            }
            return esValid;
        }

        private bool ValidaCamps()
        {
            bool esValid = true;

            esValid = MostraError(cboMarca.SelectedIndex == -1, txbErrorMarca, esValid);
            esValid = MostraError(cboModel.SelectedIndex == -1, txbErrorModel, esValid);
            esValid = MostraError(!Vehicle.ValidaMatricula(txbMatricula.Text), txbErrorMatricula, esValid);

            /*if (cboMarca.SelectedIndex==-1)
            {
                txbErrorMarca.Visibility = Visibility.Visible;
                esValid = false;
            } else
            {
                txbErrorMarca.Visibility = Visibility.Collapsed;
            }
            //----------------------------------------------------------
            if (cboModel.SelectedIndex == -1)
            {
                txbErrorModel.Visibility = Visibility.Visible;
                esValid = false;
            }
            else
            {
                txbErrorModel.Visibility = Visibility.Collapsed;
            }
            //----------------------------------------------------------

            if(Vehicle.ValidaMatricula(txbMatricula.Text))
            {
                txbErrorMatricula.Visibility = Visibility.Collapsed;
                txbMatricula.Background = new SolidColorBrush(Colors.Transparent);
            } else
            {
                txbErrorMatricula.Visibility = Visibility.Visible;
                txbMatricula.Background = new SolidColorBrush(Colors.Red);
                esValid = false;
            }
            */
            return esValid;
        }

        ModeEdicio modeActual = ModeEdicio.MODE_EDIT;

        private void Button_Click_New(object sender, RoutedEventArgs e)
        {
            BuidarFormulari();
            modeActual = ModeEdicio.MODE_NEW;
        }

        private void BuidarFormulari()
        {
            txbMatricula.Text = "";
            cboMarca.SelectedIndex = -1;
            cboModel.SelectedIndex = -1;
            rdoCotxe.IsChecked = true;
            rdoMoto.IsChecked = false;

            int codiMax = -1;
            foreach(Vehicle v in vehicles)
            {
                if (v.Codi > codiMax) codiMax = v.Codi;
            }
            codiMax++;
            txbCodi.Text = codiMax + "";
        }

        private async void Button_Click_Esborrar(object sender, RoutedEventArgs e)
        {
            if (await verificaCanvisPendentsAsync())
            {
                //vehicles.Remove(vehicles[indexVehicleActual]);
                vehicles.RemoveAt(indexVehicleActual);
                if (indexVehicleActual >= vehicles.Count) indexVehicleActual--;
                MostrarVehicle(indexVehicleActual);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MostrarVehicle(indexVehicleActual);

        }

        private void txbMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void cboModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void rdoCotxe_Checked(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

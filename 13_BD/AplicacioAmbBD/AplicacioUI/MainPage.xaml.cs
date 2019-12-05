using AplicacioDM;
using MetroLog;
using MetroLog.Targets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
         static MainPage()
        {
#if DEBUG
            LogManagerFactory.DefaultConfiguration.AddTarget(
                LogLevel.Debug,
                LogLevel.Fatal, new FileStreamingTarget());
#else
            LogManagerFactory.DefaultConfiguration.AddTarget(
                LogLevel.Error,
                LogLevel.Fatal, new FileStreamingTarget());
#endif
        }

        public MainPage()
        {
            this.InitializeComponent();
        }
        private ObservableCollection<Emp> empleats;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            empleats = EmpDB.getLlistaEmpleats();
            dtgEmpleats.ItemsSource = empleats;
            cmbDept.ItemsSource = DeptDB.getLlistaDepartaments();
            cmbDept.DisplayMemberPath = "DNom";
   
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

        private bool ModeEdicio = true;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // manca fer validacions
            // de tots els camps abans de desar
            // ..............
            //   YUPI !
            int salari =  (int) uiFitxa.Empleat.Salari;
            int numDept = uiFitxa.Empleat.DeptNo;
            EmpDB_Update_Error_Codes errCode;
            if (EmpDB.Update(   ((Emp)dtgEmpleats.SelectedItem).EmpNo,
                            uiFitxa.Empleat.Cognom, 
                            salari,
                            numDept,
                            out errCode))
            {
                //dtgEmpleats.ItemsSource = EmpDB.getLlistaEmpleats();

                Emp emp = ((Emp)dtgEmpleats.SelectedItem);
                emp.Cognom = uiFitxa.Empleat.Cognom;
                emp.Salari = uiFitxa.Empleat.Salari;
                emp.DeptNo = uiFitxa.Empleat.DeptNo;
                //empleats
            } else
            {
                String missatgeError = "";
                switch(errCode)
                {
                    case EmpDB_Update_Error_Codes.ERR_COGNOM_REPETIT:
                        missatgeError = "El cognom està repetit"; break;
                    case EmpDB_Update_Error_Codes.ERR_INESPERAT:
                        missatgeError = "Error inesperat mentre es connnectava a la BD";
                        break;
                    default:
                        missatgeError = "Error inesperat mentre es connnectava a la BD";
                        break;                    
                }

                DisplayError(missatgeError);

            }

        }

        private async void DisplayError(String error)
        {
            ContentDialog dialeg = new ContentDialog
            {
                Title = "Error",
                Content = error,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await dialeg.ShowAsync();
        }

        private void dtgEmpleats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Emp emp = ((Emp)dtgEmpleats.SelectedItem);
            if (emp != null)
            {
                Emp clonic = new Emp(emp);
                uiFitxa.Empleat = clonic;
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

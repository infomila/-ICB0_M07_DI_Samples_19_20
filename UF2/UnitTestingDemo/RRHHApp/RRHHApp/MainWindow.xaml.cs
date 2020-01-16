using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RRHHApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> operacions = new List<string>();
            operacions.Add("+");
            operacions.Add("-");
            operacions.Add("/");
            operacions.Add("*");
            cboOperacio.ItemsSource = operacions;
            cboOperacio.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int resultat =0;
                int num1 = Int32.Parse(txtOp1.Text);
                int num2 = Int32.Parse(txtOp2.Text);
                switch (cboOperacio.SelectedItem)
                {
                    case "+": resultat = num1 + num2;break;
                    case "-": resultat = num1 - num2; break;
                    case "*": resultat = num1 * num2; break;
                    case "/": resultat = num1 / num2; break;
                }                 
                txtRes.Text = resultat.ToString();
            }catch(Exception ex)
            {

            }
        }
    }
}

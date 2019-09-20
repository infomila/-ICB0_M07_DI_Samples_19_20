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

namespace _0_Strings
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
           this.InitializeComponent(); // don't touch me !
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            String nom = "Marta    ";
            String cognom1 = "González   ";
            String cognom2 = "Cruz";

            String nomComplet = nom + " " + cognom1 + " " + cognom2;
            txbSortida.Text = nomComplet;


            nomComplet = $"{nom} {cognom1} {cognom2}";

            MostraLinia(nomComplet);

            MostraLinia(nomComplet.ToUpper());

            MostraLinia(nomComplet);

            int indexDelEspai = nomComplet.IndexOf(' ');

            String primeraParaula = nomComplet.Substring(0, indexDelEspai);
            //01234567890123456789
            //Marta González Cruz

            MostraLinia(primeraParaula);


            MostraLinia(GetPrimerCognom(nomComplet));

        }
        /*
        String GetPrimerCognom(String nomComplet)
        {
            int posicioPrimerEspai = nomComplet.IndexOf(" ");//5
            int posicioSegonEspai = nomComplet.IndexOf(" ", posicioPrimerEspai + 1);//14
            return nomComplet.Substring(posicioPrimerEspai+1,
                                 posicioSegonEspai- posicioPrimerEspai-1
                                );

        }

        */
        /*
        String GetPrimerCognom(String nomComplet)
        {
            int i;
            for (i=1;i<nomComplet.Length;i++)
            {
                if(nomComplet[i-1]==' ' && nomComplet[i]!=' ')
                {
                    break;
                }
            }
            int posicioPrimerEspai = i-1;
            i++;
            for ( ; i < nomComplet.Length; i++)
            {
                if (nomComplet[i - 1] == ' ' && nomComplet[i] != ' ')
                {
                    break;
                }
            }
            int posicioSegonEspai = i-1;
            return nomComplet.Substring(posicioPrimerEspai + 1,
                                 posicioSegonEspai - posicioPrimerEspai - 1
                                ).Trim();


        }*/

        String GetPrimerCognom(String nomComplet)
        {
            char[] separadors = { ' ' , '\t'};
            string[] paraules = nomComplet.Split(
                separadors,
                StringSplitOptions.RemoveEmptyEntries);
            return paraules[1];
        }


            void MostraLinia(String text)
        {
            txbSortida.Text = txbSortida.Text + Environment.NewLine + text;
        }


    }
}

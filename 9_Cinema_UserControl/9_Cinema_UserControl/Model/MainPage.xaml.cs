using _9_Cinema_UserControl.Model;
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

namespace _9_Cinema_UserControl
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Sala s = Sala.CrearSala();
            s.Cadires[0].Estat = EnumEstat.OCUPADA;
            uicad1.LaCadira = s.Cadires[0];
            uicad2.LaCadira = s.Cadires[25];
            uicad3.LaCadira = s.Cadires[45];
            uicad4.LaCadira = s.Cadires[65];

            List<Cadira> seleccionades = new List<Cadira>();
            foreach (Cadira c in s.Cadires) {
                if (c.Estat==EnumEstat.SELECCIONADA)
                {
                    seleccionades.Add(c);
                }
            }
            //-------------------------------------
            // LAMBDA EXPRESSIONS
            List<Cadira> seleccionades2 = 
                s.Cadires.Where(c => c.Estat == EnumEstat.SELECCIONADA).ToList();

            decimal total = 0;
            s.Cadires.ForEach(c => total += c.Id);

            List<Cadira> cadiresOrdenadesId = s.Cadires.OrderBy(c => c.Id).ToList();





        }

    
    }
}

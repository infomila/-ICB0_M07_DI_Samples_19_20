using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI;

namespace _9_Cinema_UserControl.Model
{
    public class Categoria
    {
        private string nom;
        private decimal preu;
        private Color unColor;

        public Categoria(string nom, decimal preu, Color unColor)
        {
            Nom = nom;
            Preu = preu;
            UnColor = unColor;
        }

        public string Nom { get => nom; set => nom = value; }
        public decimal Preu { get => preu; set => preu = value; }
        public Color UnColor { get => unColor; set => unColor = value; }
    }
        
}
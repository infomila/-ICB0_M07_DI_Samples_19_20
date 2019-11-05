using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace _9_Cinema_UserControl.Model
{
    public class Sala
    {
        private long id;
        private string nom;
        private List<Cadira> cadires;
        private List<ItemEscenari> items;

        public Sala(long id, string nom, List<Cadira> cadires, List<ItemEscenari> items)
        {
            this.id = id;
            Nom = nom;
            Cadires = cadires;
            Items = items;
        }

        public long Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public List<Cadira> Cadires { get => cadires; set => cadires = value; }
        public List<ItemEscenari> Items { get => items; set => items = value; }


        //---------------------------------------------------------------

        /// <summary>
        /// Creació d'una classe per a fer proves
        /// </summary>
        /// <returns>la ditxosa sala que hem creat</returns>
        public static Sala CrearSala()
        {
            List<Categoria> cats = new List<Categoria>() {
                new Categoria("platea", 87, Colors.Azure),
                new Categoria("lateral", 69, Colors.Aqua),
                new Categoria("primer pis", 55, Colors.Aquamarine),
                new Categoria("segon pis", 50, Colors.AntiqueWhite)
            };

            //------------------------------------
            // P P P P P P P P P P
            // P P P P P P P P P P
            // P P P P P P P P P P
            // L L L L L L L L L L
            // L L L L L L L L L L
            // L L L L L L L L L L
            // 1 1 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1 1
            // 2 2 2 2 2 2 2 2 2 2
            // 2 2 2 2 2 2 2 2 2 2
            // 2 2 2 2 2 2 2 2 2 2

            long id = 0;
            int f = 1;
            // la distància entre cadira i cadira
            int espaiatH = 10, espaiatV = 10;
            List<Cadira> cadires = new List<Cadira>();
            // Per cada categoria creem 10*3 cadires
            foreach (Categoria cat in cats) {
                for(int f1=0;f1<3;f1++, f++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        Cadira cad = new Cadira(
                            id++,  //id general
                            new Point(f* espaiatV, c* espaiatH), //coordenades
                            cat, 
                            0, 
                            EnumEstat.LLIURE);
                        cadires.Add(cad);
                    }
                }
            }
            //---------------------------------------------
            // Creació de la pantalla
            ItemEscenari pantalla = new ItemEscenari(
                "pantalla",
                new Point(0, 0), 
                new Point(espaiatH * 10, espaiatV));
            List<ItemEscenari> items = new List<ItemEscenari>();
            items.Add(pantalla);
            //---------------------------------------------
            Sala s = new Sala(10, "Sala Igualada", cadires, items);

            return s;
        }


    }
}




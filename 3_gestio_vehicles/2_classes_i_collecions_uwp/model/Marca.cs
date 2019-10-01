using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_classes_i_collecions_uwp.model
{
    class Marca
    {
        //--- Singleton -------------------------
        private static List<Marca> marques;

        public static List<Marca> GetMarques()
        {
            if (marques == null) // inicialitzem la llista si no té valor
            {
                marques = new List<Marca>();
                //-------------------------------
                Marca seat = new Marca("Seat");
                seat.models.Add("Leon");
                seat.models.Add("Tarraco");
                seat.models.Add("Exeo");
                marques.Add(seat);
                //-------------------------------
                Marca volkswagen = new Marca("Volkswagen");
                volkswagen.models.Add("Golf");
                volkswagen.models.Add("Touran");
                volkswagen.models.Add("California");
                marques.Add(volkswagen);
            }
            return marques;
        }

        //---------------------------------------------
        private string nom;
        private List<string> models;
        //---------------------------------------------
        public Marca(string pNom)
        {
            nom = pNom;
            models = new List<string>();
        }

        //---------------------------------------------
        public string Nom { get => nom; }
        public List<string> Models {
            get => models;
            }
        //---------------------------------------------

    }
}

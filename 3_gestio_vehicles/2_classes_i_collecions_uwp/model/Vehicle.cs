using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2_classes_i_collecions_uwp.model
{
    class Vehicle
    {
        private static List<Vehicle> vehicles;

        public static List<Vehicle> GetVehicles()
        {
            if (vehicles == null)
            {
                vehicles = new List<Vehicle>();
                Vehicle v1 = new Vehicle(1, "1234JKJ", "Seat", "Leon", EnumTipus.COTXE);
                Vehicle v2 = new Vehicle(2, "9999GGG", "Seat", "Exeo", EnumTipus.COTXE);
                Vehicle v3 = new Vehicle(3, "3333JJJ", "Volkswagen", "Golf", EnumTipus.COTXE);
                vehicles.Add(v1);
                vehicles.Add(v2);
                vehicles.Add(v3);
                //vehicles.AddRange(new List<Vehicle>{ v1,v2,v3});
            }
            return vehicles;
        }




        //-----------------------------------------------


        private int codi;
        private string matricula;
        private string marca;
        private string model;
        private EnumTipus tipus;

        public Vehicle(int codi, string matricula, string marca, string model, EnumTipus tipus)
        {
            this.Codi = codi;
            this.Matricula = matricula;
            this.Marca = marca;
            this.Model = model;
            this.Tipus = tipus;
        }

        public int Codi { get => codi; set => codi = value; }
        public string Matricula {
                            get => matricula;
                            set  {
                                    if (value == null )
                                        throw new Exception("MATRICULA NO VÀLIDA");
     
                                    // Instantiate the regular expression object.
                                    Regex r = new Regex("^[0-9]{4}[ZXCVBNMSDFGHJKLQWRTYP]{3}$", RegexOptions.IgnoreCase);

                                    // Match the regular expression pattern against a text string.
                                    Match m = r.Match(value);
                                    if(m.Success) { matricula = value; } else
                                    {
                                        throw new Exception("MATRICULA NO VÀLIDA");
                                    }
                            }
        }
        public string Marca { get => marca; set => marca = value; }
        public string Model { get => model; set => model = value; }
        public EnumTipus Tipus { get => tipus; set => tipus = value; }


        
        public override bool Equals(object obj)
        {
            var vehicle = obj as Vehicle;
            return vehicle != null &&
                   matricula == vehicle.matricula;
        }

        
        public override String ToString()
        {
            return Codi + " " + Matricula + " " + Marca;
        }


        /*
        public Vehicle(int pcodi, string pmatricula, string pmarca, string pmodel , string ptipus)
        {
            this.codi = pcodi;
            this.matricula = pmatricula;
        }*/
    }
}

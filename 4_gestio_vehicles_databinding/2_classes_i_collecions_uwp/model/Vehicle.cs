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
                Vehicle v1 = new Vehicle(1, "1234JKJ", _2_classes_i_collecions_uwp.model.Marca.GetMarques()[0], "Leon", EnumTipus.COTXE);
                Vehicle v2 = new Vehicle(20, "9999GGG", _2_classes_i_collecions_uwp.model.Marca.GetMarques()[0], "Exeo", EnumTipus.MOTO);
                Vehicle v3 = new Vehicle(3, "3333JJJ", _2_classes_i_collecions_uwp.model.Marca.GetMarques()[1], "Golf", EnumTipus.COTXE);
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
        //private string marca;
        private Marca marca;
        private string model;
        private EnumTipus tipus;

        public Vehicle(int codi, string matricula, Marca marca, string model, EnumTipus tipus)
        {
            this.Codi = codi;
            this.Matricula = matricula;
            this.marca = marca;
            this.Model = model;
            this.Tipus = tipus;
        }

        public int Codi { get => codi; set => codi = value; }
        public string Matricula {
                            get => matricula;
                            set  {
                                    if(ValidaMatricula(value))
                                    {
                                        matricula = value;
                                    } else
                                    {
                                        throw new Exception("Matricula errònia");
                                    }
                            }
        }


        public static bool ValidaMatricula(String unaMatricula)
        {
            if (unaMatricula == null)  return false;
     
            // Instantiate the regular expression object.
            Regex r = new Regex("^[0-9]{4}[ZXCVBNMSDFGHJKLQWRTYP]{3}$", RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(unaMatricula);
            if(m.Success) { return true; } else
            {
                return false;
            }            
        }

        public override bool Equals(object obj)
        {
            var vehicle = obj as Vehicle;
            return vehicle != null &&
                   Codi == vehicle.Codi &&
                   Matricula == vehicle.Matricula &&
                   Marca == vehicle.Marca &&
                   Model == vehicle.Model &&
                   Tipus == vehicle.Tipus;
        }

        public _2_classes_i_collecions_uwp.model.Marca Marca { get => marca;  set => marca = value; }
        public string Model { get => model; set => model = value; }
        public EnumTipus Tipus { get => tipus; set => tipus = value; }


         public string TipusEmoji {  get
            {
                if (Tipus == EnumTipus.COTXE) return "🚗";
                else return "🛵";

            }
        }


        /*
        public Vehicle(int pcodi, string pmatricula, string pmarca, string pmodel , string ptipus)
        {
            this.codi = pcodi;
            this.matricula = pmatricula;
        }*/





    }
}

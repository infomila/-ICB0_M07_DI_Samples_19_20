using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_classes_i_collecions_uwp.model
{
    class Vehicle
    {
        private int codi;
        private string matricula;
        private string marca;
        private string model;
        private string tipus;

        public Vehicle(int codi, string matricula, string marca, string model, string tipus)
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
                if (value == null || value.Length != 7)
                    throw new Exception("MATRICULA NO VÀLIDA");
                                matricula = value;
                            }
        }
        public string Marca { get => marca; set => marca = value; }
        public string Model { get => model; set => model = value; }
        public string Tipus { get => tipus; set => tipus = value; }


        
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

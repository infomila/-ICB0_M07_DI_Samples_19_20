using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llibreria
{
    public class Persona
    {
        private int id;
        private String nom;

        public Persona(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}

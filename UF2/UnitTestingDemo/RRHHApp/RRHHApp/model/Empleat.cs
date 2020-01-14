using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHHApp.model
{
    class Empleat : Persona
    {
        private decimal salari;
        private int numeroEmpleat;
        private string carrec;

        public Empleat(string NIF, string nom, DateTime dataNaixement, decimal salari, int numeroEmpleat, string carrec) : base(NIF, nom, dataNaixement)
        {
            this.salari = salari;
            this.numeroEmpleat = numeroEmpleat;
            this.carrec = carrec;
        }



        public decimal Salari { get => salari; set => salari = value; }
        public int NumeroEmpleat { get => numeroEmpleat; set => numeroEmpleat = value; }
        public string Carrec { get => carrec; set => carrec = value; }
    }
}

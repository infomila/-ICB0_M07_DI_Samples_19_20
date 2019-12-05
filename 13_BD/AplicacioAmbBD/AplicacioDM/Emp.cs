using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AplicacioDM
{
    public class Emp : INotifyPropertyChanged
    {
        internal int empNo ;
        internal string cognom ;      
        internal string ofici ;
        internal int cap ;
        internal string nomCap;
        internal DateTime data_alta ;
        internal decimal salari ;     
        internal decimal comissio ;
        internal int deptNo ;


        public Emp() { }

        public Emp(int empNo, string cognom, string ofici, int cap, DateTime data_alta, decimal salari, decimal comissio, int deptNo)
        {
            this.EmpNo = empNo;
            this.Cognom = cognom;
            this.Ofici = ofici;
            this.Cap = cap;
            this.Data_alta = data_alta;
            this.Salari = salari;
            this.Comissio = comissio;
            this.DeptNo = deptNo;
        }

        public Emp(Emp source)
        {
            this.EmpNo = source.EmpNo;
            this.Cognom = source.Cognom;
            this.Ofici = source.Ofici;
            this.Cap = source.Cap;
            this.Data_alta = source.Data_alta;
            this.Salari = source.Salari;
            this.Comissio = source.Comissio;
            this.DeptNo = source.DeptNo;
        }

        public int EmpNo { get => empNo; set => empNo = value; }
        public string Cognom { get => cognom; set => cognom = value; }
        public string Ofici { get => ofici; set => ofici = value; }
        public int Cap { get => cap; set => cap = value; }
        public DateTime Data_alta { get => data_alta; set => data_alta = value; }
        public decimal Salari { get => salari; set => salari = value; }


        private string salariS = null;

        public String SalariS
        {
            get
            {
                if (salariS == null)
                    return Salari.ToString();
                else
                    return salariS;
            }
            set {
                salariS = value;
            }
        }


        public decimal Comissio { get => comissio; set => comissio = value; }
        public int DeptNo { get => deptNo; set => deptNo = value; }
        public string NomCap { get => nomCap; set => nomCap = value; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

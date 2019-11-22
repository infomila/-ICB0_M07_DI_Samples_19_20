using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacioDM
{
    public class Emp
    {
        public int empNo ;
        public string cognom ;      
        public string ofici ;
        public int cap ;
        public string nomCap;
        public DateTime data_alta ;
        public decimal salari ;     
        public decimal comissio ;
        public int deptNo ;


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

        public int EmpNo { get => empNo; set => empNo = value; }
        public string Cognom { get => cognom; set => cognom = value; }
        public string Ofici { get => ofici; set => ofici = value; }
        public int Cap { get => cap; set => cap = value; }
        public DateTime Data_alta { get => data_alta; set => data_alta = value; }
        public decimal Salari { get => salari; set => salari = value; }
        public decimal Comissio { get => comissio; set => comissio = value; }
        public int DeptNo { get => deptNo; set => deptNo = value; }
        public string NomCap { get => nomCap; set => nomCap = value; }
    }
}

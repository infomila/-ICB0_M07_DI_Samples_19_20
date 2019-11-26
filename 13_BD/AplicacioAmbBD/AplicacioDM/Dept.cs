using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacioDM
{
    public class Dept
    {
        internal int deptNo;
        internal string dNom;
        internal string loc;

        public Dept() { }

        public Dept(int deptNo, string dNom, string loc)
        {
            this.DeptNo = deptNo;
            this.DNom = dNom;
            this.Loc = loc;
        }

        public int DeptNo { get => deptNo; set => deptNo = value; }
        public string DNom { get => dNom; set => dNom = value; }
        public string Loc { get => loc; set => loc = value; }
    }
}

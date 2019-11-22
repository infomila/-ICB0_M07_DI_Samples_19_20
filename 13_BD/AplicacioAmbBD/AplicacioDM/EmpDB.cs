using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;

namespace AplicacioDM
{
    public class EmpDB
    {

        public static ObservableCollection<Emp> getLlistaEmpleats()
        {
            using (EmpresaDBContext context = new EmpresaDBContext())
            {
                using (var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();

                    using (var consulta = connexio.CreateCommand())
                    {
                        consulta.CommandText = @"   select e.* , cap.cognom  as cognom_cap
                                                    from emp e left join emp cap on e.cap = cap.emp_no
                                                     ";
                        var reader = consulta.ExecuteReader();
                        ObservableCollection<Emp> empleats = new ObservableCollection<Emp>();
                        while (reader.Read())
                        {
                            Emp e = new Emp();
                            Llegeix(reader, out e.empNo, "EMP_NO");
                            Llegeix(reader, out e.cognom, "COGNOM");
                            Llegeix(reader, out e.ofici, "OFICI", "");
                            Llegeix(reader, out e.cap, "CAP", -1);
                            Llegeix(reader, out e.nomCap, "cognom_cap", "");
                            Llegeix(reader, out e.data_alta, "DATA_ALTA", DateTime.Today);
                            Llegeix(reader, out e.salari, "SALARI", 0);
                            Llegeix(reader, out e.comissio, "COMISSIO", 0);
                            Llegeix(reader, out e.deptNo, "DEPT_NO");

                            /*e.EmpNo = reader.GetInt32(reader.GetOrdinal("EMP_NO"));
                            e.Cognom = reader.GetString(reader.GetOrdinal("COGNOM"));
                            e.Ofici = reader.IsDBNull(reader.GetOrdinal("OFICI")) ? "" : reader.GetString(reader.GetOrdinal("OFICI"));
                            e.Cap = reader.GetInt32(reader.GetOrdinal("CAP"));
                            e.Data_alta = reader.GetDateTime(reader.GetOrdinal("DATA_ALTA"));
                            e.Salari = reader.GetDecimal(reader.GetOrdinal("SALARI"));
                            e.Comissio = reader.GetDecimal(reader.GetOrdinal("COMISSIO"));
                            e.DeptNo = reader.GetInt32(reader.GetOrdinal("DEPT_NO"));*/
                            empleats.Add(e);
                        }
                        return empleats;
                    }
                }
            }

        }

        // supermagic happy function
        private static void Llegeix(DbDataReader reader, out int valor, string nomColumna, int valorPerDefecte = -1)
        {
            valor = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                Type t = reader.GetFieldType(reader.GetOrdinal(nomColumna));

                valor = reader.GetInt32(ordinal);             
            }
        }

        private static void Llegeix(DbDataReader reader, out string valor, string nomColumna, string valorPerDefecte = "")
        {
            valor = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                Type t = reader.GetFieldType(reader.GetOrdinal(nomColumna));

                valor = reader.GetString(ordinal);
            }
        }

        private static void Llegeix(DbDataReader reader, out DateTime valor, string nomColumna, DateTime valorPerDefecte = new DateTime())
        {
            valor = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                Type t = reader.GetFieldType(reader.GetOrdinal(nomColumna));

                valor = reader.GetDateTime(ordinal);
            }
        }
        private static void Llegeix(DbDataReader reader, out Decimal valor, string nomColumna, Decimal valorPerDefecte = 0m)
        {
            valor = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                Type t = reader.GetFieldType(reader.GetOrdinal(nomColumna));

                valor = reader.GetDecimal(ordinal);
            }
        }

    }
}


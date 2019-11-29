using MetroLog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AplicacioDM
{
    public class DeptDB
    {
         
        public static ObservableCollection<Dept> getLlistaDepartaments()
        {
            try
            {

                using (EmpresaDBContext context = new EmpresaDBContext())
                {
                    using (var connexio = context.Database.GetDbConnection())
                    {
                        connexio.Open();

                        using (var consulta = connexio.CreateCommand())
                        {
                            consulta.CommandText = $@"  select * from dept  ";
                            var reader = consulta.ExecuteReader();
                            ObservableCollection<Dept> departaments = new ObservableCollection<Dept>();
                            while (reader.Read())
                            {
                                Dept d = new Dept();
                                DBUtils.Llegeix(reader, out d.deptNo, "DEPT_NO");
                                DBUtils.Llegeix(reader, out d.dNom, "DNOM");
                                DBUtils.Llegeix(reader, out d.loc, "LOC", "");
                                departaments.Add(d);
                            }
                            return departaments;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogger log = LogManagerFactory.DefaultLogManager.GetLogger<EmpDB>();
                log.Fatal("error durant la select dels departaments");
                return new ObservableCollection<Dept>();
            }

        }





    }
}

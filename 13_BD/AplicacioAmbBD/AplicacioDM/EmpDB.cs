using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AplicacioDM
{
    public class EmpDB
    {

        public static ObservableCollection<Emp> getLlistaEmpleats()
        {
            using(EmpresaDBContext context = new EmpresaDBContext())
            {
                using(var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();

                    using(var consulta = connexio.CreateCommand())
                    {
                        consulta.CommandText = @"select * 
                                                    from emp";
                        var reader = consulta.ExecuteReader();
                        ObservableCollection<Emp> empleats = new ObservableCollection<Emp>();
                        while(reader.Read())
                        {
                            Emp e = new Emp();
                            e.EmpNo =             reader.GetInt32(    reader.GetOrdinal("EMP_NO"));
                            e.Cognom =         reader.GetString(   reader.GetOrdinal("COGNOM"));
                            e.Ofici =          reader.GetString(   reader.GetOrdinal("OFICI"));
                            e.Cap =               reader.GetInt32(    reader.GetOrdinal("CAP"));
                            e.Data_alta =    reader.GetDateTime( reader.GetOrdinal("DATA_ALTA"));
                            e.Salari =        reader.GetDecimal(  reader.GetOrdinal("SALARI"));
                            e.Comissio =      reader.GetDecimal(  reader.GetOrdinal("COMISSIO"));
                            e.DeptNo =            reader.GetInt32(    reader.GetOrdinal("DEPT_NO"));
                            empleats.Add(e);
                        }
                        return empleats;
                    }
                }
            }
            
        }


    }
}

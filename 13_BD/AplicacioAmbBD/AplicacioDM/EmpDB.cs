using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Text;

namespace AplicacioDM
{
    public class EmpDB
    {
        public const int SENSE_DEPT = -1;

        public static ObservableCollection<Emp> getLlistaEmpleats()
        {
           return  getLlistaEmpleats("", DateTime.MinValue, SENSE_DEPT);
        }

        public static ObservableCollection<Emp> getLlistaEmpleats(
            string cognom, DateTime dataLimit, int numDept)
        {
            using (EmpresaDBContext context = new EmpresaDBContext())
            {
                using (var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();

                    using (var consulta = connexio.CreateCommand())
                    {
                        /*
                        consulta.CommandText =
                    $@"   select e.* , cap.cognom  as cognom_cap
                         from emp e left join emp cap on e.cap = cap.emp_no
                         where e.cognom like '%{cognom}%' and
                         e.data_alta >= '{dataLimit.ToString("yyyy-MM-dd")}'   
                         and ( {numDept}=-1 OR e.dept_no={numDept} )
                            ";

                        */
                        consulta.CommandText =
                    $@"   select e.* , cap.cognom  as cognom_cap
                         from emp e left join emp cap on e.cap = cap.emp_no
                         where e.cognom like @cognom and
                         e.data_alta >= @dataLimit    
                         and ( @numDept=-1 OR e.dept_no=@numDept )
                            ";
                        DBUtils.createParameter(consulta, "cognom", $"%{cognom}%", DbType.String);
                        DBUtils.createParameter(consulta, "dataLimit", dataLimit, DbType.DateTime);
                        DBUtils.createParameter(consulta, "numDept", numDept, DbType.Int32);

                        /*DbParameter paramCognom = consulta.CreateParameter();
                        paramCognom.ParameterName = "cognom";
                        paramCognom.Value = $"%{cognom}%";
                        paramCognom.DbType = System.Data.DbType.String;
                        consulta.Parameters.Add(paramCognom);*/




                        var reader = consulta.ExecuteReader();
                        ObservableCollection<Emp> empleats = new ObservableCollection<Emp>();
                        while (reader.Read())
                        {
                            Emp e = new Emp();
                            DBUtils.Llegeix(reader, out e.empNo, "EMP_NO");
                            DBUtils.Llegeix(reader, out e.cognom, "COGNOM");
                            DBUtils.Llegeix(reader, out e.ofici, "OFICI", "");
                            DBUtils.Llegeix(reader, out e.cap, "CAP", SENSE_DEPT);
                            DBUtils.Llegeix(reader, out e.nomCap, "cognom_cap", "");
                            DBUtils.Llegeix(reader, out e.data_alta, "DATA_ALTA", DateTime.Today);
                            DBUtils.Llegeix(reader, out e.salari, "SALARI", 0);
                            DBUtils.Llegeix(reader, out e.comissio, "COMISSIO", 0);
                            DBUtils.Llegeix(reader, out e.deptNo, "DEPT_NO");

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

        public static bool update(int empNo, string cognom, int salari, int deptNo)
        {
            using (EmpresaDBContext context = new EmpresaDBContext())
            {
                using (var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();

                    using (var consulta = connexio.CreateCommand())
                    {
                        // Creem transacció
                        DbTransaction transaction =  connexio.BeginTransaction();
                        consulta.Transaction = transaction; // Ara si que la consulta usa la transacció


                        //string cognom, int salari, int deptNo
                        consulta.CommandText =
                        $@"update emp set cognom = @cognom, salari = @salari , dept_no = @deptNo
                            where emp_no = @empNo";

                        DBUtils.createParameter(consulta, "cognom", cognom, DbType.String);
                        DBUtils.createParameter(consulta, "salari", salari, DbType.Int32);
                        DBUtils.createParameter(consulta, "deptNo", deptNo, DbType.Int32);
                        DBUtils.createParameter(consulta, "empNo", empNo, DbType.Int32);


                        int filesModificades = consulta.ExecuteNonQuery();
                        if(filesModificades==1)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            // OMG!
                            throw new Exception("error durant la inserció de l'empleat , filesModificades="+ filesModificades);
                            // rollback !!!!!!!!
                        }
                        return false;
                    }
                }
            }
        }
    }
}


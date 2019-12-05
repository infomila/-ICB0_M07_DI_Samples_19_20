using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace AplicacioDM
{
    public class DBUtils
    {
        public static void createParameter(
            DbCommand consulta,
            string nom, object valor, DbType tipus)
        {
            DbParameter param = consulta.CreateParameter();
            param.ParameterName = nom;
            param.Value = valor;
            param.DbType = tipus;
            consulta.Parameters.Add(param);
        }



        // supermagic happy function
        public static void Llegeix(DbDataReader reader, out int valor, string nomColumna, int valorPerDefecte = -1)
        {
            valor = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                Type t = reader.GetFieldType(reader.GetOrdinal(nomColumna));

                valor = reader.GetInt32(ordinal);
            }
        }
        public static void Llegeix(DbDataReader reader, out string valor, string nomColumna, string valorPerDefecte = "")
        {
            valor = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                Type t = reader.GetFieldType(reader.GetOrdinal(nomColumna));

                valor = reader.GetString(ordinal);
            }
        }
        public static void Llegeix(DbDataReader reader, out DateTime valor, string nomColumna, DateTime valorPerDefecte = new DateTime())
        {
            valor = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                Type t = reader.GetFieldType(reader.GetOrdinal(nomColumna));

                valor = reader.GetDateTime(ordinal);
            }
        }
        public static void Llegeix(DbDataReader reader, out Decimal valor, string nomColumna, Decimal valorPerDefecte = 0m)
        {
            valor = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                Type t = reader.GetFieldType(reader.GetOrdinal(nomColumna));

                valor = reader.GetDecimal(ordinal);
            }
        }

        internal static object GetId(DbConnection connexio, DbTransaction transaction, string table_name)
        {
                using (var consulta = connexio.CreateCommand())
                {
                    consulta.Transaction = transaction; // Ara si que la consulta usa la transacció

                    // 
                    consulta.CommandText =
                        $@"select last_id from ids where table_name=@table_name for update";
                    DBUtils.createParameter(consulta, "table_name", table_name, DbType.String);
                    object o = consulta.ExecuteScalar();
                    int last_id = (int)((decimal)o);
                    last_id++;
                    consulta.CommandText = $@"update ids set last_id=@last_id where table_name=@table_name ";
                    //DBUtils.createParameter(consulta, "table_name", table_name, DbType.String);
                    DBUtils.createParameter(consulta, "last_id", last_id, DbType.Int32);
                    int filesActualitzades = consulta.ExecuteNonQuery();

                    if (filesActualitzades != 1)
                    {
                        throw new Exception("Error actualitzant IDS");
                    }

                    return last_id;
                }
        }
        
    }
}

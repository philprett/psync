using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.extensions
{
    static class SQLiteConnectionExtensions
    {
        public static DataTable ExecuteQuery(this SQLiteConnection con, string sql, SQLiteParameter[] parameters = null)
        {
            var dt = new DataTable();
            var com = con.CreateCommand();
            com.CommandText = sql;
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    com.Parameters.Add(p);
                }
            }
            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter(com);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int ExecuteNonQuery(this SQLiteConnection con, string sql, SQLiteParameter[] parameters = null)
        {
            var com = con.CreateCommand();
            com.CommandText = sql;
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    com.Parameters.Add(p);
                }
            }
            try
            {
                int ret = com.ExecuteNonQuery();
                return ret;
            }
            catch
            {
                return -1;
            }
        }

        public static object ExecuteScalar(this SQLiteConnection con, string sql, SQLiteParameter[] parameters = null)
        {
            var com = con.CreateCommand();
            com.CommandText = sql;
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    com.Parameters.Add(p);
                }
            }
            try
            {
                object ret = com.ExecuteScalar();
                return ret;
            }
            catch
            {
                return null;
            }
        }

        public static int GetUniqueInt(this SQLiteConnection con, string table, string field)
        {
            Random rand = new Random();
            int i = 0;
            int found = 1;
            while (found > 0)
            {
                i = rand.Next();
                object tmp = con.ExecuteScalar(string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = @i", table, field), new[] { new SQLiteParameter("@i", i) });
                found = (int)(long)tmp;
            }
            return i;
        }
    }

}

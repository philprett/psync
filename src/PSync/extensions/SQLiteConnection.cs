using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.extensions
{
    /// <summary>
    /// Provide usefull extensions to the SQLiteConnection class
    /// </summary>
    static class SQLiteConnectionExtensions
    {
        /// <summary>
        /// Execute a select query on the database and return the results in a DataTable
        /// </summary>
        /// <param name="con"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Execute a query on the database and return the amount of rows affected
        /// </summary>
        /// <param name="con"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Execute a select query on the database and return the first column in the first row of the results.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get a random int value making sure it does not already exist in a particular field in a particular table
        /// </summary>
        /// <param name="con"></param>
        /// <param name="table"></param>
        /// <param name="field"></param>
        /// <returns></returns>
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

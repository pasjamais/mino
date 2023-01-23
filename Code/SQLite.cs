using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace mino
{
         public static class SQLite //: Database //Extending for future improvement (Making it object oriented later).
        {
            public static string apppath = @".\";
            public static bool DatabasePooling = true;
            private static string connStringFormat = "Data Source =mino.db; Version =3; Pooling ={0}; Max Pool Size =1000;";
        public static SQLiteParameterCollection parameters = new SQLiteCommand().Parameters;

            public static string connString { get { return String.Format(connStringFormat, DatabasePooling); } }
            //[Obsolete("Preferably use Database.executeQuery instead")]
            public static void executeQuery(string queryString)
            {
            //Database.executeQuery(queryString);
            try
            {
                execute(queryString);

            }
            catch (Exception ex)
            { }
            finally
            {
                ClearParams();
            }
        }
        //[Obsolete("Preferably use Database.executeQuery instead")]
        public static DataTable fillData(string queryString, bool skipError = false)
        {
            using (DataTable toReturn = new DataTable("toReturn"))
            {
                try
                {
                    fill(queryString, toReturn);

                }
                catch (Exception e)
                {

                }
                finally
                {
                    ClearParams();
                }
                return toReturn;
            }
        }

            /// <summary>
            /// Adds a parameter to the parameterized SQLite query.
            /// Use this before executing the query.
            /// </summary>
            /// <param name="name">The name of the parameter</param>
            /// <param name="param">The value of the parameter</param>
            public static void AddParams(string name, object param)
            {
                parameters.AddWithValue(name, param);
            }
            /// <summary>
            /// Clears the parameters added with <see cref="MCForge.SQL.MySQL.AddParams(System.string, System.string)"/>
            /// <seealso cref="MCForge.SQL.MySQL"/>
            /// </summary>
            public static void ClearParams()
            {
                parameters.Clear();
            }
            private static void AddSQLiteParameters(SQLiteCommand command)
            {
                foreach (SQLiteParameter param in parameters)
                    command.Parameters.Add(param);
            }
            private static void AddSQLiteParameters(SQLiteDataAdapter dAdapter)
            {
                foreach (SQLiteParameter param in parameters)
                    dAdapter.SelectCommand.Parameters.Add(param);
            }

            private static void execute(string queryString)
            {
                using (var conn = new SQLiteConnection(SQLite.connString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(queryString, conn))
                    {
                        AddSQLiteParameters(cmd);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            internal static void fill(string queryString, DataTable toReturn)
            {
                using (var conn = new SQLiteConnection(SQLite.connString))
                {
                    conn.Open();
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(queryString, conn))
                    {
                        AddSQLiteParameters(da);
                        da.Fill(toReturn);
                    }
                    conn.Close();
                }
            }
        }
    }
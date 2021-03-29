using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air3550
{
    public class SqliteDataAccess
    {
        public static void getRand()
        {
            SQLiteConnection con = new SQLiteConnection(LoadConnectionString());
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM userIDTable ORDER BY RANDOM() LIMIT 1";
            cmd.Connection = con;
            SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0)}");
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}

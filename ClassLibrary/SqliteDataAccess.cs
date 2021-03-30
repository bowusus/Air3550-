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
        // This class file will include any methods that touch the database, 
        // For example, the method to get a random user id is included in this file.
        public static int GetRandUserID()
        {
            // This method goes into the database, specifically the userID table, 
            // and random picks one userID then deletes that record, so it is a unique id
            // for every user. It returns this unique userID
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString())) 
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand(); 
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM userIDTable ORDER BY RANDOM() LIMIT 1"; // write the sql command // remember to delete value
                cmd.Connection = con;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                SQLiteDataReader rdr = cmd.ExecuteReader(); 
                int currUserID = 0; // used to return id

                while (rdr.Read())
                {
                    currUserID = rdr.GetInt32(0);
                }
                return currUserID; // return user id
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}

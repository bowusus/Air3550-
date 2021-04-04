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
        public static int CheckIfNewCustomer(string tempEmail)
        {
            // This method goes into the database, specifically the customer table, 
            // and checks if there are any rows that currently contain the email that 
            // the customer is trying to create a new account with
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT count(*) FROM customer where customer.email = @email";
                cmd.Parameters.AddWithValue("@email", tempEmail.ToLower());
                cmd.Connection = con;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int count = 0; // used to return count

                while (rdr.Read())
                {
                    count = rdr.GetInt32(0);
                }
                return count; // return count with that email
            }
        }
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
                cmd.CommandText = "SELECT * FROM userIDTable ORDER BY RANDOM() LIMIT 1"; // remember to delete value
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
        public static void CreateAccount(int tempUserID, string pass, string first, string last, string street1, string city1, string state1, string zip, string phone, string creditCardNumber1, int age1, string email1)
        {
            // This method goes into the database, specifically the customer table, 
            // and adds the customer to the table with the provided information
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO customer(userID, password, firstName, lastName, street, city, state, zipCode, phoneNumber, creditCardNumber, age, email) VALUES (@userID, @password, @firstName, @lastName, @street, @city, @state, @zipCode, @phoneNumber, @creditCardNumber, @age, @email)";
                cmd.Connection = con;
                // use the customer's information to input into the database
                cmd.Parameters.AddWithValue("@userID", tempUserID);
                cmd.Parameters.AddWithValue("@password", pass);
                cmd.Parameters.AddWithValue("@firstName", first);
                cmd.Parameters.AddWithValue("@lastName", last);
                cmd.Parameters.AddWithValue("@street", street1);
                cmd.Parameters.AddWithValue("@city", city1);
                cmd.Parameters.AddWithValue("@state", state1);
                cmd.Parameters.AddWithValue("@zipCode", zip);
                cmd.Parameters.AddWithValue("@phoneNumber", phone);
                cmd.Parameters.AddWithValue("@creditCardNumber", creditCardNumber1);
                cmd.Parameters.AddWithValue("@age", age1);
                cmd.Parameters.AddWithValue("@email", email1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static int GetPassword(int userID, string currPass)
        {
            // This method goes into the database, specifically the customer table
            // and gets the current (encrypted) password asssociated with the UserID provided
            // When the provided password is encrypted, if they are the same string, then
            // the userID and password are correct. Return 1
            // If the provided password and password in the database are not the same string,
            // then the password is incorrect. Return 0
            // If the UserID is not in the database, the user is not a current user. Return -1
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT customer.password FROM customer where customer.userID = @userID";
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Connection = con;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                SQLiteDataReader rdr = cmd.ExecuteReader();
                string pass = null; // used to return id

                while (rdr.Read())
                {
                    pass = rdr.GetString(0); // get the password from the database
                }
                if (pass == null) // if there is no password in the database, that means the userID is not in the database and the user is not a customer
                    return -1;
                string encryptPass = ClassLibrary.SystemAction.EncryptPassword(currPass);
                // if the encryption of the provided password is the same as the encrypted password in the database, the user is logged. Return 1
                // if they are different, the wrong password was provided. Return 0
                if (encryptPass.Equals(pass))
                    return 1;
                else
                    return 0;
            }
        }
        public static void UpdateUser(int tempUserID, string pass, string first, string last, string street1, string city1, string state1, string zip, string phone, string creditCardNumber1, int age1, string email1)
        {
            // This method goes into the database, specifically the customer table, 
            // and updates the specified customer in the table with the provided information
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                // if the password is not updated then do not change the password. Everything is else is included in the update
                // if the password is updated, include the password in the sql script and update the password (that was already hashed)
                if (String.IsNullOrEmpty(pass))
                    cmd.CommandText = "UPDATE customer set firstName = @firstName, lastName = @lastName, street = @street, city = @city, state = @state, zipCode = @zipCode, phoneNumber = @phoneNumber, creditCardNumber = @creditCardNumber, age = @age, email = @email where customer.userID = @userID";
                else
                {
                    cmd.CommandText = "UPDATE customer set firstName = @firstName, lastName = @lastName, password = @password, street = @street, city = @city, state = @state, zipCode = @zipCode, phoneNumber = @phoneNumber, creditCardNumber = @creditCardNumber, age = @age, email = @email where customer.userID = @userID";
                    cmd.Parameters.AddWithValue("@password", pass);
                }
                cmd.Parameters.AddWithValue("@userID", tempUserID);
                cmd.Parameters.AddWithValue("@firstName", first);
                cmd.Parameters.AddWithValue("@lastName", last);
                cmd.Parameters.AddWithValue("@street", street1);
                cmd.Parameters.AddWithValue("@city", city1);
                cmd.Parameters.AddWithValue("@state", state1);
                cmd.Parameters.AddWithValue("@zipCode", zip);
                cmd.Parameters.AddWithValue("@phoneNumber", phone);
                cmd.Parameters.AddWithValue("@creditCardNumber", creditCardNumber1);
                cmd.Parameters.AddWithValue("@age", age1);
                cmd.Parameters.AddWithValue("@email", email1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            // This method helps connect to the database
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}

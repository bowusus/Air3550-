﻿using ClassLibrary;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
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
                cmd.CommandText = "select count(*) from customer where customer.email = @email";
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
                cmd.CommandText = "select * from userIDTable order by random() limit 1"; // remember to delete value
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
                cmd.CommandText = "insert into customer(userID, password, firstName, lastName, street, city, state, zipCode, phoneNumber, creditCardNumber, age, email) values (@userID, @password, @firstName, @lastName, @street, @city, @state, @zipCode, @phoneNumber, @creditCardNumber, @age, @email)";
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
        public static int CheckPassword(int userID, string currPass)
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
                cmd.CommandText = "select customer.password from customer where customer.userID = @userID";
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
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
        public static List<string> GetUserData(int userID)
        {
            // This method goes into the database, specifically the customer table, 
            // and retrieves all of the user data and returns it as a list of strings
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where customer.userID = @userID";
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Connection = con;
                List<string> data = new List<string>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    data.Add(reader[0].ToString());
                    data.Add(reader[1].ToString());
                    data.Add(reader[2].ToString());
                    data.Add(reader[3].ToString());
                    data.Add(reader[4].ToString());
                    data.Add(reader[5].ToString());
                    data.Add(reader[6].ToString());
                    data.Add(reader[7].ToString());
                    data.Add(reader[8].ToString());
                    data.Add(reader[9].ToString());
                    data.Add(reader[10].ToString());
                    data.Add(reader[11].ToString());
                }
                return data; // return user data
            }
        }
        public static List<int> GetCurrentFlightIDs(int userID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and retrieves all of the customer's booked flights and returns this list
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select flightsBooked.flightID_fk from flightsBooked where flightsBooked.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                List<int> flightIDsList = new List<int>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    flightIDsList.Add(rdr.GetInt32(0));
                }
                return flightIDsList; // return user data
            }
        }
        public static string GetFlightNames(string code)
        {
            // This method goes into the database, specifically the airport table, 
            // and retrieves all of the airport names associated with the airport codes
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select airport.airportName from airport where airport.airportCode = @airportCode";
                cmd.Parameters.AddWithValue("@airportCode", code);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                string airportName = null;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    airportName = rdr.GetString(0); // get the airport name from the database
                }
                return airportName; // return airport name
            }
        }
        public static List<string> GetFlightData(int flightID)
        {
            // This method goes into the database, specifically the availableFlight table, 
            // and retrieves all of the flight data and returns it as a list of strings
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from availableFlight where flightID = @flightID"; 
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Connection = con;
                List<string> flightData = new List<string>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    flightData.Add(reader[0].ToString());
                    flightData.Add(reader[1].ToString());
                    flightData.Add(reader[2].ToString());
                    flightData.Add(reader[3].ToString());
                    flightData.Add(reader[4].ToString());
                    flightData.Add(reader[5].ToString());
                    flightData.Add(reader[6].ToString());
                    flightData.Add(reader[7].ToString());
                    flightData.Add(reader[8].ToString());
                    flightData.Add(reader[9].ToString());
                    flightData.Add(reader[10].ToString());
                    flightData.Add(reader[11].ToString());
                }
                return flightData; // return flight data
            }
        }
        public static void CancelBookedFlight(int userID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and removes specific flights with the userID
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from flightsBooked where flightsBooked.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void AddToCancelledFlights(int userID, int flightID)
        {
            // This method goes into the database, specifically the flightsCancelled table, 
            // and adds the cancelled flight
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into flightsCancelled values (@userID_fk, @flightID_fk)";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static string GetPaymentMethod(int userID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and returns a string with the payment method that the customer used
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select flightsBooked.paymentMethod from flightsBooked where flightsBooked.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                SQLiteDataReader rdr = cmd.ExecuteReader();
                string paymentMethod = null; // used to return payment method

                while (rdr.Read())
                {
                    paymentMethod = rdr.GetString(0);
                }
                return paymentMethod; // return payment method
            }
        }
        public static int GetBalance(int userID)
        {
            // This method goes into the database, specifically the credits table,
            // and gets the current available balance of the customer
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select credits.balanceAvailable from credits where credits.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int balance = 0; // used to return id

                while (rdr.Read())
                {
                    balance = rdr.GetInt32(0);
                }
                return balance; // return user id
            }
        }
        public static void UpdateBalance(int userID, double balance)
        {
            // This method goes into the database, specifically the credits table, 
            // and updates the customer's available balance if they paid cash for a flight they are cancelling
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update credits set balanceAvailable = @balanceAvailable where credits.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@balanceAvailable", balance);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static int GetAvailablePoints(int userID)
        {
            // This method goes into the database, specifically the credits table,
            // and gets the current available points of the customer
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select credits.pointsAvailable from credits where credits.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int pointsAvailable = 0; // used to return id

                while (rdr.Read())
                {
                    pointsAvailable = rdr.GetInt32(0);
                }
                return pointsAvailable; // return user id
            }
        }
        public static void UpdateAvailablePoints(int userID, int points)
        {
            // This method goes into the database, specifically the credits table, 
            // and updates the customer's available points if they paid with points for a flight they are cancelling
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update credits set pointsAvailable = @pointsAvailable where credits.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@pointsAvailable", points);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static int GetUsedPoints(int userID)
        {
            // This method goes into the database, specifically the credits table,
            // and gets the current used points of the customer
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select credits.pointsUsed from credits where credits.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int pointsUsed = 0; // used to return id

                while (rdr.Read())
                {
                    pointsUsed = rdr.GetInt32(0);
                }
                return pointsUsed; // return user id
            }
        }
        public static void UpdateUsedPoints(int userID, int points)
        {
            // This method goes into the database, specifically the credits table, 
            // and updates the customer's used points if they paid with points for a flight they are cancelling
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update credits set pointsAvailable = @pointsAvailable where credits.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@pointsAvailable", points);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void UpdateNumOfVacantSeats(int flightID, int num)
        {
            // This method goes into the database, specifically the availableFlights table, 
            // and updates the number of vacant seats on a flight after a customer cancels their flight
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update availableFlight set numOfVacantSeats = @numOfVacantSeats where availableFlight.flightID = @flightID";
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Parameters.AddWithValue("@numOfVacantSeats", num);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void UpdateFlightIncome(int flightID, double num)
        {
            // This method goes into the database, specifically the availableFlights table, 
            // and updates the flight's income after a customer cancels their flight
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update availableFlight set flightIncome = @flightIncome where availableFlight.flightID = @flightID";
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Parameters.AddWithValue("@flightIncome", num);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
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

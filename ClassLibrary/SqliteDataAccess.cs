using ClassLibrary;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class SqliteDataAccess
    {
        // This class file will include any methods that touch the database, 
        // For example, the method to get a random user id is included in this file.
        public static string CheckIfEmployee(int userID, string pass)
        {
            // This method goes into the database, specifically the employee table, 
            // and checks if there are any rows that currently contain the userID and password that 
            // the user is logging in with
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                string password = SystemAction.EncryptPassword(pass);
                cmd.CommandText = "select employee.role from employee where employee.userID = @userID and employee.password = @password";
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Connection = con;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                SQLiteDataReader rdr = cmd.ExecuteReader();
                string role = null;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    role = rdr.GetString(0); // get the airport name from the database
                }
                if (String.IsNullOrEmpty(role))
                    role = "employee";
                rdr.Close();
                con.Close();
                return role; // return airport name
            }
        }
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
                rdr.Close();
                con.Close();
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
                rdr.Close();
                con.Close();
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
        public static void AddCustomerToCredits(int tempUserID)
        {
            // This method goes into the database, specifically the credits table, 
            // and adds the customer to the credits table with default values
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into credits(userID_fk) values(@userID_fk)";
                cmd.Connection = con;
                // use the customer's information to input into the database
                cmd.Parameters.AddWithValue("@userID_fk", tempUserID);
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
                rdr.Close();
                con.Close();
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
                    reader.Close();
                }
                con.Close();
                return data; // return user data
            }
        }
        public static void AddToFlightsBooked(int userID, int flightID, int routeID, string paymentMethod)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and adds the booked flight
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into flightsBooked values (@userID_fk, @flightID_fk, @routeID_fk, @paymentMethod)";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
                cmd.Parameters.AddWithValue("@routeID_fk", routeID);
                cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void AddTransaction(int userID, int flightID, double amount, string paymentMethod)
        {
            // This method goes into the database, specifically the transaction table, 
            // and adds the transaction
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into transactionTable values (@userID_fk, @flightID_fk, @amount, @paymentMethod)";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void DeleteTransaction(int userID, int flightID)
        {
            // This method goes into the database, specifically the transaction table, 
            // and removes the specfied transaction
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from transactionTable where transactionTable.userID_fk = @userID_fk and transactionTable.flightID_fk = @flightID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static List<(int, int)> GetRouteInfo(string origin, string destination)
        {
            // This method goes into the database, specifically the route table, 
            // and retrieves all of the routes with the specified originCode and destinationCode
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select route.routeID, route.numOfLayovers from route where route.originCode_fk = @originCode_fk and route.destinationCode_fk = @destinationCode_fk";
                cmd.Parameters.AddWithValue("@originCode_fk", origin);
                cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                cmd.Connection = con;
                List<(int, int)> routeIDs = new List<(int, int)>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                SQLiteDataReader rdr = cmd.ExecuteReader();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    routeIDs.Add((rdr.GetInt32(0), rdr.GetInt32(1)));
                }
                rdr.Close();
                con.Close();
                return routeIDs;
            }
        }
        public static List<int> GetBookedFlightsRouteID(int userID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and retrieves all of the route IDs of the customer's booked flights and returns this list
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct flightsBooked.routeID_fk from flightsBooked where flightsBooked.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                List<int> routeID = new List<int>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    routeID.Add(rdr.GetInt32(0));
                }
                rdr.Close();
                con.Close();
                return routeID; 
            }
        }
        public static List<int> GetFlightIDsInRoute(int routeID)
        {
            // This method goes into the database, specifically the route table, 
            // and retrieves all of the flightIDs in this route
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from route where route.routeID = @routeID";
                cmd.Parameters.AddWithValue("@routeID", routeID);
                cmd.Connection = con;
                List<int> flightIDs = new List<int>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    flightIDs.Add(reader.GetInt32(4));
                    if (!String.IsNullOrEmpty(reader[5].ToString()))
                        flightIDs.Add(reader.GetInt32(5));
                    if (!String.IsNullOrEmpty(reader[6].ToString()))
                        flightIDs.Add(reader.GetInt32(6));
                    reader.Close();
                }
                con.Close();
                return flightIDs; // return user data
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
                rdr.Close();
                con.Close();
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
                    reader.Close();
                }
                con.Close();
                return flightData; // return flight data
            }
        }
        public static void CancelBookedFlight(int userID, int flightID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and removes specific flights with the userID
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from flightsBooked where flightsBooked.userID_fk = @userID_fk and flightsBooked.flightID_fk = @flightID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
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
        public static string GetPaymentMethod(int userID, int flightID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and returns a string with the payment method that the customer used
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select flightsBooked.paymentMethod from flightsBooked where flightsBooked.userID_fk = @userID_fk and flightsBooked.flightID_fk = @flightID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
                cmd.Connection = con;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                SQLiteDataReader rdr = cmd.ExecuteReader();
                string paymentMethod = null; // used to return payment method

                while (rdr.Read())
                {
                    paymentMethod = rdr.GetString(0);
                }
                rdr.Close();
                con.Close();
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
                rdr.Close();
                con.Close();
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
                rdr.Close();
                con.Close();
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
                int pointsUsed = 0;

                while (rdr.Read())
                {
                    pointsUsed = rdr.GetInt32(0);
                }
                rdr.Close();
                con.Close();
                return pointsUsed; 
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
                cmd.CommandText = "update credits set pointsUsed = @pointsUsed where credits.userID_fk = @userID_fk";
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@pointsUsed", points);
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
                if (String.IsNullOrEmpty(pass) && creditCardNumber1 != "    -    -    -")
                {
                    cmd.CommandText = "UPDATE customer set firstName = @firstName, lastName = @lastName, street = @street, city = @city, state = @state, zipCode = @zipCode, phoneNumber = @phoneNumber, creditCardNumber = @creditCardNumber, age = @age, email = @email where customer.userID = @userID";
                    cmd.Parameters.AddWithValue("@creditCardNumber", creditCardNumber1);
                }
                else if (!String.IsNullOrEmpty(pass) && creditCardNumber1 == "    -    -    -")
                {
                    cmd.CommandText = "UPDATE customer set firstName = @firstName, lastName = @lastName, password = @password, street = @street, city = @city, state = @state, zipCode = @zipCode, phoneNumber = @phoneNumber, age = @age, email = @email where customer.userID = @userID";
                    cmd.Parameters.AddWithValue("@password", pass);
                }
                else if (String.IsNullOrEmpty(pass) && creditCardNumber1 == "    -    -    -")
                    cmd.CommandText = "UPDATE customer set firstName = @firstName, lastName = @lastName, street = @street, city = @city, state = @state, zipCode = @zipCode, phoneNumber = @phoneNumber, age = @age, email = @email where customer.userID = @userID";
                else
                {
                    cmd.CommandText = "UPDATE customer set firstName = @firstName, lastName = @lastName, password = @password, street = @street, city = @city, state = @state, zipCode = @zipCode, phoneNumber = @phoneNumber, creditCardNumber = @creditCardNumber, age = @age, email = @email where customer.userID = @userID";
                    cmd.Parameters.AddWithValue("@creditCardNumber", creditCardNumber1);
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
                cmd.Parameters.AddWithValue("@age", age1);
                cmd.Parameters.AddWithValue("@email", email1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static List<Airport> GetAirports()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                List<Airport> airports = new List<Airport>();
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT airportCode, airportName FROM airport";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    airports.Add(new Airport(rdr.GetString(0), rdr.GetString(1)));
                }
                rdr.Close();
                con.Close();
                return airports;
            }
        }
        public static List<FlightModel> GetDirectFlights()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                List<FlightModel> directFlights = new List<FlightModel>();
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT originCode_fk, destinationCode_fk, distance FROM directFlight";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    directFlights.Add(new FlightModel(rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2)));
                }
                rdr.Close();
                con.Close();
                return directFlights;
            }
        }

        public static DataTable GetMasterFlightDT()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM masterFlight";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(rdr);
                rdr.Close();
                con.Close();
                return dt;
            }
        }

        public static List<String> GetAirportCodes()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                List<string> airportCodes = new List<string>();
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT airportCode FROM airport";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    airportCodes.Add(rdr.GetString(0));
                }
                rdr.Close();
                con.Close();
                return airportCodes;
            }
        }

        public static void AddFlightToMaster(FlightModel[] flightModels)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                if (flightModels.Length == 1)
                {

                    cmd.CommandText = "INSERT INTO masterFlight VALUES (@flightID, @originCode_fk, @destinationCode_fk, @distance, @departureTime, @planeType, @numberOfVacantSeats)";
                    cmd.Parameters.AddWithValue("@flightID", flightModels[0].flightID);
                    cmd.Parameters.AddWithValue("@originCode_fk", flightModels[0].originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", flightModels[0].destinationCode);
                    cmd.Parameters.AddWithValue("@distance", flightModels[0].distance);
                    cmd.Parameters.AddWithValue("@departureTime", flightModels[0].departureDateTime.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@planeType", flightModels[0].planeType);
                    cmd.Parameters.AddWithValue("@numberOfVacantSeats", flightModels[0].numberOfVacantSeats);
                }
                else if (flightModels.Length == 2)
                {
                    cmd.CommandText = @"BEGIN TRANSACTION;
                                        INSERT INTO masterFlight 
                                        VALUES (@flightID1, @originCode_fk1, @destinationCode_fk1, @distance1, @departureTime1, @planeType1, @numberOfVacantSeats1);
                                        INSERT INTO masterFlight 
                                        VALUES (@flightID2, @originCode_fk2, @destinationCode_fk2, @distance2, @departureTime2, @planeType2, @numberOfVacantSeats2);
                                        COMMIT";
                    cmd.Parameters.AddWithValue("@flightID1", flightModels[0].flightID);
                    cmd.Parameters.AddWithValue("@originCode_fk1", flightModels[0].originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk1", flightModels[0].destinationCode);
                    cmd.Parameters.AddWithValue("@distance1", flightModels[0].distance);
                    cmd.Parameters.AddWithValue("@departureTime1", flightModels[0].departureDateTime.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@planeType1", flightModels[0].planeType);
                    cmd.Parameters.AddWithValue("@numberOfVacantSeats1", flightModels[0].numberOfVacantSeats);
                    cmd.Parameters.AddWithValue("@flightID2", flightModels[1].flightID);
                    cmd.Parameters.AddWithValue("@originCode_fk2", flightModels[1].originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk2", flightModels[1].destinationCode);
                    cmd.Parameters.AddWithValue("@distance2", flightModels[1].distance);
                    cmd.Parameters.AddWithValue("@departureTime2", flightModels[1].departureDateTime.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@planeType2", flightModels[1].planeType);
                    cmd.Parameters.AddWithValue("@numberOfVacantSeats2", flightModels[1].numberOfVacantSeats);
                }
                else if (flightModels.Length == 3)
                {
                    cmd.CommandText = @"BEGIN TRANSACTION;
                                        INSERT INTO masterFlight 
                                        VALUES (@flightID1, @originCode_fk1, @destinationCode_fk1, @distance1, @departureTime1, @planeType1, @numberOfVacantSeats1);
                                        INSERT INTO masterFlight 
                                        VALUES (@flightID2, @originCode_fk2, @destinationCode_fk2, @distance2, @departureTime2, @planeType2, @numberOfVacantSeats2);
                                        INSERT INTO masterFlight
                                        VALUES (@flightID3, @originCode_fk3, @destinationCode_fk3, @distance3, @departureTime3, @planeType3, @numberOfVacantSeats3);
                                        COMMIT";
                    cmd.Parameters.AddWithValue("@flightID1", flightModels[0].flightID);
                    cmd.Parameters.AddWithValue("@originCode_fk1", flightModels[0].originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk1", flightModels[0].destinationCode);
                    cmd.Parameters.AddWithValue("@distance1", flightModels[0].distance);
                    cmd.Parameters.AddWithValue("@departureTime1", flightModels[0].departureDateTime.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@planeType1", flightModels[0].planeType);
                    cmd.Parameters.AddWithValue("@numberOfVacantSeats1", flightModels[0].numberOfVacantSeats);
                    cmd.Parameters.AddWithValue("@flightID2", flightModels[1].flightID);
                    cmd.Parameters.AddWithValue("@originCode_fk2", flightModels[1].originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk2", flightModels[1].destinationCode);
                    cmd.Parameters.AddWithValue("@distance2", flightModels[1].distance);
                    cmd.Parameters.AddWithValue("@departureTime2", flightModels[1].departureDateTime.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@planeType2", flightModels[1].planeType);
                    cmd.Parameters.AddWithValue("@numberOfVacantSeats2", flightModels[1].numberOfVacantSeats);
                    cmd.Parameters.AddWithValue("@flightID3", flightModels[2].flightID);
                    cmd.Parameters.AddWithValue("@originCode_fk3", flightModels[2].originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk3", flightModels[2].destinationCode);
                    cmd.Parameters.AddWithValue("@distance3", flightModels[2].distance);
                    cmd.Parameters.AddWithValue("@departureTime3", flightModels[2].departureDateTime.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@planeType3", flightModels[2].planeType);
                    cmd.Parameters.AddWithValue("@numberOfVacantSeats3", flightModels[2].numberOfVacantSeats);
                }
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static int GetLastMasterFlightID()
        {
            int newID = 1;
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT flightID FROM masterFlight WHERE flightID=(SELECT max(flightID) FROM masterFlight)";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) newID = rdr.GetInt32(0);
                newID++;
                rdr.Close();
                con.Close();
            }
            return newID;
        }

        public static int GetDirectFlightDistance(string originCode, string destinationCode)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                int distance = 0;
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT distance FROM directFlight WHERE directFlight.originCode_fk = @originCode_fk AND directFlight.destinationCode_fk = @destinationCode_fk";
                cmd.Parameters.AddWithValue("@originCode_fk", originCode);
                cmd.Parameters.AddWithValue("@destinationCode_fk", destinationCode);
                cmd.Connection = con;

                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) distance = rdr.GetInt32(0);
                rdr.Close();
                con.Close();
                return distance;
            }
        }

        public static void RemoveMasterFlight(int flightID)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM masterFlight WHERE masterFlight.flightID = @flightID";
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static int CheckMasterFlightEmpty()
        {
            int numOfRows = 0;
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) AS RowCnt FROM masterFlight";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) numOfRows = rdr.GetInt32(0);
                rdr.Close();
                con.Close();
            }
            return numOfRows;
        }

        public static void ChangeTimeMaster(int flightID, DateTime departureTime)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE masterFlight SET departureTime = @departureTime WHERE flightID = @flightID";
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Parameters.AddWithValue("@departureTime", departureTime.ToShortTimeString());
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static List<FlightModel> GetAllMasterFlights()
        {
            List<FlightModel> masterFlights = new List<FlightModel>();

            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM masterFlight";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    masterFlights.Add(new FlightModel(rdr.GetInt32(0), rdr.GetString(1), 
                        rdr.GetString(2), rdr.GetInt32(3), Convert.ToDateTime(rdr.GetString(4)),
                        rdr.GetString(5)));
                }
            }
                return masterFlights;
        }

        public static Boolean MasterFlightExists(string originCode, string destinationCode, string departureTime)
        {

            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT 1 FROM masterFlight " +
                                  "WHERE masterFlight.originCode_fk = @originCode_fk " +
                                  "AND masterFlight.destinationCode_fk = @destinationCode_fk " +
                                  "AND masterFlight.departureTime = @departureTime";
                cmd.Parameters.AddWithValue("@originCode_fk", originCode);
                cmd.Parameters.AddWithValue("@destinationCode_fk", destinationCode);
                cmd.Parameters.AddWithValue("@departureTime", departureTime);
                cmd.Connection = con;

                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    rdr.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    rdr.Close();
                    con.Close();
                    return false;
                }
            }
        }

        public static int GetPlaneCapacity(string planeType)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                int capacity = 0;
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT capacity FROM plane WHERE plane.planeType = @planeType";
                cmd.Parameters.AddWithValue("@planeType", planeType);
                cmd.Connection = con;

                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) capacity = rdr.GetInt32(0);
                rdr.Close();
                con.Close();
                return capacity;
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            // This method helps connect to the database
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}

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
                    role = rdr.GetString(0); // get the employee role
                }
                if (String.IsNullOrEmpty(role))
                    role = "employee"; // if there is no employee role, then the user is a customer
                rdr.Close();
                con.Close();
                return role; // return the empployee role
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
                return count; // return row count with that email
            }
        }
        public static int GetRandUserID()
        {
            // This method goes into the database, specifically the userID table, 
            // and randomly picks one userID, so it is a unique id
            // for every user. It returns this unique userID
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from userIDTable order by random() limit 1";
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
        public static void RemoveFromUserIDTable(int userID)
        {
            // This method goes into the database, specifically the userID table, 
            // and removes the userID so no other user has it as well
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM userIDTable WHERE userIDTable.userID = @userID";
                // use the provided information to add to the flightsBooked table
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
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
                // use the customer's userID to input into the credits table
                cmd.Parameters.AddWithValue("@userID_fk", tempUserID);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static int CheckPassword(int userID, string currPass)
        {
            // This method goes into the database, specifically the customer table,
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
                // add of the customer's data to a list of strings to use elsewhere
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
                // use the provided information to add to the flightsBooked table
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
                cmd.Parameters.AddWithValue("@routeID_fk", routeID);
                cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void AddTransaction(int userID, int flightID, double amount, string paymentMethod, DateTime departDate)
        {
            // This method goes into the database, specifically the transaction table 
            // and adds the transaction
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into transactionTable values (@userID_fk, @flightID_fk, @amount, @paymentMethod, @departDate)";
                // use the provided information to add to the transaction table
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                cmd.Parameters.AddWithValue("@departDate", departDate.ToString("yyyy-MM-dd"));
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
                // delete the specified transaction from the table when the customer has cancelled that flight
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static List<(int, int)> GetRouteInfo(string origin, string destination, DateTime departDate, DateTime returnDate)
        {
            // This method goes into the database, specifically the route table, 
            // and retrieves all of the routes with the specified originCode and destinationCode
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                if (returnDate.Date != DateTime.MinValue)
                {
                    cmd.CommandText = "select route.routeID, route.numOfLayovers from route where route.originCode_fk = @originCode_fk and route.destinationCode_fk = @destinationCode_fk and (date(route.lastFlightDate) not between date(@departDate) and date(@returnDate) or route.lastFlightDate is NULL)";
                    cmd.Parameters.AddWithValue("@returnDate", returnDate.Date);
                }
                else
                    cmd.CommandText = "select route.routeID, route.numOfLayovers from route where route.originCode_fk = @originCode_fk and route.destinationCode_fk = @destinationCode_fk and (date(route.lastFlightDate) != date(@departDate) or route.lastFlightDate is NULL)";
                // use the specified information to get the routeID and number of Layovers
                cmd.Parameters.AddWithValue("@originCode_fk", origin);
                cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                cmd.Parameters.AddWithValue("@departDate", departDate.Date);
                cmd.Connection = con;
                List<(int, int)> routeIDs = new List<(int, int)>();
                SQLiteDataReader rdr = cmd.ExecuteReader();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    // add the values to the list as a pair
                    routeIDs.Add((rdr.GetInt32(0), rdr.GetInt32(1)));
                }
                rdr.Close();
                con.Close();
                return routeIDs; // return the information
            }
        }
        public static int GetBookedFlightsRouteID(int flightID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and retrieves the route ID of the specified flight
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select flightsBooked.routeID_fk from flightsBooked where flightsBooked.flightID_fk = @flightID";
                // use the userID to get the correct routeIDs
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int routeID = 0;
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    routeID = rdr.GetInt32(0);
                }
                rdr.Close();
                con.Close();
                return routeID;
            }
        }
        public static List<int> GetBookedFlightIDs(int userID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and retrieves all of the flight IDs of the customer's booked flights and returns this list
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select flightsBooked.flightID_fk from flightsBooked where flightsBooked.userID_fk = @userID_fk";
                // use the userID to get the current booked flights
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                List<int> flightIDs = new List<int>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    flightIDs.Add(rdr.GetInt32(0));
                }
                rdr.Close();
                con.Close();
                return flightIDs; // return the currently booked flightIDs
            }
        }
        public static List<int> GetCancelledFlightIDs(int userID)
        {
            // This method goes into the database, specifically the flightsCancelled table, 
            // and retrieves all of the flight IDs of the customer's cancelled flights and returns this list
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select flightsCancelled.flightID_fk from flightsCancelled where flightsCancelled.userID_fk = @userID_fk";
                // use the userID to get the cancelled flights
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                List<int> flightIDs = new List<int>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    flightIDs.Add(rdr.GetInt32(0));
                }
                rdr.Close();
                con.Close();
                return flightIDs; // return the currently booked flightIDs
            }
        }
        public static List<int> GetTakenFlightIDs(int userID)
        {
            // This method goes into the database, specifically the flightsTaken table, 
            // and retrieves all of the flight IDs of the customer's taken flights and returns this list
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select flightsTaken.flightID_fk from flightsTaken where flightsTaken.userID_fk = @userID_fk";
                // use the userID to get the current taken flights
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                List<int> flightIDs = new List<int>();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    flightIDs.Add(rdr.GetInt32(0));
                }
                rdr.Close();
                con.Close();
                return flightIDs; // return the currently booked flightIDs
            }
        }
        public static List<int> GetFlightIDsInRoute(int routeID)
        {
            // This method goes into the database, specifically the route table, 
            // and retrieves all of the master flightIDs in this route
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from route where route.routeID = @routeID";
                // use the routeID to get the FlightIDs
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
                return flightIDs; // return flightIDs in the route
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
                // get the name for the provided airport code
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
                // use the flight ID to get the information about the flight
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
        public static void RemoveFromFlightsBooked(int userID, int flightID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and removes the booked flight for the specific user and flight
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM flightsBooked WHERE userID_fk = @userID_fk AND flightID_fk = @flightID_fk";
                // use the provided information to add to the flightsBooked table
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
                // add the specified flight to the cancelledFlights table
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
                // use the provided information to get the payment method
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
        public static double GetBalance(int userID)
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
                // use the provided id to get the balance
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                double balance = 0; // used to return balance

                while (rdr.Read())
                {
                    balance = rdr.GetDouble(0);
                }
                rdr.Close();
                con.Close();
                return balance; // return the balance
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
                // use the provided id to update the balance
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
                // use the provided id to get the available points
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int pointsAvailable = 0; // used to return points available

                while (rdr.Read())
                {
                    pointsAvailable = rdr.GetInt32(0);
                }
                rdr.Close();
                con.Close();
                return pointsAvailable; // return points available
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
                // use the provided id to update the available points
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
                // use the provided id to get the used points
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int pointsUsed = 0; // used to return the points used

                while (rdr.Read())
                {
                    pointsUsed = rdr.GetInt32(0);
                }
                rdr.Close();
                con.Close();
                return pointsUsed; // return points used
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
                // use the provided id to update the used points
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
                // use the provided id to update the number of vacant seats
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
                // use the provided id to update the flight income
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
                // if the password is not updated but the credit card is then do not change the password but update everything else
                // if the password is updated but the credit card is not then do not change the credit card but update everything else
                // if both are updated, include both in the update
                // otherwise, update everything but the password and credit card
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
        public static List<FlightModel> GetFlights(string origin, string destination, DateTime from, DateTime to)
        {
            // This method goes into the database, specifically the availableFlights table, 
            // and gets all flights that have the specific information
            // All dates are before right now since the flight manifests are lists of everyone on each flight when it takes off.
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination))
                {
                    // if only the dates are provided, then select all flights
                    cmd.CommandText = "select * from availableFlight";
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination))
                {
                    // if the origin is provided, then find all flights with that originCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination))
                {
                    // if the destination is provided, then find all flights with that destinationCpde
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @destinationCode_fk";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                }
                else
                {
                    // if the origin and destination are provided, then find all flights with that originCode and destinationCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                }
                /*
                if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin is the only filter provided, then find all flights with that originCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) <= date(@toDate)";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the destination is the only filter provided, then find all flights with that destinationCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) <= date(@toDate)";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the from date is the only filter provided, then find all flights since that date
                    cmd.CommandText = "select * from availableFlight where date(availableFlight.departureDate) between date(@fromDate) and date(@toDate)";
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the to date is the only filter provided, then find all flights up until that date
                    cmd.CommandText = "select * from availableFlight where date(availableFlight.departureDate) <= date(@toDate)";
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin and destination are the filters provided, then find all flights with that originCode and destinationCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) <= date(@toDate)";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin and from date are the filters provided, then find all flights with that originCode and all flights since that date
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) between date(@fromDate) and date(@toDate)";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin and to date are the filters provided, then find all flights with that originCode and all flights up until that date
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate + availableFlight.departureTime) <= date(@toDate)";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the destination and from date are the filters provided, then find all flights with that destinationCode and all flights since that date
                    cmd.CommandText = "select * from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between date(@fromDate) and date(@toDate)";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the destination and to date are the filters provided, then find all flights with that destinationCode and all flights up until that date
                    cmd.CommandText = "select * from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) <= date(@toDate)";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the from and to dates are the filters provided, then find all flights between those two dates
                    cmd.CommandText = "select * from availableFlight where date(availableFlight.departureDate) between date(@fromDate) and date(@toDate)";
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin, destination, and from date are the filters provided, then find all flights with that originCode and destinationCode and all flights since that date
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk  and datetime(availableFlight.departureDate) between dateTime(@fromDate) and dateTime(@toDate)";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin, destination, and to date are the filters provided, then find all flights with that originCode and destinationCode and all flights up until that date
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk  and date(availableFlight.departureDate) <= date(@toDate)";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin, from, and to date are the filters provided, then find all flights with that originCode and all flights between those two dates
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) between date(@fromDate) and date(@toDate)";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the destination, from, and to date are the filters provided, then find all flights with that destinationCode and all flights between those two dates
                    cmd.CommandText = "select * from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between date(@fromDate) and date(@toDate)";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if everything is provided, then find all flights with that originCode and destinationCode and all flights between those two dates
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between date(@fromDate) and date(@toDate)";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else
                {
                    // if nothing is provide, just find all flights in the availableFlight table before today
                    cmd.CommandText = "select * from availableFlight where date(availableFlight.departureDate) <= date(@toDate)";
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                */
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                List<FlightModel> flights = new List<FlightModel>();

                while (rdr.Read())
                {
                    DateTime dateTime = Convert.ToDateTime(rdr.GetString(4)).Date + Convert.ToDateTime(rdr.GetString(5)).TimeOfDay;
                    if (DateTime.Compare(dateTime, from) >= 0 && DateTime.Compare(dateTime, to) <= 0)
                    {
                        double capacityPercentage = Math.Round((1.0 - (double)(Convert.ToDouble(rdr.GetInt32(10)) / (double)SqliteDataAccess.GetPlaneCapacity(rdr.GetString(8)))) * 100.0, 2);
                        flights.Add(new FlightModel(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(6), dateTime, rdr.GetDouble(7), rdr.GetString(8), rdr.GetDouble(9), rdr.GetInt32(10), rdr.GetDouble(11), capacityPercentage));
                    }
                }
                // DataTable dt = new DataTable();
                // dt.Load(rdr); // fill a datatable with the sql query data
                rdr.Close(); // close the reader
                con.Close(); // close the connection
                return flights; // return the list of flights
            }
        }
        public static List<int> GetFlightPassengers(int flightID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and retrieves all of the userIDs that are connected with the specific flightID aka passengers
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from flightsBooked where flightsBooked.flightID_fk = @flightID_fk";
                // use the userID to get the correct routeIDs
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
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
        public static int GetCompanyFlightCount(string origin, string destination, DateTime from, DateTime to)
        {
            // This method goes into the database, specifically the availableFlights table, 
            // and gets the count of all flights that have the specific information
            // All dates are before right now since the account summaries are lists of everyone on each flight when it takes off.
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination))
                {
                    // if only the dates are provided, then select all flights
                    cmd.CommandText = "select * from availableFlight";
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination))
                {
                    // if the origin is provided, then find all flights with that originCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination))
                {
                    // if the destination is provided, then find all flights with that destinationCpde
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @destinationCode_fk";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                }
                else
                {
                    // if the origin and destination are provided, then find all flights with that originCode and destinationCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                }
                /*
                if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin is the only filter provided, then find  the count of flights with that originCode
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.originCode_fk = @originCode_fk and datetime(availableFlight.departureDate + availableFlight.departureTime) <= @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the destination is the only filter provided, then find  the count of flights with that destinationCode
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and datetime(availableFlight.departureDate + availableFlight.departureTime) <= @toDate";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the from date is the only filter provided, then find  the count of flights since that date
                    cmd.CommandText = "select count(*) from availableFlight where date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the to date is the only filter provided, then find  the count of flights up until that date
                    cmd.CommandText = "select count(*) from availableFlight where date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin and destination are the filters provided, then find  the count of flights with that originCode and destinationCode
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk and datetime(availableFlight.departureDate + availableFlight.departureTime) <= @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin and from date are the filters provided, then find  the count of flights with that originCode and all flights since that date
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin and to date are the filters provided, then find  the count of flights with that originCode and all flights up until that date
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the destination and from date are the filters provided, then find  the count of flights with that destinationCode and all flights since that date
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the destination and to date are the filters provided, then find  the count of flights with that destinationCode and all flights up until that date
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the from and to dates are the filters provided, then find  the count of flights between those two dates
                    cmd.CommandText = "select count(*) from availableFlight where date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin, destination, and from date are the filters provided, then find  the count of flights with that originCode and destinationCode and all flights since that date
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk  and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin, destination, and to date are the filters provided, then find  the count of flights with that originCode and destinationCode and all flights up until that date
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk  and date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin, from, and to date are the filters provided, then find  the count of flights with that originCode and all flights between those two dates
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the destination, from, and to date are the filters provided, then find  the count of flights with that destinationCode and all flights between those two dates
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if everything is provided, then find  the count of flights with that originCode and destinationCode and all flights between those two dates
                    cmd.CommandText = "select count(*) from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else
                {
                    // if nothing is provide, just find the count of flights in the availableFlight table before today
                    cmd.CommandText = "select count(*) from availableFlight where date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }*/
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int flightCount = 0; // used to return the company flight count based on filters

                while (rdr.Read())
                {
                    DateTime dateTime = Convert.ToDateTime(rdr.GetString(4)).Date + Convert.ToDateTime(rdr.GetString(5)).TimeOfDay;
                    if (DateTime.Compare(dateTime, from) >= 0 && DateTime.Compare(dateTime, to) <= 0)
                        flightCount += 1;
                }
                rdr.Close();
                con.Close();
                return flightCount; // return company flight count
            }
        }
        public static double GetCompanyIncome(string origin, string destination, DateTime from, DateTime to)
        {
            // This method goes into the database, specifically the availableFlights table, 
            // and gets the income of all flights that have the specific information
            // All dates are before right now since the account summaries are lists of everyone on each flight when it takes off.
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination))
                {
                    // if only the dates are provided, then select all flights
                    cmd.CommandText = "select * from availableFlight";
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination))
                {
                    // if the origin is provided, then find all flights with that originCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination))
                {
                    // if the destination is provided, then find all flights with that destinationCpde
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @destinationCode_fk";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                }
                else
                {
                    // if the origin and destination are provided, then find all flights with that originCode and destinationCode
                    cmd.CommandText = "select * from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                }
                /*
                if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin is the only filter provided, then find the income with that originCode
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.originCode_fk = @originCode_fk and datetime(availableFlight.departureDate + availableFlight.departureTime) <= @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the destination is the only filter provided, then find the income with that destinationCode
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and datetime(availableFlight.departureDate + availableFlight.departureTime) <= @toDate";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the from date is the only filter provided, then find the income since that date
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the to date is the only filter provided, then find the income up until that date
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin and destination are the filters provided, then find the income with that originCode and destinationCode
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk and datetime(availableFlight.departureDate + availableFlight.departureTime) <= @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin and from date are the filters provided, then find the income with that originCode and all flights since that date
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin and to date are the filters provided, then find the income with that originCode and all flights up until that date
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the destination and from date are the filters provided, then find the income with that destinationCode and all flights since that date
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the destination and to date are the filters provided, then find the income with that destinationCode and all flights up until that date
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", origin);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the from and to dates are the filters provided, then find the income between those two dates
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to == DateTime.MinValue)
                {
                    // if the origin, destination, and from date are the filters provided, then find the income with that originCode and destinationCode and all flights since that date
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk  and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from == DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin, destination, and to date are the filters provided, then find the income with that originCode and destinationCode and all flights up until that date
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk  and date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the origin, from, and to date are the filters provided, then find the income with that originCode and all flights between those two dates
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.originCode_fk = @originCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if the destination, from, and to date are the filters provided, then find the income with that destinationCode and all flights between those two dates
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && from != DateTime.MinValue && to != DateTime.MinValue)
                {
                    // if everything is provided, then find the income with that originCode and destinationCode and all flights between those two dates
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where availableFlight.originCode_fk = @originCode_fk and availableFlight.destinationCode_fk = @destinationCode_fk and date(availableFlight.departureDate) between @fromDate and @toDate";
                    cmd.Parameters.AddWithValue("@originCode_fk", origin);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destination);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);
                }
                else
                {
                    // if nothing is provide, just find the income for all flights before today
                    cmd.CommandText = "select availableFlight.flightIncome from availableFlight where date(availableFlight.departureDate) <= @toDate";
                    cmd.Parameters.AddWithValue("@toDate", DateTime.Now);
                }
                */
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                double income = 0; // used to return the company income count based on filters

                while (rdr.Read())
                {
                    DateTime dateTime = Convert.ToDateTime(rdr.GetString(4)).Date + Convert.ToDateTime(rdr.GetString(5)).TimeOfDay;
                    if (DateTime.Compare(dateTime, from) >= 0 && DateTime.Compare(dateTime, to) <= 0)
                        income += rdr.GetDouble(11);
                }
                rdr.Close();
                con.Close();
                return income; // return company income
            }
        }
        public static List<(int, DateTime)> GetFlightIDs_MasterID(int masterID, List<(int, DateTime)> flights_MasterID, DateTime departDate, DateTime compareDateTime)
        {
            // This method goes into the database, specifically the availableFlight table, 
            // and retrieves all of the flight ids according to the customer's inputs
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select availableFlight.flightID, availableFlight.departureDate, availableFlight.departureTime, availableFlight.duration from availableFlight where availableFlight.masterFlightID_fk = @masterFlightID_fk and availableFlight.numOfVacantSeats != 0";
                // use the flight ID to get the information about the flight
                cmd.Parameters.AddWithValue("@masterFlightID_fk", masterID);
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                // execute the command with the reader, which only reads the database rather than updating it in anyway
                while (rdr.Read())
                {
                    DateTime departureDateTime = Convert.ToDateTime(rdr.GetString(1)).Date + Convert.ToDateTime(rdr.GetString(2)).TimeOfDay;
                    DateTime arriveDateTime = departureDateTime.AddHours(rdr.GetDouble(3));
                    if (DateTime.Compare(departureDateTime.Date, departDate.Date) == 0 && DateTime.Compare(departureDateTime, compareDateTime) > 0)
                        flights_MasterID.Add((rdr.GetInt32(0), arriveDateTime));
                }
                rdr.Close();
                con.Close();
                return flights_MasterID; // return flight data
            }
        }
        /* Gets all of the airports in the airports table */
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

                // Read in all airports in the airports table and make a new airport object to
                // add to the airports list
                while (rdr.Read())
                {
                    airports.Add(new Airport(rdr.GetString(0), rdr.GetString(1)));
                }
                rdr.Close();
                con.Close();
                return airports;
            }
        }
        /* Gets all of the flights in the direct flights table */
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


                // Read in all direct flights in the directFlight table and make a new FlightModel object to
                // add to the direct flights list
                while (rdr.Read())
                {
                    directFlights.Add(new FlightModel(rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2)));
                }
                rdr.Close();
                con.Close();
                return directFlights;
            }
        }
        /* Get all of the flights in masterFlight table and loads them into a data table to be used
         * by a data grid view object in form */
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
        /* Get all of the current airport codes from the airport table */
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

                // read in all airport codes and add them to the list of airport codes to be returned
                while (rdr.Read())
                {
                    airportCodes.Add(rdr.GetString(0));
                }
                rdr.Close();
                con.Close();
                return airportCodes;
            }
        }
        /* Add all flights in the flightModels list to the masterFlight table */
        public static void AddFlightToMaster(List<FlightModel> flightModels)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                // There is only 1 flight in the flight model list use this code
                if (flightModels.Count == 1)
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
                // There are 2 flights in the flight model list use this code
                else if (flightModels.Count == 2)
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
                // There are 3 flights in the flight model list use this code
                else if (flightModels.Count == 3)
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
        /* Gets the masterFlightID from tracker table */
        public static int GetLastMasterFlightID()
        {
            int newID = 0;
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT lastMasterID FROM tracker";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) newID = rdr.GetInt32(0);
                newID++;
                rdr.Close();
                con.Close();
            }
            return newID;
        }
        /* Update the last master flight ID value in tracker table */
        public static void UpdateLastMasterID(int lastID)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE tracker SET lastMasterID = @lastID";
                cmd.Parameters.AddWithValue("@lastID", lastID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Gets the distance between two different airports by looking the distance up in the directFlight table */
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
        /* Remove a flight from the masterFlight table based on the passed in flightID */
        public static void RemoveMasterFlight(int flightID)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM masterFlight WHERE masterFlight.masterFlightID = @flightID";
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Checks if the masterFlight table is empty by returning the number of rows found */
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
        /* Changes the time of a flight in master based on the passed in parameters of the old flight's flightID, the new time, and
         * the flightID that is going to be used */
        public static void ChangeTimeMaster(int flightID, DateTime departureTime, int newFlightID)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE masterFlight SET departureTime = @departureTime, masterFlightID = @newFlightID WHERE masterFlightID = @flightID";
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Parameters.AddWithValue("@departureTime", departureTime.ToShortTimeString());
                cmd.Parameters.AddWithValue("@newFlightID", newFlightID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Gets all of the flights in the masterFlight table and adds them to a list
         * then returns that list */
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
        /* Checks to see if the flight already exists in master based on the origin code, destination code, and departure time 
         * if it does exist it returns true if not then false */
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
        /* Gets the capacity of the passed in planeType and returns it */
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
        /* Gets the last routeID from the tracker table */
        public static int GetLastRouteID()
        {
            int newID = 0;
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT lastRouteID FROM tracker";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) newID = rdr.GetInt32(0);
                newID++;
                rdr.Close();
                con.Close();
            }
            return newID;
        }
        /* Updates the value of the last route id in the tracker table */
        public static void UpdateLastRouteID(int lastID)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE tracker SET lastRouteID = @lastID";
                cmd.Parameters.AddWithValue("@lastID", lastID);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Adds a brand new route to the route table based on all of the parameters passed into the method */
        public static void AddToRoute(int routeID, string originCode, string destinationCode, int numOfLayovers, string flightID1, string flightID2 = null, string flightID3 = null)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                /* If there is no flight two use this SQL code */
                if (flightID2 == null)
                {
                    cmd.CommandText = "INSERT INTO route VALUES (@routeID, @originCode_fk, @destinationCode_fk, @numOfLayovers, @masterFlightID1_fk, null, null, null)";
                    cmd.Parameters.AddWithValue("@routeID", routeID);
                    cmd.Parameters.AddWithValue("@originCode_fk", originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destinationCode);
                    cmd.Parameters.AddWithValue("@numOfLayovers", numOfLayovers);
                    cmd.Parameters.AddWithValue("@masterFlightID1_fk", Convert.ToInt32(flightID1));
                }
                /* If there is no flight three use this SQL code */
                else if (flightID3 == null)
                {
                    cmd.CommandText = "INSERT INTO route VALUES (@routeID, @originCode_fk, @destinationCode_fk, @numOfLayovers, @masterFlightID1_fk, @masterFlightID2_fk, null, null)";
                    cmd.Parameters.AddWithValue("@routeID", routeID);
                    cmd.Parameters.AddWithValue("@originCode_fk", originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destinationCode);
                    cmd.Parameters.AddWithValue("@numOfLayovers", numOfLayovers);
                    cmd.Parameters.AddWithValue("@masterFlightID1_fk", Convert.ToInt32(flightID1));
                    cmd.Parameters.AddWithValue("@masterFlightID2_fk", Convert.ToInt32(flightID2));
                }
                /* If there are 3 flights then use this SQL code */
                else
                {
                    cmd.CommandText = "INSERT INTO route VALUES (@routeID, @originCode_fk, @destinationCode_fk, @numOfLayovers, @masterFlightID1_fk, @masterFlightID2_fk, @masterFlightID3_fk, null)";
                    cmd.Parameters.AddWithValue("@routeID", routeID);
                    cmd.Parameters.AddWithValue("@originCode_fk", originCode);
                    cmd.Parameters.AddWithValue("@destinationCode_fk", destinationCode);
                    cmd.Parameters.AddWithValue("@numOfLayovers", numOfLayovers);
                    cmd.Parameters.AddWithValue("@masterFlightID1_fk", Convert.ToInt32(flightID1));
                    cmd.Parameters.AddWithValue("@masterFlightID2_fk", Convert.ToInt32(flightID2));
                    cmd.Parameters.AddWithValue("@masterFlightID3_fk", Convert.ToInt32(flightID3));
                }
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Gets the flight id from the master table based on the passed in origin code, destination code, and departure time */
        public static int GetFlightIDFromMaster(string originCode, string destinationCode, string departureTime)
        {
            int flightID = 0;
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT masterFlightID FROM masterFlight " +
                                  "WHERE masterFlight.originCode_fk = @originCode_fk " +
                                  "AND masterFlight.destinationCode_fk = @destinationCode_fk " +
                                  "AND masterFlight.departureTime = @departureTime";
                cmd.Parameters.AddWithValue("@originCode_fk", originCode);
                cmd.Parameters.AddWithValue("@destinationCode_fk", destinationCode);
                cmd.Parameters.AddWithValue("@departureTime", departureTime);
                cmd.Connection = con;

                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) flightID = rdr.GetInt32(0);

                rdr.Close();
                con.Close();
            }
            return flightID;
        }
        /* Sets the last date that the route is going to be used by the system */
        public static void SetRemovalDateRoutes(int flightID)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE route SET lastFlightDate = @currentDate WHERE masterFlightID1_fk = @flightID OR masterFlightID2_fk = @flightID OR masterFlightID3_fk = @flightID";
                cmd.Parameters.AddWithValue("@flightID", flightID);

                DateTime currentDate = DateTime.Now.AddMonths(6).AddDays(1);
                cmd.Parameters.AddWithValue("@currentDate", currentDate.ToString("yyyy-MM-dd"));
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Checks to see if a route with the same flightID1, flightID2, and flightID3 already exists if it does return true
         * if not then returns false */
        public static Boolean RouteExists(string flightID1, string flightID2 = null, string flightID3 = null)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT 1 FROM route " +
                                  "WHERE masterFlightID1_fk = @flightID1 " +
                                  "AND masterFlightID2_fk = @flightID2 " +
                                  "AND masterFlightID3_fk = @flightID3";

                cmd.Parameters.AddWithValue("@flightID1", Convert.ToInt32(flightID1));
                // if flightID2 is not null then put the value of the flight id into the paramater @flightID2
                _ = (flightID2 != null) ? cmd.Parameters.AddWithValue("@flightID2", Convert.ToInt32(flightID2)) : cmd.Parameters.AddWithValue("@flightID2", null);

                // if flightID3 is not null then put the value of the flight id into the paramater @flightID3
                _ = (flightID3 != null) ? cmd.Parameters.AddWithValue("@flightID3", Convert.ToInt32(flightID3)) : cmd.Parameters.AddWithValue("@flightID3", null);
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
        /* Checks if the available flight table is completely empty if it is returns true
         * if not then it returns false */
        public static Boolean CheckAvailableFlightEmpty()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) AS RowCnt FROM availableFlight";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr.GetInt32(0) == 0)
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
                rdr.Close();
                con.Close();
                return true; // should never reach here
            }
        }
        /* Gets the last date recorded in the availableFlight table and returns it */
        public static string GetLatestAvailableFlight()
        {
            string lastDate = "";
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT departureDate FROM availableFlight WHERE flightID=(SELECT max(flightID) FROM availableFlight)";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) lastDate = rdr.GetString(0);
                rdr.Close();
                con.Close();
            }
            return lastDate;
        }
        /* Gets the flightID held by the last entry in the availableFlight table */
        public static int GetLastAvailableFlightID()
        {
            int newID = 0;
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT flightID FROM availableFlight WHERE flightID=(SELECT max(flightID) FROM availableFlight)";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) newID = rdr.GetInt32(0);
                newID++;
                rdr.Close();
                con.Close();
            }
            return newID;
        }
        /* Adds a flight to the availableFlight table based on the flightModel passed into the method */
        public static void AddFlightToAvailable(FlightModel newFlight)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO availableFlight VALUES (@flightID, @masterFlightID_fk, @originCode_fk, @destinationCode_fk, " +
                                  "@departureDate, @departureTime, @distance, @duration, @planeType_fk, @cost, @numOfVacantSeats, @flightIncome)";
                cmd.Parameters.AddWithValue("@flightID", newFlight.flightID);
                cmd.Parameters.AddWithValue("@masterFlightID_fk", newFlight.masterFlightID);
                cmd.Parameters.AddWithValue("@originCode_fk", newFlight.originCode);
                cmd.Parameters.AddWithValue("@destinationCode_fk", newFlight.destinationCode);
                cmd.Parameters.AddWithValue("@departureDate", newFlight.departureDateTime.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@departureTime", newFlight.departureDateTime.ToShortTimeString());
                cmd.Parameters.AddWithValue("@distance", newFlight.distance);
                cmd.Parameters.AddWithValue("@duration", newFlight.durDouble);
                cmd.Parameters.AddWithValue("@planeType_fk", newFlight.planeType);
                cmd.Parameters.AddWithValue("@cost", newFlight.cost);
                cmd.Parameters.AddWithValue("@numOfVacantSeats", newFlight.numberOfVacantSeats);
                cmd.Parameters.AddWithValue("@flightIncome", newFlight.flightIncome);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Gets the oldest available flight from the available flight table */
        public static string GetOldestAvailable()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                string oldestDate = "";
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM availableFlight LIMIT 1";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) oldestDate = rdr.GetString(4);
                rdr.Close();
                con.Close();
                return oldestDate;
            }
        }

        /* Removes any flight in the availableFlight table that matches the string passed in */
        public static void RemoveOldAvailable(string oldestDate)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM availableFlight WHERE departureDate = @departureDate";
                cmd.Parameters.AddWithValue("@departureDate", oldestDate);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Cleans any routes from the route table whose removal date matches the current date */
        public static void CleanRoutes()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM route WHERE lastFlightDate = @lastFlightDate";
                cmd.Parameters.AddWithValue("@lastFlightDate", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Gets all routes ids from routes that contain the flight ID passed in */
        public static List<int> GetRoutesWithFlightID(int flightID)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                List<int> routeIDs = new List<int>();
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT routeID FROM route WHERE masterFlightID1_fk = @flightID OR masterFlightID2_fk = @flightID OR masterFlightID3_fk = @flightID";
                cmd.Parameters.AddWithValue("@masterFlightID", flightID);

                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) routeIDs.Add(rdr.GetInt32(0));
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                rdr.Close();
                con.Close();
                return routeIDs;
            }
        }
        /* Gets all plane types from the plane table and returns them as a list of strings */
        public static List<String> GetPlaneTypes()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                List<string> planeTypes = new List<string>();
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT planeType FROM plane";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    planeTypes.Add(rdr.GetString(0));
                }
                rdr.Close();
                con.Close();
                return planeTypes;
            }
        }
        /* Updates the master flight with the passed in flight id to have a new planeType based on the
         * passed in string value for planeType */
        public static void UpdateMasterNewPlane(int flightID, string planeType)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE masterFlight SET planeType = @planeType, capacity = @capacity WHERE masterFlightID = @flightID";
                cmd.Parameters.AddWithValue("@flightID", flightID);
                cmd.Parameters.AddWithValue("@planeType", planeType);
                cmd.Parameters.AddWithValue("@capacity", GetPlaneCapacity(planeType));
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /* Get all of the routes in route table and loads them into a data table to be used
         * by a data grid view object in form */
        public static DataTable GetRouteDT()
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM route";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(rdr);
                rdr.Close();
                con.Close();
                return dt;
            }
        }
         /* This method will get all customer ids in the database and return them as a list */
        public static List<int> GetAllCustomerIDs()
        {
            List<int> custIDs = new List<int>();

            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM customer";
                cmd.Connection = con;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    custIDs.Add(rdr.GetInt32(0));
                }
                rdr.Close();
                con.Close();
            }
            return custIDs;
        }
        /* Check and see if the flight for the flight ID passed in is older than the current date and time */
        public static Boolean CheckIfBookedOld(int flightID)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT departureDate, departureTime FROM availableFlight WHERE flightID = @flightID";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@flightID", flightID);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // If flight is older than current date and time return true
                    DateTime departureDate = Convert.ToDateTime(rdr.GetString(0)).Date + Convert.ToDateTime(rdr.GetString(1)).TimeOfDay;
                    if (DateTime.Compare(departureDate, DateTime.Now) < 0)
                    {
                        rdr.Close();
                        con.Close();
                        return true;
                    }
                }
                rdr.Close();
                con.Close();
                return false;
            }
        }
        /* This method adds a flight to the flight taken table in the database based on the passed in
         * customer id and flight id
         */
        public static void AddToFlightsTaken(int userID, int flightID)
        {
            // This method goes into the database, specifically the flightsBooked table, 
            // and adds the booked flight
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            // closes the connection when there is an error or it is done executing
            {
                con.Open(); // open the connection
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO flightsTaken values (@userID_fk, @flightID_fk)";
                // use the provided information to add to the flightsBooked table
                cmd.Parameters.AddWithValue("@userID_fk", userID);
                cmd.Parameters.AddWithValue("@flightID_fk", flightID);
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

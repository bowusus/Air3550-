﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SystemAction 
    {
        // This class file will include any methods that the system does, 
        // so there is no connection to the database and no specific class 
        // or user does the action. For example, the method to encrypt
        // the password is in this file.
        public static string EncryptPassword(string pass)
        {
            // This method encrypts the provided password to either verify 
            // the inputted password and therefore the user can log in
            // or to simply store the password for a specific user in the database
            byte[] bytes = Encoding.UTF8.GetBytes(pass); // turn the provided string into a byte array
            byte[] hash; // use a byte array for the hash
            SHA512 sHA512 = new SHA512Managed(); // create a sha-512 instance
            StringBuilder result = new StringBuilder(); // create a string builder instance to create the hash as a string
            hash = sHA512.ComputeHash(bytes); // generate the sha-512 hash
            for (int i = 0; i < hash.Length; i++)
                result.Append(hash[i].ToString("x2")); // turn the hash into a string
            return result.ToString(); // return the string and exit
        }
        public static int[] ValidateAccountFormat(string password, string firstName, string lastName, string street, string city, string zip, string phone, string email)
        {
            // This method checks the format of the account information
            // If any of the formats are invalid or the information is blank (besides the password), it is added to an errorMessage string that is returned
            // set the formats for the city, zip code, phone number, credit card number, and email
            Regex cityReg = new Regex(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$");
            Regex zipReg = new Regex(@"^\d{5}(?:[-]\d{4})?$");
            Regex phoneReg = new Regex(@"^\(?([0-9]{3})\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$");
            Regex emailReg = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            // match the provided string with the format
            Match cityMatch = cityReg.Match(city);
            Match zipMatch = zipReg.Match(zip);
            Match phoneMatch = phoneReg.Match(phone);
            Match emailMatch = emailReg.Match(email);

            int[] errorMessage = new int[12];

            // check if any of the text boxes are empty 
            // add any of the invalid information errors to the errorMessage[]
            if (String.IsNullOrEmpty(firstName))
                errorMessage[0] = 1;
            if (String.IsNullOrEmpty(lastName))
                errorMessage[1] = 1;
            if (String.IsNullOrEmpty(street))
                errorMessage[2] = 1;
            if (String.IsNullOrEmpty(city) || !cityMatch.Success)
                errorMessage[3] = 1;
            if (String.IsNullOrEmpty(zip) || !zipMatch.Success)
                errorMessage[4] = 1;
            if (String.IsNullOrEmpty(phone) || !phoneMatch.Success)
                errorMessage[5] = 1;
            if (String.IsNullOrEmpty(email) || !emailMatch.Success)
                errorMessage[7] = 1;

            return errorMessage;
        }
        public static int CalculateCost(int depart, int arrive, double cost)
        {
            // This method determines if the flight is departing or arriving during a time that would warrant a discount
            // Depart between 5 and 8 or Arriving between 7 and midnight --> 10 % discount
            // Depart or arrive between midnight and 5 --> 20 % discount
            // return the new calculated cost
            if ((depart >= 5 && depart <= 8) || (arrive >= 19 && arrive <= 23))
                cost *= 0.90;
            else if (depart < 5 || arrive < 5)
                cost *= 0.80;
            return Convert.ToInt32(cost);
        }
        public static List<FlightModel> GetCurrentFlights(int routeID)
        {
            // This method creates a list of Flights that allows this page to access that flights details without going back to the database
            // After every cancellation, the current flights are repopulated and updates the datagridview with the most current information
            // A list of the current flights are returned
            List<int> flightIDs;
            List<FlightModel> flights = new List<FlightModel>();
            flightIDs = SqliteDataAccess.GetFlightIDsInRoute(routeID);
            //flightIDs = SqliteDataAccess.GetCurrentFlightIDs(currCustomer.userID); // get the flight ids of the customer's current flights 
            // for each of these ids, get the flight information (origin, destination, etc.)
            // Then get the name of the airports, depart times, arrival times, any discounts to the base cost, and calculate the points
            // Finally create a FlightModel object with that information and add it to a list of booked flights to be displayed to the customer
            foreach (int id in flightIDs)
            {
                List<string> flightsBookedData = SqliteDataAccess.GetFlightData(id);
                string originName = SqliteDataAccess.GetFlightNames(flightsBookedData[2]);
                string destinationName = SqliteDataAccess.GetFlightNames(flightsBookedData[3]);

                DateTime departureDateTime = DateTime.Parse(flightsBookedData[4] + " " + flightsBookedData[5]);
                DateTime arriveDateTime = departureDateTime.AddHours(Convert.ToDouble(flightsBookedData[7]));
                int depHour = departureDateTime.Hour;
                int arrHour = arriveDateTime.Hour;

                int currCost = SystemAction.CalculateCost(depHour, arrHour, int.Parse(flightsBookedData[9]));
                int currPoints = currCost * 100;

                var duration = arriveDateTime.Subtract(departureDateTime);
                //double dur = duration.TotalHours;

                FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), int.Parse(flightsBookedData[1]), flightsBookedData[2], originName, flightsBookedData[3], destinationName, int.Parse(flightsBookedData[6]), DateTime.Parse(flightsBookedData[4] + " " + flightsBookedData[5]), duration, flightsBookedData[8], currCost, currPoints, int.Parse(flightsBookedData[10]), Convert.ToDouble(flightsBookedData[11]));

                flights.Add(flight);
            }
            return flights;
        }
        public static List<Route> GetAvailableFlights(string origin, string destination)
        {
            // This method finds all available routes for the given origin and destinationqa    
            List<Route> routes = new List<Route>();
            List<(int, int)> routeInfo = SqliteDataAccess.GetRouteInfo(origin, destination);
            // go through the route IDs that were found for the specified origin and destination
            // and get the flightIDs in that route, then get information to display to the customer
            foreach ((int, int) id in routeInfo)
            {
                List<int> flightIDs = SqliteDataAccess.GetFlightIDsInRoute(id.Item1);
                List<FlightModel> flights = new List<FlightModel>();
                // initialization/declaration of values to be returned in data grid view
                string routeList = null;
                DateTime depart;
                string departString;
                DateTime arrive;
                string arriveString;
                string planeChange = null;
                string seatsAvailable = null;
                int cost = 0;
                int points = 0;
                int i = 0; // used for grabbing information from the availableRoutes list
                           // go through each of these flight IDs and check if the depart date is the same as the 
                           // depart date in the departDatePicker. If it is, get the specific information to be displayed
                           // and add that flight to the list of available flights.
                           // otherwise, do not add it
                foreach (int fID in flightIDs)
                {
                    List<string> flightsBookedData = SqliteDataAccess.GetFlightData(fID);

                    string originName = SqliteDataAccess.GetFlightNames(flightsBookedData[2]);
                    string destinationName = SqliteDataAccess.GetFlightNames(flightsBookedData[3]);

                    DateTime departureDateTime = DateTime.Parse(flightsBookedData[4] + " " + flightsBookedData[5]);
                    DateTime arriveDateTime = departureDateTime.AddHours(Convert.ToDouble(flightsBookedData[7]));
                    int depHour = departureDateTime.Hour;
                    int arrHour = arriveDateTime.Hour;

                    int currCost = SystemAction.CalculateCost(depHour, arrHour, int.Parse(flightsBookedData[9]));
                    cost += currCost;
                    int currPoints = currCost * 100;
                    points += currPoints;

                    var duration = arriveDateTime.Subtract(departureDateTime);
                    double dur = duration.TotalHours;

                    FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), int.Parse(flightsBookedData[1]), flightsBookedData[2], originName, flightsBookedData[3], destinationName, int.Parse(flightsBookedData[6]), DateTime.Parse(flightsBookedData[4] + " " + flightsBookedData[5]), duration, flightsBookedData[8], currCost, currPoints, int.Parse(flightsBookedData[10]), Convert.ToDouble(flightsBookedData[11]));
                    flights.Add(flight);
                    // mainly for formating purposes, check if the current Flight ID is the last in the list
                    // if it is, then do not add extra lines
                    if (fID == flightIDs[flightIDs.Count - 1])
                    {
                        routeList += fID;
                        seatsAvailable += flights[i].numberOfVacantSeats;
                    }
                    else
                    {
                        routeList += fID + Environment.NewLine;
                        planeChange += flights[i].destinationCode + "/" + flights[i].destinationName + Environment.NewLine;
                        seatsAvailable += flights[i].numberOfVacantSeats + Environment.NewLine;
                    }
                    i += 1;
                }
                // as long as the flight count is not 0, get the depart time, arrive time, duration, and total credits, 
                // add that all to a route object, and add that route object to the available routes list
                if (flights.Count != 0)
                {
                    depart = flights[0].departureDateTime;
                    departString = flights[0].departureDateTime.ToShortTimeString();
                    arrive = flights[flightIDs.Count - 1].departureDateTime.AddHours(flights[flightIDs.Count - 1].duration.TotalHours);
                    arriveString = flights[flightIDs.Count - 1].departureDateTime.AddHours(flights[flightIDs.Count - 1].duration.TotalHours).ToShortTimeString();
                    var duration = arrive.Subtract(depart);
                    string credits = "$" + cost + " (" + points + " points)";
                    Route route = new Route(id.Item1, departString, arriveString, duration, id.Item2, routeList, planeChange, seatsAvailable, credits);
                    routes.Add(route);
                }
            }
            return routes;
        }
        public static double CancelFlight(int uID, FlightModel flight, string paymentMethod, double totalCredit, int totalPoints)
        {
            // move this flight from booked to cancelled and increase the number of vacant seats on the plain
            SqliteDataAccess.CancelBookedFlight(uID, flight.flightID);
            SqliteDataAccess.AddToCancelledFlights(uID, flight.flightID);
            SqliteDataAccess.UpdateNumOfVacantSeats(flight.flightID, flight.numberOfVacantSeats + 1);
            // depending on the payment method, the customer will either get cash back from the airline
            // which will also decrease their total flight income
            // or they will receive points back, increasing available points and decreasing used points
            if (paymentMethod == "Dollars" || paymentMethod == "AirlineCredit")
            {
                totalCredit += flight.cost;
                int bal = SqliteDataAccess.GetBalance(uID);
                SqliteDataAccess.UpdateBalance(uID, bal + flight.cost);
                SqliteDataAccess.UpdateFlightIncome(flight.flightID, flight.flightIncome - flight.cost);
                return totalCredit;
            }
            else
            {
                totalPoints += flight.numOfPoints;
                int available = SqliteDataAccess.GetAvailablePoints(uID);
                int used = SqliteDataAccess.GetUsedPoints(uID);
                SqliteDataAccess.UpdateAvailablePoints(uID, available + flight.numOfPoints);
                SqliteDataAccess.UpdateUsedPoints(uID, used - flight.numOfPoints);
                return totalPoints;
            }
        }
        public static void GenerateFlights()
        {

        }
    }
}

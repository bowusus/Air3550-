using System;
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
        // or user that does the action. For example, the method to encrypt
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
        public static int[] ValidateAccountFormat(string firstName, string lastName, string street, string city, string zip, string phone, string email)
        {
            // This method checks the format of the account information
            // If any of the formats are invalid or the information is blank, it is added to an errorMessage string that is returned
            // set the formats for the city, zip code, phone number, and email
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
        public static double CalculateCost(int depart, int arrive, double cost)
        {
            // This method determines if the flight is departing or arriving during a time that would warrant a discount
            // Depart between 5 and 8 or Arriving between 7 and midnight --> 10 % discount
            // Depart or arrive between midnight and 5 --> 20 % discount
            // return the new calculated cost
            if ((depart >= 5 && depart <= 8) || (arrive >= 19 && arrive <= 23))
                cost *= 0.90;
            else if (depart < 5 || arrive < 5)
                cost *= 0.80;
            return cost;
        }
        public static List<FlightModel> GetCurrentFlights(int routeID)
        {
            // This method creates a list of Flights that allows this page to access that flights details without going back to the database
            // It gets all of the currently booked flights and their details then returns a list of these flight objects
            List<int> flightIDs;
            List<FlightModel> flights = new List<FlightModel>();
            flightIDs = SqliteDataAccess.GetFlightIDsInRoute(routeID);
            int i = 0;
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

                double currCost = SystemAction.CalculateCost(depHour, arrHour, Convert.ToDouble(flightsBookedData[9]));
                if (i == 0)
                    currCost += 50;
                else
                    currCost += 8;
                int currPoints = Convert.ToInt32(currCost * 100);

                var duration = arriveDateTime.Subtract(departureDateTime);

                FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), int.Parse(flightsBookedData[1]), flightsBookedData[2], originName, flightsBookedData[3], destinationName, int.Parse(flightsBookedData[6]), DateTime.Parse(flightsBookedData[4] + " " + flightsBookedData[5]), duration, flightsBookedData[8], currCost, currPoints, int.Parse(flightsBookedData[10]), Convert.ToDouble(flightsBookedData[11]));

                flights.Add(flight);
                i += 1;
            }
            return flights;
        }
        public static List<Route> GetAvailableRoutes(string origin, string destination)
        {
            // This method finds all available routes for the given origin and destination
            // A list of the available routes are returned
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
                DateTime arrive;
                string planeChange = null;
                string seatsAvailable = null;
                double cost = 0;
                int points = 0;
                int i = 0; // used for grabbing information from the availableRoutes list
                // go through each of these flight IDs, make a flight object, add it to the list to be returned
                // add some formatting since this method is used to populate the datagridview tables in the bookFlight form
                foreach (int fID in flightIDs)
                {
                    List<string> flightsBookedData = SqliteDataAccess.GetFlightData(fID);

                    string originName = SqliteDataAccess.GetFlightNames(flightsBookedData[2]);
                    string destinationName = SqliteDataAccess.GetFlightNames(flightsBookedData[3]);

                    DateTime departureDateTime = DateTime.Parse(flightsBookedData[4] + " " + flightsBookedData[5]);
                    DateTime arriveDateTime = departureDateTime.AddHours(Convert.ToDouble(flightsBookedData[7]));
                    int depHour = departureDateTime.Hour;
                    int arrHour = arriveDateTime.Hour;

                    double currCost = SystemAction.CalculateCost(depHour, arrHour, double.Parse(flightsBookedData[9]));
                    cost += currCost;
                    if (i == 0)
                    {
                        currCost += 50;
                        cost += 50;
                    }
                    else
                    {
                        currCost += 8;
                        cost += 8;
                    }
                    int currPoints = Convert.ToInt32(currCost * 100);
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
                    arrive = flights[flightIDs.Count - 1].departureDateTime.AddHours(flights[flightIDs.Count - 1].duration.TotalHours);
                    var duration = arrive.Subtract(depart);
                    string credits = "$" + cost + " (" + points + " points)";
                    Route route = new Route(id.Item1, depart, arrive, duration, id.Item2, routeList, planeChange, seatsAvailable, credits);
                    routes.Add(route);
                }
            }
            return routes;
        }
        public static List<Route> FilterRoutes(List<Route> routes, DateTime departDateTime, DateTime compareDateTime)
        {
            // This method is used to check the routes that will display to the customer
            // For example, the routes should have a departure date and return date that match the input
            // Also, if any of the routes do not have available seats, they should not be displayed
            List<Route> filteredRoutes = new List<Route>();
            // go through the provided routes, if they are valid routes, then add them to a list that will be returned
            foreach (Route route in routes)
            {
                var delta = route.departTime.Subtract(compareDateTime); // get the difference between this route's depart time and the compareDateTime (which could be now or the departure route's depart dateTime)
                int index1 = route.availableSeats.IndexOf("\r\n"); // get the first index of the first space to find the available seats of the first flight in the route 
                int index2 = route.availableSeats.LastIndexOf("\r\n"); // get the last index of the space to find the available seats of the second and third flight in the route 
                int seats1; // used for available seats on the first flight
                int seats2; // used for available seats on the second flight
                int seats3; // used for available seats on the third flight
                if (index1 == -1) // if there is no "\r\n" then, there is only one flight
                {
                    seats1 = int.Parse(route.availableSeats);
                    // check if the number of available seats is not zero, if the route's depart date is the same as the provided depart date,
                    // and if the difference between the route's depart date time and the compareDateTime
                    // If these are all valid, then all the route to the filtered routes list
                    if (seats1 != 0 && route.departTime.Date == departDateTime.Date && delta.TotalMinutes > 0)
                        filteredRoutes.Add(route);
                }
                else if (index1 == index2) // if the index of the first and last "\r\n" are the same, then there are two flights
                {
                    seats1 = int.Parse(route.availableSeats.Substring(0, index1));
                    seats2 = int.Parse(route.availableSeats.Substring(index1 + 1, route.availableSeats.Length - index1 - 1));
                    // check if the number of available seats for both flights is not zero, if the route's depart date is the same as the provided depart date,
                    // and if the difference between the route's depart date time and the compareDateTime
                    // If these are all valid, then all the route to the filtered routes list
                    if (seats1 != 0 && seats2 != 0 && route.departTime.Date == departDateTime.Date && delta.TotalMinutes > 0)
                        filteredRoutes.Add(route);
                }
                else // if the index of the first and last "\r\n" are different, then there are three flights
                {
                    // check if the number of available seats for all three flights is not zero, if the route's depart date is the same as the provided depart date,
                    // and if the difference between the route's depart date time and the compareDateTime
                    // If these are all valid, then all the route to the filtered routes list
                    seats1 = int.Parse(route.availableSeats.Substring(0, index1));
                    seats2 = int.Parse(route.availableSeats.Substring(index1 + 1, index2 - index1));
                    seats3 = int.Parse(route.availableSeats.Substring(index2 + 1, route.availableSeats.Length - index2 - 1));
                    if (seats1 != 0 && seats2 != 0 && seats3 != 0 && route.departTime.Date == departDateTime.Date && delta.TotalMinutes > 0)
                        filteredRoutes.Add(route);
                }
            }
            return filteredRoutes;
        }
        public static double CancelFlight(int uID, FlightModel flight, string paymentMethod, double totalCredit, int totalPoints)
        {
            // This method is used to cancel the specified flight and update the total credits or points
            // Depending on whether the payment method was dollars, airline credit, or points, whichever value is returned

            // Move the specified flight from booked to cancelled and increase the number of vacant seats in the plane
            SqliteDataAccess.CancelBookedFlight(uID, flight.flightID);
            SqliteDataAccess.AddToCancelledFlights(uID, flight.flightID);
            SqliteDataAccess.UpdateNumOfVacantSeats(flight.flightID, flight.numberOfVacantSeats + 1);
            // Depending on the payment method, the customer will either get cash back from the airline
            // Which will also decrease the total flight income
            // Or they will receive points back, increasing available points and decreasing used points
            if (paymentMethod == "Dollars" || paymentMethod == "AirlineCredit")
            {
                totalCredit += flight.cost;
                double bal = SqliteDataAccess.GetBalance(uID);
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
                return Convert.ToDouble(totalPoints);
            }
        }
        public static void GenerateFlights()
        {
            // Get all of the flgihts on the master flights that we are going to use as a template to create available flights
            List<FlightModel> masterFlights = new List<FlightModel>();
            masterFlights = SqliteDataAccess.GetAllMasterFlights();

            // Check if database is empty if it is start making flights based on the current date otherwise generate based on the date last date a flight was made
            DateTime startDate = (SqliteDataAccess.CheckAvailableFlightEmpty()) ? DateTime.Now : Convert.ToDateTime(SqliteDataAccess.GetLatestAvailableFlight()).AddDays(1);
            // Flights should only exist if they are within 6 months of the current date
            DateTime endDate = DateTime.Now.AddMonths(6).AddDays(1);
            int currentFlightID = SqliteDataAccess.GetLastAvailableFlightID();

            //continue making flights until we reach the date that is 6 months + 1 day current date
            while (DateTime.Compare(startDate, endDate) < 0)
            {
                foreach (FlightModel masterFlight in masterFlights)
                {
                    DateTime newDepartureDateTime = startDate.Date + masterFlight.departureDateTime.TimeOfDay;
                    //create the new available flight based on the master flight templeate and add it to the available flights table
                    decimal duration = (decimal)(masterFlight.distance / 500.0) + .5M + (40 / 60.0M);
                    decimal cost = (decimal)(masterFlight.distance * .12);
                    FlightModel newAvaFlight = new FlightModel(currentFlightID, masterFlight.flightID, masterFlight.originCode,
                                                                masterFlight.destinationCode, (int)masterFlight.distance, 
                                                                newDepartureDateTime, (double)duration, masterFlight.planeType, 
                                                                (double)cost, SqliteDataAccess.GetPlaneCapacity(masterFlight.planeType), 0);
                    SqliteDataAccess.AddFlightToAvailable(newAvaFlight);
                    currentFlightID++;
                }
                // increment the date
                DateTime newStartDate = startDate.AddDays(1);
                startDate = newStartDate;
            }
        }

        public static void GenerateFlight(FlightModel masterFlight)
        {
            // New flight has been made in master so creating all available flights from the current date to 6 months out
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddMonths(6).AddDays(1);
            int currentFlightID = SqliteDataAccess.GetLastAvailableFlightID();

            // keep making flights from now to 6 months out
            while (DateTime.Compare(startDate, endDate) < 0)
            {
                DateTime newDepartureDateTime = startDate.Date + masterFlight.departureDateTime.TimeOfDay;
                //create the new available flight based on the master flight templeate and add it to the available flights table
                decimal duration = (decimal)(masterFlight.distance / 500.0) + .5M + (40 / 60.0M);
                decimal cost = (decimal)(masterFlight.distance * .12);
                FlightModel newAvaFlight = new FlightModel(currentFlightID, masterFlight.flightID, masterFlight.originCode,
                                                            masterFlight.destinationCode, (int)masterFlight.distance,
                                                            newDepartureDateTime, (double)duration, masterFlight.planeType,
                                                            (double)cost, SqliteDataAccess.GetPlaneCapacity(masterFlight.planeType), 0);
                SqliteDataAccess.AddFlightToAvailable(newAvaFlight);
                currentFlightID++;
                // increment the date
                DateTime newStartDate = startDate.AddDays(1);
                startDate = newStartDate;
            }
        }

        public static void CleanAvailableFlights()
        {
            // Get the oldest date in the available flights data base
            if (SqliteDataAccess.GetOldestAvailable().Equals("")) return;
            DateTime oldestDate = Convert.ToDateTime(SqliteDataAccess.GetOldestAvailable());
            DateTime endDate = DateTime.Now;
            
            // Clean from oldest date till the current date is reached
            while (oldestDate.ToShortDateString() != endDate.ToShortDateString())
            {
                SqliteDataAccess.RemoveOldAvailable(oldestDate.ToShortDateString());
                DateTime newOldestDate = oldestDate.AddDays(1);
                oldestDate = newOldestDate;
            }
        }

    }
}

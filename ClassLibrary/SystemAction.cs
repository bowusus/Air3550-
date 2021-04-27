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
        public static FlightModel GetFlight(int flightID, int i)
        {
            // This method gets the specified flight's data. It calculates its cost, points, and duration,
            // Then it makes it a flight object and returns the flight
            List<string> flightsBookedData = SqliteDataAccess.GetFlightData(flightID);

            string originName = SqliteDataAccess.GetFlightNames(flightsBookedData[2]);
            string destinationName = SqliteDataAccess.GetFlightNames(flightsBookedData[3]);

            DateTime departureDateTime = DateTime.Parse(flightsBookedData[4] + " " + flightsBookedData[5]);
            DateTime arriveDateTime = departureDateTime.AddHours(Convert.ToDouble(flightsBookedData[7]));
            int depHour = departureDateTime.Hour;
            int arrHour = arriveDateTime.Hour;

            double currCost;
            if (i == 0)
                currCost = CalculateCost(depHour, arrHour, Convert.ToDouble(flightsBookedData[9]) + 50);
            else
                currCost = CalculateCost(depHour, arrHour, Convert.ToDouble(flightsBookedData[9]) + 8);
            int currPoints = Convert.ToInt32(currCost * 100);

            var duration = arriveDateTime.Subtract(departureDateTime);
            duration = new TimeSpan(duration.Ticks / TimeSpan.TicksPerSecond * TimeSpan.TicksPerSecond);

            departureDateTime = arriveDateTime.Subtract(duration);
            FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), int.Parse(flightsBookedData[1]), flightsBookedData[2], originName, flightsBookedData[3], destinationName, int.Parse(flightsBookedData[6]), departureDateTime, arriveDateTime, duration, flightsBookedData[8], Math.Round(currCost, 2), currPoints, int.Parse(flightsBookedData[10]), Convert.ToDouble(flightsBookedData[11]));

            return flight;
        }
        public static List<Route> GetFlights_MasterID(string origin, string destination, DateTime departDate, DateTime compareDateTime)
        {
            // This method finds all available routes for the given origin and destination
            // A list of the available routes are returned
            List<Route> routes = new List<Route>();
            List<(int, int)> routeInfo = SqliteDataAccess.GetRouteInfo(origin, destination, departDate.Date, compareDateTime.Date);
            // go through the route IDs that were found for the specified origin and destination
            // and get the flightIDs in that route, then get information to display to the customer
            foreach ((int, int) id in routeInfo)
            {
                List<int> masterFlightIDs = SqliteDataAccess.GetFlightIDsInRoute(id.Item1);
                List<(int, DateTime)> flightIDs_MasterID = new List<(int, DateTime)>();
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
                int index = 0;

                foreach (int mID in masterFlightIDs)
                {
                    if (index == flightIDs_MasterID.Count)
                    {
                        if (flightIDs_MasterID.Count > 0 && flightIDs_MasterID[index - 1].Item2.Date != departDate.Date)
                            flightIDs_MasterID = SqliteDataAccess.GetFlightIDs_MasterID(mID, flightIDs_MasterID, departDate.AddDays(1), compareDateTime);
                        else
                            flightIDs_MasterID = SqliteDataAccess.GetFlightIDs_MasterID(mID, flightIDs_MasterID, departDate, compareDateTime);
                        index += 1;
                    }
                }
                if (flightIDs_MasterID.Count == masterFlightIDs.Count)
                {
                    // go through each of these flight IDs, make a flight object, add it to the list to be returned
                    // add some formatting since this method is used to populate the datagridview tables in the bookFlight form
                    foreach ((int fID, DateTime date) in flightIDs_MasterID)
                    {
                        FlightModel flight = GetFlight(fID, i);
                        flights.Add(flight);
                        cost += flight.cost;
                        points += flight.numOfPoints;
                        if (i == masterFlightIDs.Count - 1)
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
                        arrive = flights[masterFlightIDs.Count - 1].arrivalDateTime;
                        var duration = arrive.Subtract(depart);
                        duration = new TimeSpan(duration.Ticks / TimeSpan.TicksPerSecond * TimeSpan.TicksPerSecond);
                        string credits = "$" + cost + " (" + points + " points)";
                        Route route = new Route(id.Item1, depart, arrive, duration, id.Item2, routeList, planeChange, seatsAvailable, credits);
                        routes.Add(route);
                    }
                }
            }
            return routes;
        }
        public static double CancelFlight(int uID, FlightModel flight, string paymentMethod, double totalCredit, int totalPoints)
        {
            // This method is used to cancel the specified flight and update the total credits or points
            // Depending on whether the payment method was dollars, airline credit, or points, whichever value is returned

            // Move the specified flight from booked to cancelled and increase the number of vacant seats in the plane
            SqliteDataAccess.RemoveFromFlightsBooked(uID, flight.flightID);
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
        public static List<int> DeriveFlightIDs_SelectedRoute(string flightIDs)
        {
            List<int> flightIDsList = new List<int>();
            int index1 = flightIDs.IndexOf("\r\n"); // get the first index of the first space to find the available seats of the first flight in the route 
            int index2 = flightIDs.LastIndexOf("\r\n"); // get the last index of the space to find the available seats of the second and third flight in the route 
            int flightID1; // used for available seats on the first flight
            int flightID2; // used for available seats on the second flight
            int flightID3; // used for available seats on the third flight
            if (index1 == -1) // if there is no "\r\n" then, there is only one flight
            {
                flightID1 = int.Parse(flightIDs);
                flightIDsList.Add(flightID1);
                return flightIDsList;
            }
            else if (index1 == index2) // if the index of the first and last "\r\n" are the same, then there are two flights
            {
                flightID1 = int.Parse(flightIDs.Substring(0, index1));
                flightID2 = int.Parse(flightIDs.Substring(index1 + 1, flightIDs.Length - index1 - 1));
                flightIDsList.Add(flightID1);
                flightIDsList.Add(flightID2);
                return flightIDsList;
            }
            else // if the index of the first and last "\r\n" are different, then there are three flights
            {
                flightID1 = int.Parse(flightIDs.Substring(0, index1));
                flightID2 = int.Parse(flightIDs.Substring(index1 + 1, index2 - index1));
                flightID3 = int.Parse(flightIDs.Substring(index2 + 1, flightIDs.Length - index2 - 1));
                flightIDsList.Add(flightID1);
                flightIDsList.Add(flightID2);
                flightIDsList.Add(flightID3);
                return flightIDsList;
            }
        }
        public static FlightModel GetBoardingFlights(int FID, int i, ref CustomerModel customer)
        {
            // This method gets the specified flight's data. It calculates its cost, points, and duration,
            // Then it makes it a flight object and returns the flight
            // specific to the boarding pass (aka includes name)
            List<string> flightsBookedData = SqliteDataAccess.GetFlightData(FID);

            string originName = SqliteDataAccess.GetFlightNames(flightsBookedData[2]);
            string destinationName = SqliteDataAccess.GetFlightNames(flightsBookedData[3]);

            DateTime departureDateTime = DateTime.Parse(flightsBookedData[4] + " " + flightsBookedData[5]);
            DateTime arriveDateTime = departureDateTime.AddHours(Convert.ToDouble(flightsBookedData[7]));

            var duration = arriveDateTime.Subtract(departureDateTime);
            duration = new TimeSpan(duration.Ticks / TimeSpan.TicksPerSecond * TimeSpan.TicksPerSecond);

            departureDateTime = arriveDateTime.Subtract(duration);

            FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), departureDateTime, arriveDateTime,  duration, originName, destinationName, ref customer);
            
            return flight;

        }
        /* Generates all available flights for each master flight from the last generated date in the 
         * available flights table to 6 months from the current date */
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
                    decimal duration = (decimal)(masterFlight.distance / 500.0) + .5M;
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
        /* Generates all the available flights for the newly created masterFlight based on
         * the next days date to 6 months out */
        public static void GenerateFlight(FlightModel masterFlight)
        {
            // New flight has been made in master so creating all available flights from the current date to 6 months out
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddMonths(6).AddDays(1);
            int currentFlightID = SqliteDataAccess.GetLastAvailableFlightID();

            // keep making flights from now to 6 months out
            while (DateTime.Compare(startDate, endDate) < 0)
            {
                DateTime newDepartureDateTime = startDate.Date + masterFlight.departureDateTime.TimeOfDay;
                //create the new available flight based on the master flight templeate and add it to the available flights table
                decimal duration = (decimal)(masterFlight.distance / 500.0) + .5M;
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
        /*
         * On start up this method will take any flights from the customer's booked flight list 
         * and set them as being taken if the date and time is less than the current date and time
         */
        public static void SetTakenFlights(int custID)
        {
            // Checks flights booked by the current custID
            List<int> bookedFIDs = SqliteDataAccess.GetBookedFlightIDs(custID);
            // Cycles through all booked flights by the current customer and 
            // checks if they are old if they are then they get passed to the
            // flights taken table and is removed from booked flights
            foreach(int bookedFID in bookedFIDs)
            {
                if(SqliteDataAccess.CheckIfBookedOld(bookedFID))
                {
                    SqliteDataAccess.AddToFlightsTaken(custID, bookedFID);
                    SqliteDataAccess.RemoveFromFlightsBooked(custID, bookedFID);
                }
            }
        }
    }
}
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
        public static List<FlightModel> GetCurrentFlights(int userID)
        {
            // This method creates a list of Flights that allows this page to access that flights details without going back to the database
            // After every cancellation, the current flights are repopulated and updates the datagridview with the most current information
            // A list of the current flights are returned
            List<int> flightIDs;
            List<FlightModel> flights = new List<FlightModel>();
            flightIDs = SqliteDataAccess.GetCurrentFlightIDs(userID); // get the flight ids of the customer's current flights 
            // for each of these ids, get the flight information (origin, destination, etc.)
            // Then get the name of the airports
            // Finally create a FlightModel object with that information and add it to a list of booked flights to be displayed to the customer
            foreach (int id in flightIDs)
            {
                List<string> flightsBookedData = SqliteDataAccess.GetFlightData(id);
                string originName = SqliteDataAccess.GetFlightNames(flightsBookedData[1]);
                string destinationName = SqliteDataAccess.GetFlightNames(flightsBookedData[2]);
                FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), int.Parse(flightsBookedData[1]), flightsBookedData[2], originName, flightsBookedData[3], destinationName, int.Parse(flightsBookedData[4]), DateTime.Parse(flightsBookedData[5]), Convert.ToDouble(flightsBookedData[6]), flightsBookedData[7], DateTime.Parse(flightsBookedData[8]), Convert.ToDouble(flightsBookedData[9]), int.Parse(flightsBookedData[10]), int.Parse(flightsBookedData[11]), Convert.ToDouble(flightsBookedData[12]));
                flights.Add(flight);
            }
            return flights;
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
                //create the new available flight based on the master flight templeate and add it to the available flights table
                decimal duration = (decimal)(masterFlight.distance / 500.0) + .5M + (40 / 60.0M);
                decimal cost = (decimal)(masterFlight.distance * .12);
                FlightModel newAvaFlight = new FlightModel(currentFlightID, masterFlight.flightID, masterFlight.originCode,
                                                            masterFlight.destinationCode, (int)masterFlight.distance,
                                                            startDate, (double)duration, masterFlight.planeType,
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

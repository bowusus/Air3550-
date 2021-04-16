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
        public static string ValidateAccountFormat(string password, string firstName, string lastName, string street, string city, string zip, string phone, string creditCardNum, string email)
        {
            // This method checks the format of the account information
            // If any of the formats are invalid or the information is blank (besides the password), it is added to an errorMessage string that is returned
            // set the formats for the city, zip code, phone number, credit card number, and email
            Regex cityReg = new Regex(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$");
            Regex zipReg = new Regex(@"^\d{5}(?:[-]\d{4})?$");
            Regex phoneReg = new Regex(@"^\(?([0-9]{3})\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$");
            Regex creditCardReg = new Regex(@"^?\d{4}-?\d{4}-?\d{4}-?\d{4}$");
            Regex emailReg = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            // match the provided string with the format
            Match cityMatch = cityReg.Match(city);
            Match zipMatch = zipReg.Match(zip);
            Match phoneMatch = phoneReg.Match(phone);
            Match creditCardMatch = creditCardReg.Match(creditCardNum);
            Match emailMatch = emailReg.Match(email);

            string errorMessage = null;

            // check if any of the text boxes are empty 
            // add any of the invalid information errors to the errorMessage string
            if (String.IsNullOrEmpty(firstName))
                errorMessage += "FIRST NAME is Blank\n";
            if (String.IsNullOrEmpty(lastName))
                errorMessage += "LAST NAME is Blank\n";
            if (String.IsNullOrEmpty(street))
                errorMessage += "STREET is Blank\n";
            if (String.IsNullOrEmpty(city))
                errorMessage += "CITY is Blank\n";
            else if (!cityMatch.Success)
                errorMessage += "The provided CITY is invalid\n";
            if (String.IsNullOrEmpty(zip))
                errorMessage += "ZIP CODE is Blank\n";
            else if (!zipMatch.Success)
                errorMessage += "The provided ZIP CODE is invalid. Provide an email that is of the format: XXXXX-XXXX or XXXXX where X's are numbers\n";
            if (String.IsNullOrEmpty(phone))
                errorMessage += "PHONE NUMBER is Blank\n";
            else if (!phoneMatch.Success)
                errorMessage += "The provided PHONE NUMBER is invalid. Provide an email that is of the format shown on the form\n";
            if (String.IsNullOrEmpty(creditCardNum))
                errorMessage += "CREDIT CARD NUMBER is Blank\n";
            else if (!creditCardMatch.Success)
                errorMessage += "The provided CREDIT CARD NUMBER is invalid. Provide an email that is of the format shown on the form\n";
            if (String.IsNullOrEmpty(email))
                errorMessage += "EMAIL is Blank\n";
            else if (!emailMatch.Success)
                errorMessage += "The provided EMAIL is invalid\n";

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
                FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), flightsBookedData[1], originName, flightsBookedData[2], destinationName, int.Parse(flightsBookedData[3]), DateTime.Parse(flightsBookedData[4]), Convert.ToDouble(flightsBookedData[5]), flightsBookedData[6], DateTime.Parse(flightsBookedData[7]), Convert.ToDouble(flightsBookedData[8]), int.Parse(flightsBookedData[9]), int.Parse(flightsBookedData[10]), Convert.ToDouble(flightsBookedData[11]));
                flights.Add(flight);
            }
            return flights;
        }

        public static void GenerateFlights()
        {

        }
    }
}

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
        public static string ValidateAccountFormat(string city, string zip, string phone, string creditCard, string email)
        {
            // This method checks the format provided for the city, zip code, phone number, credit card number, and email
            // If any of the formats are invalid, it is added to an errorMessage string that is returned

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
            Match creditCardMatch = creditCardReg.Match(creditCard);
            Match emailMatch = emailReg.Match(email);

            string errorMessage = null; // used to create an error message for the user

            // check if any of the matches were unsuccessful and add that format error to the error Message that is returned
            if (!cityMatch.Success)
                errorMessage += "The provided CITY is invalid\n";
            if (!zipMatch.Success)
                errorMessage += "The provided ZIP CODE is invalid. Provide an email that is of the format: XXXXX-XXXX or XXXXX where X's are numbers\n";
            if (!phoneMatch.Success)
                errorMessage += "The provided PHONE NUMBER is invalid. Provide an email that is of the format shown on the form\n";
            if (!creditCardMatch.Success)
                errorMessage += "The provided CREDIT CARD NUMBER is invalid. Provide an email that is of the format shown on the form\n";
            if (!emailMatch.Success)
                errorMessage += "The provided EMAIL is invalid";
            return errorMessage; // return any errors
        }
    }
}

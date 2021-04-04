using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public class CustomerModel
	{
		// This class file is the CustomerModel class. There are 
		// the attributes associated with the Customer included, 
		// the constructor to create an instance of the CustomerModel,
		// and methods to describe the actions the customer does.

		// auto-implemented properties for trivial get and set
		public int userID { get; set; }
		public string password { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string street { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zipCode { get; set; }
		public string phoneNumber { get; set; }
		public string creditCardNumber { get; set; }
		public int age { get; set; }
		public string email { get; set; }

		// customer constructor
		public CustomerModel(int tempUserID, string pass, string first, string last, string street1, string city1, string state1, string zip, string phone, string creditCardNumber1, int age1, string email1)
		{
			userID = tempUserID;
			password = pass;
			firstName = first;
			lastName = last;
			street = street1;
			city = city1;
			state = state1;
			zipCode = zip;
			phoneNumber = phone;
			creditCardNumber = creditCardNumber1;
			age = age1;
			email = email1;
		}
	}
}

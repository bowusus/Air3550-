using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public class FlightModel
	{
		public CustomerModel currCustomer;

		// This class file is the FlightModel class. There are 
		// the attributes associated with the Flight included, 
		// the constructor to create an instance of the FlightModel,
		// and methods to describe the actions the flight does.
		// auto-implemented properties for trivial get and set
		public int flightID { get; set; }
		public int userid { get; set; }
		public string firstName { get; set; }	
		public string lastName { get; set; }
		public int masterFlightID { get; set; }
		public string originCode { get; set; }
		public string originName { get; set; }
		public string destinationCode { get; set; }
		public string destinationName { get; set; }
		public int distance { get; set; }
		public DateTime departureDateTime { get; set; }
		public DateTime arrivalDateTime { get; set; }
		public double durDouble { get; set; }
		public TimeSpan duration { get; set; }
		public string planeType { get; set; }
		public double cost { get; set; }
		public int numOfPoints { get; set; }
		public int numberOfVacantSeats { get; set; }
		public double percentFull { get; set; }
		public double flightIncome { get; set; }

		/* This overloading of the flight model is used mainly to display the flight's details that are important to the customer. 
		 * Used in Booking, Cancelling, and Account History */
		public FlightModel(int fID, int mID, string origin, string oName, string destination, string dName, int dist, DateTime departDate, DateTime arriveDate, TimeSpan dur, string plane, double baseCost, int points, int seats, double income)
		{
			flightID = fID;
			masterFlightID = mID;
			originCode = origin;
			originName = oName;
			destinationCode = destination;
			destinationName = dName;
			distance = dist;
			departureDateTime = departDate;
			arrivalDateTime = arriveDate;
			duration = dur;
			planeType = plane;
			cost = baseCost;
			numOfPoints = points;
			numberOfVacantSeats = seats;
			flightIncome = income;
		}
		/* This overloading of the flight model is specifically used to get the important details to display on the Flight Manager and 
		 * Account Manager pages (with % capacity) */
		public FlightModel(int flightID, int masterFlightID, string originCode, string destinationCode, int distance, DateTime departureDateTime, double duration,
						   string planeType, double cost, int numberOfVacantSeat, double flightIncome, double percentage)
		{
			this.flightID = flightID;
			this.masterFlightID = masterFlightID;
			this.originCode = originCode;
			this.destinationCode = destinationCode;
			this.distance = distance;
			this.departureDateTime = departureDateTime;
			this.durDouble = duration;
			this.planeType = planeType;
			this.cost = cost;
			this.numberOfVacantSeats = numberOfVacantSeat;
			this.percentFull = percentage;
			this.flightIncome = flightIncome;
		}
		/* This overloading of the flight model is specific for the availableFlight table we have in the database */
		public FlightModel(int flightID, int masterFlightID, string originCode, string destinationCode, int distance, DateTime departureDateTime, double duration,
						   string planeType, double cost, int numberOfVacantSeat, double flightIncome)
		{
			this.flightID = flightID;
			this.masterFlightID = masterFlightID;
			this.originCode = originCode;
			this.destinationCode = destinationCode;
			this.distance = distance;
			this.departureDateTime = departureDateTime;
			this.durDouble = duration;
			this.planeType = planeType;
			this.cost = cost;
			this.numberOfVacantSeats = numberOfVacantSeat;
			this.flightIncome = flightIncome;
		}
		/* This overloading of the flight model is specific for the masterFlight table we have in the database it is basically a
		 * template for the creation of all available flights*/
		public FlightModel(int flightID, string originCode, string destinationCode, int distance, DateTime departureDateTime, string planeType)
		{
			this.flightID = flightID;
			this.originCode = originCode;
			this.destinationCode = destinationCode;
			this.distance = distance;
			this.departureDateTime = departureDateTime;
			this.planeType = planeType;
			this.numberOfVacantSeats = SqliteDataAccess.GetPlaneCapacity(this.planeType);
		}
		/* This overloading of the flight model is specific for the direct flight the edges of the graph
		 * Connecting all of the airports (vectors) in the graph */
		public FlightModel(string originCode, string destinationCode, int distance)
		{
			this.originCode = originCode;
			this.destinationCode = destinationCode;
			this.distance = distance;
		}
		/* This overloading of the flight model is specific to the boarding pass page */
		public FlightModel (int fID, DateTime departDate, DateTime arriveDate, TimeSpan dur,  string origin, string destination, ref CustomerModel customer)
        {
			flightID = fID;
			originName = origin;
			destinationName = destination;
			duration = dur;
			departureDateTime = departDate;
			arrivalDateTime = arriveDate;
			firstName = customer.firstName;
			lastName = customer.lastName;
			userid = customer.userID;
		}
	}
}
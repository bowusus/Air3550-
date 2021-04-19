using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public class FlightModel
	{
		// This class file is the FlightModel class. There are 
		// the attributes associated with the Flight included, 
		// the constructor to create an instance of the FlightModel,
		// and methods to describe the actions the flight does.

		// auto-implemented properties for trivial get and set
		public int flightID { get; set; }
		public int masterFlightID { get; set; }
		public string originCode { get; set; }
		public string originName { get; set; }
		public string destinationCode { get; set; }
		public string destinationName { get; set; }
		public double distance { get; set; }
		public DateTime departureDateTime { get; set; }
		public TimeSpan duration { get; set; }
		public string planeType { get; set; }
		public int cost { get; set; }
		public int numOfPoints { get; set; }
		public int numberOfVacantSeats { get; set; }
		public double flightIncome { get; set; }

		// customer constructor
		public FlightModel(int fID, int mID, string origin, string oName, string destination, string dName, int dist, DateTime date, TimeSpan dur, string plane, int baseCost, int points, int seats, double income)
		{
			flightID = fID;
			masterFlightID = mID;
			originCode = origin;
			originName = oName;
			destinationCode = destination;
			destinationName = dName;
			distance = dist;
			departureDateTime = date;
			duration = dur;
			planeType = plane;
			cost = baseCost;
			numOfPoints = points;
			numberOfVacantSeats = seats;
			flightIncome = income;
		}
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
		public FlightModel(string originCode, string destinationCode, int distance)
		{
			this.originCode = originCode;
			this.destinationCode = destinationCode;
			this.distance = distance;
		}
	}
}

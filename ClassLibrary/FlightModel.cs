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
		public string originCode { get; set; }
		public string originName { get; set; }
		public string destinationCode { get; set; }
		public string destinationName { get; set; }
		public int distance { get; set; }
		public DateTime departureDateTime  { get; set; }
		public double totalTime { get; set; }
		public string planeType { get; set; }
		public DateTime dateCreated { get; set; }
		public double cost { get; set; }
		public int amountOfPoints { get; set; }
		public int numberOfVacantSeats { get; set; }
		public double flightIncome { get; set; }
		// customer constructor
		public FlightModel(int fID, string origin, string oName, string destination, string dName, int dist, DateTime departure, double time, string plane, DateTime date, double baseCost, int points, int seats, double income)
		{
			flightID = fID;
			originCode = origin;
			originName = oName;
			destinationCode = destination;
			destinationName = dName;
			distance = dist;
			departureDateTime = departure;
			totalTime = time;
			planeType = plane;
			dateCreated = date;
			cost = baseCost;
			amountOfPoints = points;
			numberOfVacantSeats = seats;
			flightIncome = income;
		}

		public FlightModel(int flightID, string originCode, string destinationCode, int distance, DateTime departureDateTime)
        {
			this.flightID = flightID;
			this.originCode = originCode;
			this.destinationCode = destinationCode;
			this.distance = distance;
			this.departureDateTime = departureDateTime;
		}

		public FlightModel(string originCode, string destinationCode, int distance)
		{
			this.originCode = originCode;
			this.destinationCode = destinationCode;
			this.distance = distance;
		}
	}
}

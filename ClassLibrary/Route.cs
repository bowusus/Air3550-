using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public class Route
	{
		// This class file is the Route class. There are 
		// the attributes associated with the Route included and 
		// the constructor to create an instance of the Route
		// auto-implemented properties for trivial get and set
		public int routeID { get; set; }
		public DateTime departTime { get; set; }
		public DateTime arriveTime { get; set; }
		public TimeSpan duration { get; set; }
		public int numOfLayovers { get; set; }
		public string flightIDs { get; set; }
		public string planeChange { get; set; }
		public string availableSeats { get; set; }
		public string credits { get; set; }
		/* This overloading of the route object is used to return information about the flight when the customer is searching for flights to book */
		public Route(int rID, DateTime depart, DateTime arrival, TimeSpan dur, int num, string fID, string changeName, string seats, string cred)
		{
			routeID = rID;
			departTime = depart;
			arriveTime = arrival;
			duration = dur;
			numOfLayovers = num;
			flightIDs = fID;
			planeChange = changeName;
			availableSeats = seats;
			credits = cred;
		}
	}
}

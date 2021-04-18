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
		public string departTime { get; set; }
		public string arriveTime { get; set; }
		public TimeSpan duration { get; set; }
		public int numOfLayovers { get; set; }
		public string flightIDs { get; set; }
		public string changePlaneCode { get; set; }
		public string changePlaneName { get; set; }
		public string availableSeats { get; set; }
		public string credits { get; set; }
		// route constructor
		public Route(int rID, string depart, string arrival, TimeSpan dur, int num, string fID, string changeCode, string changeName, string seats, string cred)
		{
			routeID = rID;
			departTime = depart;
			arriveTime = arrival;
			duration = dur;
			numOfLayovers = num;
			flightIDs = fID;
			changePlaneCode = changeCode;
			changePlaneName = changeName;
			availableSeats = seats;
			credits = cred;
		}
	}
}

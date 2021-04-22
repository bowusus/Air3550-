﻿using System;
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
		public double durDouble { get; set; }
		public int masterFlightID { get; set; }
		public int numOfPoints { get; set; }
		public string originCode { get; set; }
		public string originName { get; set; }
		public string firstName { get; set; }
		public int userid { get; set; }
		public string lastName { get; set; }
		public string destinationCode { get; set; }
		public string destinationName { get; set; }
		public DateTime arrivaltime { get; set; }
		public double distance { get; set; }
		public DateTime departureDateTime { get; set; }
		public TimeSpan duration { get; set; }



		public double totalTime { get; set; }
		public string planeType { get; set; }
		public DateTime dateCreated { get; set; }
		public double cost { get; set; }
		public int amountOfPoints { get; set; }
		public int numberOfVacantSeats { get; set; }
		public double flightIncome { get; set; }


		public FlightModel(ref CustomerModel customer)
		{

			currCustomer = customer;

		}



		// customer constructor
		public FlightModel(int fID, int mID, string origin, string oName, string destination, string dName, int dist, DateTime date, TimeSpan dur, string plane, double baseCost, int points, int seats, double income)
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


		public FlightModel (int fID, DateTime depat, TimeSpan dur,  string origin, string destination, ref CustomerModel customer)
        {
			flightID = fID;
			originName = origin;
			destinationName = destination;
			//arrivaltime = arrival;
			duration = dur;
			departureDateTime = depat;
			firstName = customer.firstName;
			lastName = customer.lastName;
			userid = customer.userID;


		}
	}
}

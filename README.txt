Written By: Bernard Owusu Sefah
			Lindsey Forche
			Thomas Runyan
			
Class: EECS 3550 Software Engineering
Submission Date: 4/28/2021

Project Description:
	Create a reservation system for a new airline that allows: 
    -Customers to book and cancel flights, view account history and 
     information, print boarding pass, log in, and create an account
    -Accounting Managers to view how many flights we had, how full each one 
     was, and what the income was not only per flight, but for the company 
     as a whole and to print the summary report
    -Flight Managers to view/print flight manifests when the flight takes off
    -Load Engineers to add/edit/delete routes
    -Marketing Managers to decide what planes to use for each flight

Getting Started:
	Pre-Populated Login Info:
		Customers:
			- userID = 152340 password 123456
			- userID = 459387 password 123456
			- userID = 553077 password 123456
			- userID = 599800 password 123456
			- userID = 689178 password 123456
			- userID = 795965 password 123456
			- userID = 880752 password 123456
			- userID = 855557 password 123456
			- userID = 959193 password 123456
			- userID = 968693 password 123456
		
		Employees
			-Accounting Manager: userID = 111111 password = accounting
			-Flight Manager:     userID = 222222 password = flight
			-Load Engineer:      userID = 333333 password = loadengineer
			-Marketing Manager:  userID = 444444 password = marketing
	
	Information On How Load Engineer Works:
		When choosing a route masterFlights are created for that route if they do not
		already exist then availableFlights are generated based on the new masterFlights for tomorrow
		till 6 months out.
		
		As such if you add a flight on your current date the customer is unable to see that route being
		offered till the next day. As such you may need to change the date on your pc to one day forward.
		
		Also flights are generated for the system on launch so if there are availableFlights that do not
		exist for some masterFlights within the range of 6 months from the current date then the corresponding
		availableFlights are generated. This may take some time depending on how many flights needed to be 
		generated.
		
	Information On How Marketing Manager:
		Changes to plane type are not reflected in previously generated flights only in flights generated
		after the change occured.
	
	Information On Accounting Manager:
		Percent Full Capacity is within table on specific row might have to scroll to the right
		Only flights that have taken off are reflected in the tables 
		(i.e. flights that take place on the current day or previous nothing in the future)
		
	Information On Flight Manager:
		Only flights that have taken off are reflected in the tables 
		(i.e. flights that take place on the current day or previous nothing in the future)
		
	Database Viewing Application We Used: SQLite DB Browser


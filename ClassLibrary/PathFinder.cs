using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /* This class will build the graph and find the path from one airport to another airport */
    public class PathFinder
    {
        private Airport origin, destination;
        private List<Airport> airports;
        private List<FlightModel> directFlights;
        public PathFinder(Airport origin, Airport destination, List<Airport> airports, List<FlightModel> directFlights)
        {
            this.origin = origin;
            this.destination = destination;
            this.airports = airports;
            this.directFlights = directFlights;
        }
        /*  
            Explores all paths between two vertices in the graph
        */
        public List<Path> BFS()
        {
            int currentPathID = 1;
            Queue<List<Airport>> queue = new Queue<List<Airport>>();
            List<Airport> path = new List<Airport>();
            List<Path> allPaths = new List<Path>();
            //Add the origin to the first path
            path.Add(origin);
            //queue the path
            queue.Enqueue(path);

            while (queue.Count != 0)
            {
                //get path at front of queue
                path = queue.Dequeue();
                //grabbing the last airport in the current path
                Airport last = path[path.Count - 1];

                //if last in the path is the expected destination then add to official path array
                //and increment path id
                if (last == destination)
                {
                    allPaths.Add(new Path(currentPathID, path.Count - 2, path.ToArray()));
                    currentPathID++;
                }

                //if their are less than 4 airports in path then find all of the next airports to go from the current last airport
                //and make new paths and add those paths to the queue
                if (path.Count < 4)
                {
                    foreach (FlightModel directFlight in directFlights)
                    {
                        if (last.Code == directFlight.originCode && !path.Exists(airport => airport.Code == directFlight.destinationCode))
                        {
                            List<Airport> newPath = new List<Airport>(path);
                            newPath.Add(airports.Find(airports => airports.Code == directFlight.destinationCode));
                            queue.Enqueue(newPath);
                        }
                    }
                }
            }
            // All paths from origin to destination with less than 3 layovers have been found return all paths
            return allPaths;
        }
    }
}

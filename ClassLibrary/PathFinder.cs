using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
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
            Queue<List<Airport>> queue = new Queue<List<Airport>>();
            List<Airport> path = new List<Airport>();
            List<Path> allPaths = new List<Path>();
            path.Add(origin);
            queue.Enqueue(path);

            while (queue.Count != 0)
            {
                path = queue.Dequeue();
                Airport last = path[path.Count - 1];

                if (last == destination)
                {
                    allPaths.Add(new Path(path.Count - 2, path.ToArray()));
                }

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
            return allPaths;
        }
    }
}

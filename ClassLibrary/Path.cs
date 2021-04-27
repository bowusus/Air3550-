using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /* Path contains almost all the information to create a route 
       and will be constructed when gathering all possible paths that can
       be taken from on vector to another vector */
    public class Path
    {
        int pathID;
        int numberOfLayovers;
        Airport[] airports;
        public Path(int pathID, int numberOfLayovers, Airport[] airports)
        {
            this.pathID = pathID;
            this.NumberOfLayovers = numberOfLayovers;
            this.Airports = airports;
        }
        public int PathID { get => pathID; set => pathID = value; }
        public int NumberOfLayovers { get => numberOfLayovers; set => numberOfLayovers = value; }
        public Airport[] Airports { get => airports; set => airports = value; }
    }
}

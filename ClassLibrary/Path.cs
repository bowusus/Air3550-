using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Path
    {
        int numberOfLayovers;
        Airport[] airports;

        public Path(int numberOfLayovers, Airport[] airports)
        {
            this.NumberOfLayovers = numberOfLayovers;
            this.Airports = airports;
        }

        public int NumberOfLayovers { get => numberOfLayovers; set => numberOfLayovers = value; }
        public Airport[] Airports { get => airports; set => airports = value; }
    }
}

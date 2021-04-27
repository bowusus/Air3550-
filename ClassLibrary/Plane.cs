using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Plane
    {
        // This class file is the plane class. There are 
        // the attributes associated with the plane included and 
        // the constructor to create an instance of the plane
        // auto-implemented properties for trivial get and set
        private string planeType;
        private int capacity, maxDistance;
        public string PlaneType { get => planeType; set => planeType = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int MaxDistance { get => maxDistance; set => maxDistance = value; }
        public Plane(string planeType, int capacity, int maxDistance)
        {
            this.planeType = planeType;
            this.capacity = capacity;
            this.maxDistance = maxDistance;
        }
    }
}

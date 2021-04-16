using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Plane
    {
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

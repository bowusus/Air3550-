using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Airport
    {
        // This class file is the Airport class. There are 
        // the attributes associated with the Airport included and 
        // the constructor to create an instance of the Airport
        // auto-implemented properties for trivial get and set
        string code, name;
        public Airport(string code, string name)
        {
            this.code = code;
            this.name = name;
        }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
    }
}

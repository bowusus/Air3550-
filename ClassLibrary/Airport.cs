using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Airport
    {
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

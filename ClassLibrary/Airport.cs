using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Airport
    {
        string code, name, timezone;

        public Airport(string code, string name, string timezone)
        {
            this.code = code;
            this.name = name;
            this.timezone = timezone;
        }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Timezone { get => timezone; set => timezone = value; }
    }
}

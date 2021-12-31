using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Advanced.Client.Data
{
    public class Measurement
    {
        public Guid Guid { get; set; }
        public double Min { get; set; }
        public double Avg { get; set; }
        public double Max { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Advanced.Client.Data
{
    public class ComponentMetaData
    {
        public Type Type { get; set; }
        public Dictionary<string, object> Parameters { get; }
        public ComponentMetaData(Type type, Dictionary<string, object> parameters)
        {
            Type = type;
            Parameters = parameters;
        }
    }
}

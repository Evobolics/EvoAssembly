using System;
using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Mapping
{
    public class InterfaceNode
    {
        public Dictionary<string, Type> Classes { get; set; } = new Dictionary<string, Type>();

        public System.Type Interface { get; set; }
        public string FullName { get; set; }
    }
}

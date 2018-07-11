using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class GenericArgumentEntryMap
    {
        public Dictionary<int, GenericArgumentEntry> Method { get; set; } = new Dictionary<int, GenericArgumentEntry>();

        public Dictionary<int, GenericArgumentEntry> Type { get; set; } = new Dictionary<int, GenericArgumentEntry>();
    }
}

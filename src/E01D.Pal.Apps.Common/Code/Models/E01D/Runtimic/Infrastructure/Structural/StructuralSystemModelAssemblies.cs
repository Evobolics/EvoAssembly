using System;
using System.Collections.Generic;
using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural
{
    public class StructuralSystemModelAssemblies
    {
        

        public Dictionary<string, StructuralAssemblyNode> ByName { get; set; } =
            new Dictionary<string, StructuralAssemblyNode>();

        public Tuple<Assembly, StructuralAssemblyNode>[] QuickReference { get; set; } =
            new Tuple<Assembly, StructuralAssemblyNode>[15];

        public int QuickReferenceCount { get; set; }
    }
}

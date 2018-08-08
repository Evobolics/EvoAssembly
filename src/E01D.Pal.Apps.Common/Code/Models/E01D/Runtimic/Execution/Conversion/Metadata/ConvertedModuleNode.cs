using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedModuleNode
    {
        public ConvertedModuleNode()
        {
            
        }

        public ConvertedAssemblyNode AssemblyNode { get; set; }

        public ConvertedModule ConvertedModule { get; set; }

        public StructuralModuleNode InputStructuralDefinition { get; set; }

        public Dictionary<int, ConvertedTypeTable> Tables { get; set; } =
            new Dictionary<int, ConvertedTypeTable>();

        
        
    }
}

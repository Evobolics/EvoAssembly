using System;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedAssemblyNode
    {
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the structural node that provides the input source information for this particular conversion node.
        /// </summary>
        public StructuralAssemblyNode InputStructuralNode { get; set; }

        /// <summary>
        /// Gets or sets the input unified type node associated with this node.
        /// </summary>
        public UnifiedAssemblyNode InputUnifiedNode { get; set; }

        /// <summary>
        /// Gets or sets the actual converted assembly.
        /// </summary>
        public ConvertedAssembly ConvertedAssembly { get; set; }

        public long MetadataId { get; set; }

        public string InputFullName { get; set; }

        public string FullName { get; set; }
        public Guid Guid { get; set; }
        public bool IsEntireAssemblyConverted { get; set; }
    }
}

using System.Collections.Generic;
using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
    /// <summary>
    /// Represents an asembly that has been bound.
    /// </summary>
    public class BoundAssembly: BoundMetadata, BoundAssembly_I
    {
        public SemanticAssemblyAssembliesMask_I Assemblies { get; set; } = new BoundAssemblyAssemblies();

        public Assembly Assembly { get; set; }

        public AssemblyDefinition AssemblyDefinition { get; set; }

        public bool IsBuiltOut { get; set; }

        public string FullName { get; set; }

        public Dictionary<string, SemanticModuleMask_I> Modules { get; set; } = new Dictionary<string, SemanticModuleMask_I>();
        
        

        
        
        
    }
}

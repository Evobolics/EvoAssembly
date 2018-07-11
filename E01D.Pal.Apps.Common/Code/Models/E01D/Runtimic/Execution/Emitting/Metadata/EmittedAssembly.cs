using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata
{
    public class EmittedAssembly: EmittedMetadata, EmittedAssembly_I
    {
        

        public string FullName { get; set; }

        

        

        public SemanticAssemblyAssembliesMask_I Assemblies { get; set; }
        public AssemblyDefinition AssemblyDefinition { get; set; }

        public bool IsBuiltOut { get; set; }

        public Dictionary<string, SemanticModuleMask_I> Modules { get; set; } = new Dictionary<string, SemanticModuleMask_I>();
        public Assembly Assembly { get; set; }
    }
}

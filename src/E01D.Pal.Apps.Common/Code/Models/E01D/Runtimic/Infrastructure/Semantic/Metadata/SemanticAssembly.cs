using System.Collections.Generic;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public class SemanticAssembly: SemanticMetadata, SemanticAssembly_I
    {
        public SemanticAssemblyAssembliesMask_I Assemblies { get; set; } = new SemanticAssemblyAssemblies();

        public System.Reflection.Assembly Assembly { get; set; }
        public bool IsBuiltOut { get; set; }

        public AssemblyDefinition AssemblyDefinition { get; set; }

        public string FullName { get; set; }

        public Dictionary<string, SemanticModuleMask_I> Modules { get; set; } = new Dictionary<string, SemanticModuleMask_I>();
    }
}

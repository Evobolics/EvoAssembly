using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedAssembly:ConvertedMetadata, ConvertedAssembly_I, ConvertedMetadataStore_I
    {
	    public ConvertedAssembly()
	    {
				
	    }

        public SemanticAssemblyAssembliesMask_I Assemblies { get; set; } = new SemanticAssemblyAssemblies();

        public Assembly Assembly { get; set; }

        public AssemblyBuilder AssemblyBuilder { get; set; }

        public AssemblyDefinition AssemblyDefinition { get; set; }

        public Dictionary<string, AssemblyDefinition> AssociatedAssemblyDefinitions { get; set; } = new Dictionary<string, AssemblyDefinition>();

        public string FullName { get; set; }

        public bool IsBuiltOut { get; set; }

        public Dictionary<string, SemanticModuleMask_I> Modules { get; set; } = new Dictionary<string, SemanticModuleMask_I>();

        public Dictionary<string, AssemblyDefinition> ReferencedAssemblyDefinitions { get; set; } = new Dictionary<string, AssemblyDefinition>();

        public string ResolutionName { get; set; }

        public AssemblyEntryTypes Types { get; set; } = new AssemblyEntryTypes();

    }
}

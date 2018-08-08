using System.Collections.Generic;
using System.Reflection;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface SemanticAssembly_I: SemanticAssemblyMask_I
    {
        new SemanticAssemblyAssembliesMask_I Assemblies { get; set; }

        Assembly Assembly { get; set; }

        AssemblyDefinition AssemblyDefinition { get; set; }

        new bool IsBuiltOut { get; set; }

        new Dictionary<string, SemanticModuleMask_I> Modules { get; set; }
    }
}

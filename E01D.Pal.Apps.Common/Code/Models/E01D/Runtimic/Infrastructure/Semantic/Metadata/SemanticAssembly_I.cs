using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface SemanticAssembly_I: SemanticAssemblyMask_I
    {
        new SemanticAssemblyAssembliesMask_I Assemblies { get; set; }

        new Assembly Assembly { get; set; }

        new AssemblyDefinition AssemblyDefinition { get; set; }

        new bool IsBuiltOut { get; set; }

        new Dictionary<string, SemanticModuleMask_I> Modules { get; set; }
    }
}

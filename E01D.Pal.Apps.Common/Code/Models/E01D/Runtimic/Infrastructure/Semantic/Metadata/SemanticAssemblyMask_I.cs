using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface SemanticAssemblyMask_I: Assembly_I, SemanticMetadataStoreMask_I
    {
        SemanticAssemblyAssembliesMask_I Assemblies { get; }

        AssemblyDefinition AssemblyDefinition { get; }

        Dictionary<string, SemanticModuleMask_I> Modules { get; }

        System.Reflection.Assembly Assembly { get; set; }
        
    }
}

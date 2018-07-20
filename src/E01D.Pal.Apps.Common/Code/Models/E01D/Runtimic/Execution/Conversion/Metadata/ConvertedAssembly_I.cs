using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public interface ConvertedAssembly_I:ConvertedMetadata_I, EmittedAssemblyMask_I, BoundAssemblyMask_I, ConvertedMetadataStore_I
    {
        AssemblyBuilder AssemblyBuilder { get; set; }

        Dictionary<string, AssemblyDefinition> AssociatedAssemblyDefinitions { get; set; }

        
    }


}

using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedTypeDefinition_I: ConvertedTypeDefinitionMask_I, BoundTypeWithBaseType_I
    {
        new TypeReference SourceTypeReference { get; set; }

        new TypeBuilder TypeBuilder { get; set; }
        new System.Type UnderlyingType { get; set; }

        /// <summary>
        /// Gets or sets whether the type has been built.  It has been built if a type builder has been assigned.
        /// </summary>
        new bool IsBuilt { get; set; }

        new bool IsBaked { get; set; }

        
    }
}

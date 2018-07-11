using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedTypeDefinitionMask_I: ConvertedClassTypeDefinitionClassifier_I, ConvertedTypeMask_I, BoundTypeDefinitionMask_I
    {
        TypeBuilder TypeBuilder { get; }

        /// <summary>
        /// Gets or sets whether the type has been built.  It has been built if a type builder has been assigned.
        /// </summary>
        bool IsBuilt { get; }

        bool IsBaked { get; }


        
    }
}

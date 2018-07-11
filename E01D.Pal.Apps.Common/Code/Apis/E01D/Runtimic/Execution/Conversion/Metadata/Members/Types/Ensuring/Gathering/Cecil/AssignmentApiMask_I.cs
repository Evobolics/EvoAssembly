using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Typal.Ensuring.Cecil
{
    public interface AssignmentApiMask_I
    {
        void AssignGatheredTypes(ConvertedTypeDefinitionMask_I target, SemanticTypeMask_I baseType,
            List<SemanticTypeMask_I> interfaces, List<SemanticTypeMask_I> nestedTypes,
            SemanticTypeMask_I genericBlueprint, SemanticTypeMask_I[] typeArguments,
            SemanticTypeParameterMask_I[] typeParameters);
    }
}

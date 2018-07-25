using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public interface GenericInstanceApiMask_I
    {
        SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, GenericInstanceType input,BoundTypeDefinitionMask_I declaringType);

        
    }
}

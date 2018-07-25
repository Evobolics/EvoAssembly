using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields.Building
{
    public interface GenericApiMask_I
    {
	    void BuildFields(InfrastructureRuntimicModelMask_I semanticModel, BoundGenericTypeDefinition_I converted);

	    void BuildFields_WithGenericTypeParameters(InfrastructureRuntimicModelMask_I semanticModel, BoundGenericTypeDefinition_I input, BoundGenericTypeDefinitionMask_I blueprint);



    }
}

using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Fields.Building
{
    public interface GenericApiMask_I
    {
	    void BuildFields(InfrastructureModelMask_I semanticModel, BoundTypeDefinition converted);

	    void BuildFields_WithGenericTypeParameters(InfrastructureModelMask_I semanticModel, BoundTypeDefinition input, BoundGenericTypeDefinition_I blueprint);



    }
}

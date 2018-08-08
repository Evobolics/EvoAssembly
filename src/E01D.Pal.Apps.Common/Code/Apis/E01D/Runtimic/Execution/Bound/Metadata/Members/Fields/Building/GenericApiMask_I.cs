using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields.Building
{
    public interface GenericApiMask_I
    {
	    void BuildFields(RuntimicSystemModel semanticModel, BoundGenericTypeDefinition_I converted);

	    void BuildFields_WithGenericTypeParameters(RuntimicSystemModel semanticModel, BoundGenericTypeDefinition_I input, BoundGenericTypeDefinitionMask_I blueprint);



    }
}

using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public interface BuildingApiMask_I
    {
		void BuildMethods(InfrastructureRuntimicModelMask_I model, BoundTypeDefinition_I input);

	    BoundMethod BuildMethod(InfrastructureRuntimicModelMask_I model, BoundTypeDefinition_I input, MethodInfo method);


	}
}

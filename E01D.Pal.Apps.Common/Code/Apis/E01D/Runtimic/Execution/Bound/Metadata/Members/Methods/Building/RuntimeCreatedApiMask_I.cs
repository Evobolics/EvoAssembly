using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods.Building
{
	public interface RuntimeCreatedApiMask_I
	{
		void BuildMethods(InfrastructureModelMask_I model, BoundTypeDefinition_I input);

		BoundMethod BuildMethod(InfrastructureModelMask_I model, BoundTypeDefinition_I input, MethodInfo method);
	}
}

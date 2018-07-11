using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors.Building
{
	public interface RuntimeCreatedApiMask_I
	{
		

		
		void BuildConstructors(InfrastructureModelMask_I semanticModel, BoundTypeDefinition_I bound);
	}
}

using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface GettingApiMask_I
	{
		TypeDefinition GetDefinition(InfrastructureModelMask_I model, TypeReference typeReference);
	}
}

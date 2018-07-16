using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface ExternalApiMask_I
	{
		TypeReference Resolve(StructuralRuntimicModelMask_I model, TypeReference externalReference);
	}
}

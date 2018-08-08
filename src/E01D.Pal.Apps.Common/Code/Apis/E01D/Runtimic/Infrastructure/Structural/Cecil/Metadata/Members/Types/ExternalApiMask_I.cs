using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface ExternalApiMask_I
	{
		TypeReference Resolve(RuntimicSystemModel model, TypeReference externalReference);
	}
}

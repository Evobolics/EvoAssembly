using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
	public interface ExternalApiMask_I
	{
		/// <summary>
		/// Used to resolve a external type reference to a type reference that comes from an actual module definition.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="elementType"></param>
		/// <returns></returns>
		TypeReference Resolve(InfrastructureModelMask_I model, TypeReference elementType);
	}
}

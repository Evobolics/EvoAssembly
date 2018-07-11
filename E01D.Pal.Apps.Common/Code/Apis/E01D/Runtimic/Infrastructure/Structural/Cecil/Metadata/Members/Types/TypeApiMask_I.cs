using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface TypeApiMask_I
	{
		EnsuringApiMask_I Ensuring { get; }

		GettingApiMask_I Getting { get; }

		NamingApiMask_I Naming { get; }

		System.Reflection.TypeAttributes GetTypeAttributes(TypeDefinition typeDefinition);

		

		bool IsExternal(TypeReference typeReference);

		void Load(InfrastructureModelMask_I semanticModel, ModuleDefinition moduleDefinition);
	}
}

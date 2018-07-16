using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface TypeApiMask_I
	{
		AddingApiMask_I Adding { get; }

		EnsuringApiMask_I Ensuring { get; }

		ExtendingApiMask_I Extending { get; }

		ExternalApiMask_I External { get; }

		GettingApiMask_I Getting { get; }

		LoadingApiMask_I Loading { get; }

		NamingApiMask_I Naming { get; }

		System.Reflection.TypeAttributes GetTypeAttributes(TypeDefinition typeDefinition);

		bool IsClass(StructuralRuntimicModelMask_I model, TypeReference constraint);

		bool IsExternal(TypeReference typeReference);


		
	}
}

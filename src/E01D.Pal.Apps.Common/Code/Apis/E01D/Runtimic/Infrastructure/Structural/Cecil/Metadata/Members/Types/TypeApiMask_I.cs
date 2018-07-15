using Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface TypeApiMask_I
	{
		AddingApiMask_I Adding { get; }

		EnsuringApiMask_I Ensuring { get; }

		ExtendingApiMask_I Extending { get; }

		GettingApiMask_I Getting { get; }

		LoadingApiMask_I Loading { get; }

		NamingApiMask_I Naming { get; }

		System.Reflection.TypeAttributes GetTypeAttributes(TypeDefinition typeDefinition);

		

		bool IsExternal(TypeReference typeReference);

		
	}
}

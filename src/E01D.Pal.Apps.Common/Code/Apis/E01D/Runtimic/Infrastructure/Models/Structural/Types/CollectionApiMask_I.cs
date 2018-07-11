using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
	public interface CollectionApiMask_I
	{
		void Add(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module,
			TypeDefinition type);

		TypeReference GetStoredTypeReference(InfrastructureModelMask_I model, TypeReference typeReference);

		TypeReference GetStoredTypeReference(InfrastructureModelMask_I model, System.Type genericTypeDefinitionType);

		TypeReference GetStoredTypeReference(InfrastructureModelMask_I model, string fullName);

		TypeReference GetStoredTypeReference(InfrastructureModelMask_I model, string fullName, out SemanticTypeDefinitionMask_I semanticType);
	}
}

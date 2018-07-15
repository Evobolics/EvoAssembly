using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface GettingApiMask_I
	{
		TypeDefinition GetDefinition(InfrastructureRuntimicModelMask_I model, TypeReference typeReference);
		TypeDefinition[] GetAllToArray(AssemblyDefinition[] inputAssemblyDefinitionsToConvert);

		

		TypeReference GetInternalTypeReference(InfrastructureRuntimicModelMask_I model, TypeReference typeReference);

		TypeReference GetExternalTypeReference(InfrastructureRuntimicModelMask_I model, TypeReference externalReference);

		TypeReference GetInternalTypeReference(InfrastructureRuntimicModelMask_I model, Type input);

		TypeReference GetStoredTypeReference(InfrastructureRuntimicModelMask_I model, TypeReference typeReference);

		TypeReference GetStoredTypeReference(InfrastructureRuntimicModelMask_I model, System.Type genericTypeDefinitionType);

		TypeReference GetStoredTypeReference(InfrastructureRuntimicModelMask_I model, string fullName);

		TypeReference GetStoredTypeReference(InfrastructureRuntimicModelMask_I model, string fullName, out UnifiedTypeNode basicNode);

		
	}
}

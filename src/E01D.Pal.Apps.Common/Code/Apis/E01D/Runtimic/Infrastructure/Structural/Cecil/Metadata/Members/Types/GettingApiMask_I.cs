using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface GettingApiMask_I
	{
		TypeDefinition GetDefinition(StructuralRuntimicModelMask_I model, TypeReference typeReference);
		TypeDefinition[] GetAllToArray(AssemblyDefinition[] inputAssemblyDefinitionsToConvert);

		

		TypeReference GetInternalTypeReference(StructuralRuntimicModelMask_I model, TypeReference typeReference);

		

		TypeReference GetInternalTypeReference(StructuralRuntimicModelMask_I model, Type input);

		TypeReference GetStoredTypeReference(StructuralRuntimicModelMask_I model, TypeReference typeReference);

		TypeReference GetStoredTypeReference(StructuralRuntimicModelMask_I model, System.Type genericTypeDefinitionType);

		TypeReference GetStoredTypeReference(StructuralRuntimicModelMask_I model, string fullName);

		TypeReference GetStoredTypeReference(StructuralRuntimicModelMask_I model, string fullName, out UnifiedTypeNode basicNode);

		
	}
}

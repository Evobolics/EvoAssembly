using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface GettingApiMask_I
	{
		TypeDefinition GetDefinition(RuntimicSystemModel model, TypeReference typeReference);
		

		

		

		

		TypeReference GetInternalTypeReference(RuntimicSystemModel model, Type input);

		TypeReference GetStoredTypeReference(RuntimicSystemModel model, TypeReference typeReference);

		TypeReference GetStoredTypeReference(RuntimicSystemModel model, System.Type genericTypeDefinitionType);

		TypeReference GetStoredTypeReference(RuntimicSystemModel model, string fullName);

		

		
		
	}
}

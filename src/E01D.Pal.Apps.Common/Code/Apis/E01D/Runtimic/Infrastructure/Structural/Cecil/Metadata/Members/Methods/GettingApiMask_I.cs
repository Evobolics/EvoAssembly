using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting
{
	public interface GettingApiMask_I
	{
		

		Collection<MethodDefinition> GetDefinitions(TypeReference inputSourceTypeReference);

		MethodDefinition GetMethodDefinition(InfrastructureRuntimicModelMask_I model, Collection<MethodDefinition> methodDefinitions, int metadataToken);

		MethodReference GetMethodReference(InfrastructureRuntimicModelMask_I model, Collection<MethodDefinition> methods,
			Type memberDeclaringType, int methodMetadataToken);
	}
}

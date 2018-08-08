using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public interface GettingApiMask_I
	{
		

		Collection<MethodDefinition> GetDefinitions(TypeReference inputSourceTypeReference);

		MethodDefinition GetMethodDefinition(RuntimicSystemModel model, Collection<MethodDefinition> methodDefinitions, int metadataToken);

		MethodReference GetMethodReference(RuntimicSystemModel model, Collection<MethodDefinition> methods,Type memberDeclaringType, int methodMetadataToken);
	}
}

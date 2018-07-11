using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building
{
	public interface MethodDefinitionApiMask_I
	{
		MethodDefinition MakeGenericInstanceTypeMethodReference(InfrastructureModelMask_I model,
			GenericInstanceType declaringType, MethodDefinition methodDefinition);

		MethodDefinition MakeGenericInstanceTypeMethodReference(InfrastructureModelMask_I model, MethodDefinition methodDefinition, Type memberDeclaringType);
	}

}

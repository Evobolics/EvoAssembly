using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building
{
	public interface MethodDefinitionApiMask_I
	{
		MethodDefinition MakeGenericInstanceTypeMethodReference(InfrastructureRuntimicModelMask_I model,
			GenericInstanceType declaringType, MethodDefinition methodDefinition);

		MethodDefinition MakeGenericInstanceTypeMethodReference(InfrastructureRuntimicModelMask_I model, MethodDefinition methodDefinition, Type memberDeclaringType, Type[] typeArguments);
	}

}

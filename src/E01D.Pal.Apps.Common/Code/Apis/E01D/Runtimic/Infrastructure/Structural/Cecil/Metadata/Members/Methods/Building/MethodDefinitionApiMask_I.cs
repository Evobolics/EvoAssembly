using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building
{
	public interface MethodDefinitionApiMask_I
	{
		MethodDefinition MakeGenericInstanceTypeMethodReference(RuntimicSystemModel model,
			GenericInstanceType declaringType, MethodDefinition methodDefinition);

		MethodDefinition MakeGenericInstanceTypeMethodReference(RuntimicSystemModel model, MethodDefinition methodDefinition, Type memberDeclaringType, Type[] typeArguments);
	}

}

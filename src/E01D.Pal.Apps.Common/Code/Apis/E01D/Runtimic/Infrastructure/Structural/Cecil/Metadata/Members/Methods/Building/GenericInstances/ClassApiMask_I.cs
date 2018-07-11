using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances
{
	public interface ClassApiMask_I
	{
		MethodReference MakeGenericInstanceMethod(InfrastructureModelMask_I model, TypeReference typeReference, TypeDefinition typeDefinition, MethodReference methodReference, MethodInfo method);
	}
}

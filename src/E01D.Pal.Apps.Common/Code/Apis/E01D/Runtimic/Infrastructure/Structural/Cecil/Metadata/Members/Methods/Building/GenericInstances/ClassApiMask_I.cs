using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances
{
	public interface ClassApiMask_I
	{
		MethodReference MakeGenericInstanceMethod(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, TypeDefinition typeDefinition, MethodReference methodReference, MethodInfo method);
	}
}

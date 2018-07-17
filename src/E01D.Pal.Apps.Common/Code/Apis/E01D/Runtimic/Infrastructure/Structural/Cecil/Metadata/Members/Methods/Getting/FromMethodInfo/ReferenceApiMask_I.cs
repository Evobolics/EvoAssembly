using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public interface ReferenceApiMask_I
	{
		MethodReference GetMethodReference(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, MethodInfo method);

		MethodReference GetMethodReference(InfrastructureRuntimicModelMask_I model, TypeDefinition typeDefinition, MethodInfo method);

		MethodReference GetMethodReference(InfrastructureRuntimicModelMask_I model,
			Mono.Collections.Generic.Collection<MethodDefinition> methods, MethodInfo method);
	}
}

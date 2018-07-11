using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo
{
	public interface ReferenceApiMask_I
	{
		MethodReference GetMethodReference(InfrastructureModelMask_I model, TypeReference typeReference, ConstructorInfo method);
	}
}

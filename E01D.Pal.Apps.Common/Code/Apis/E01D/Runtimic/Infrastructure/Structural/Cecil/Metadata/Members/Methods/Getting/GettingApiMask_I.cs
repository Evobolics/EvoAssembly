using Mono.Cecil;
using Mono.Collections.Generic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting.FromMethodInfo;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting
{
	public interface GettingApiMask_I
	{
		FromMethodInfoApiMask_I FromMethodInfos { get; }

		Collection<MethodDefinition> GetDefinitions(TypeReference inputSourceTypeReference);
	}
}

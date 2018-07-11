using Mono.Cecil;
using Mono.Collections.Generic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting
{
	public interface GettingApiMask_I
	{
		FromConstructorInfoApiMask_I FromConstructorInfos { get; }

		Collection<MethodDefinition> GetDefinitions(TypeReference inputSourceTypeReference);
	}
}

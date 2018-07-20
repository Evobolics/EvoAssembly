using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting
{
	public interface GettingApiMask_I
	{
		FromConstructorInfoApiMask_I FromConstructorInfos { get; }

		Collection<MethodDefinition> GetDefinitions(TypeReference inputSourceTypeReference);
	}
}

using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Getting
{
    public class GettingApi<TContainer> : ConversionApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    

	    public SemanticConstructorMask_I GetConstructor(ILConversion conversion, ConvertedConstructorCallInformation callInformation)
	    {
		    return GetConstructor(conversion, callInformation.DeclaringTypeWithConstructors, callInformation.MethodReference);
	    }

	    public SemanticConstructorMask_I GetConstructor(ILConversion conversion, BoundTypeDefinitionWithConstructorsMask_I declaringType, MethodReference methodReference)
	    {
		    var constructors = declaringType.Constructors;

			// If there is  just a single constructor, return it.
			if (constructors.All.Count == 1) return constructors.All[0];

		    for (int i = 0; i < constructors.All.Count; i++)
		    {
			    var constructor = constructors.All[i];

			    if (!Routines.Finding.ParameterMatching.VerifyParameters(conversion, constructor.MethodReference, methodReference)) continue;

			    return constructor;
		    }

		    return null;
		}
	}
}

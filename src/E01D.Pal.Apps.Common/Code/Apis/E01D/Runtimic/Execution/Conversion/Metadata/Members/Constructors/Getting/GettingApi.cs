using System;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Getting
{
    public class GettingApi<TContainer> : ConversionApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    

	    

	    

	    public bool GetConstructor(ILConversion conversion, ConvertedTypeDefinition_I callingType, MethodReference methodReference, out MemberInfo memberInfo)
	    {
		    memberInfo = null;

			// how does the member reference declaring type be resolved?
			var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, methodReference.DeclaringType);

			if (declaringBound.SourceTypeReference.IsArray)
		    {
			    memberInfo = Methods.Building.MakeArrayMethod(conversion, callingType, declaringBound, methodReference);

			    return true;
		    }

		    if (!declaringBound.IsConverted())
		    {
				// NOTE - This call can only be used when accessing types that fully built.  
			    memberInfo = Binding.Metadata.Members.Constructors.FindConstructorBySignature(conversion.Model,declaringBound, methodReference);
		    }
		    else
		    {
			    // This method HAS to be used for accessing constructors of types that are not fullying built.
			    var withConstructors = (ConvertedTypeDefinitionWithConstructors_I)declaringBound;

			    var semanticConstructor = GetConstructor(conversion, withConstructors, methodReference);

			    if (semanticConstructor == null) return false;

			    if (!(semanticConstructor is BoundConstructorDefinitionMask_I boundConstructor))
			    {
				    throw new Exception("Semantic constructor is not a bound constructor.  Cannot return a constructor info from a non-executive type.");
			    }

			    memberInfo = boundConstructor.UnderlyingConstructor;
		    }
		   
		    return memberInfo != null;
	    }

	    

	    

	    public SemanticConstructorMask_I GetConstructor(ILConversion conversion, BoundTypeDefinitionWithConstructorsMask_I declaringType, MethodReference methodSignature)
	    {
		    //var sig = (IMethodSignature) methodReference;

		    var constructors = declaringType.Constructors;

		    // If there is  just a single constructor, return it.
		    if (constructors.All.Count == 1) return constructors.All[0];

		    for (int i = 0; i < constructors.All.Count; i++)
		    {
			    var constructor = constructors.All[i];

			    // TODO: Eventually change to match up RIDs or something like that instead.
			    // Member References should be matched up front right after all modules and assemblies are loaded, so they do not have to be rematched later.
			    if (!Routines.Finding.ParameterMatching.VerifyParameters(conversion, constructor.MethodReference, methodSignature)) continue;

			    return constructor;
		    }

		    return null;
	    }
	}
}

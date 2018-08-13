using System;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors
{
    public class GettingApi<TContainer> : ConversionApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    

	    

	    

	    public bool GetConstructor(ILConversion conversion, ConvertedTypeDefinitionMask_I callingType, BoundTypeDefinitionMask_I declaringBound, MethodReference methodReference, out MemberInfo memberInfo)
	    {
		    memberInfo = null;

			

		    if (!declaringBound.IsConverted())
		    {
				// NOTE - This call can only be used when accessing types that fully built.  
			    memberInfo = Bound.Metadata.Members.Constructors.FindConstructorBySignature(conversion.RuntimicSystem,declaringBound, methodReference);
		    }
		    else
		    {
			    if (declaringBound.SourceTypeReference.IsArray)
			    {
				    memberInfo = Methods.Building.MakeArrayMethod(conversion, callingType, declaringBound, methodReference);

				    return true;
			    }

				// This method HAS to be used for accessing constructors of types that are not fullying built.
				var withConstructors = (BoundTypeDefinitionWithConstructorsMask_I)declaringBound;

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
		    // I actually would want to match a mmberRef to a method siganture, but the problem is that the member ref accesse outside the 
			// assembly. So you are left having to do parameter matching. 
		    var constructors = declaringType.Constructors;

		    //if (constructors.All.Count > 0)
		    //{

			    // If there is  just a single constructor, return it.
			    if (constructors.All.Count == 1) return constructors.All[0];

			    for (int i = 0; i < constructors.All.Count; i++)
			    {
				    var constructor = constructors.All[i];

				    // TODO: Eventually change to match up RIDs or something like that instead.
				    // Member References should be matched up front right after all modules and assemblies are loaded, so they do not have to be rematched later.
				    if (!Routines.Finding.ParameterMatching.VerifyParameters(conversion, constructor.MethodReference,
					    methodSignature)) continue;

				    if (constructor.IsStaticConstructor) continue;

				    return constructor;
			    }

			    return null;
		    //}
		  //  else
		  //  {
				//var constructors1 = declaringType.UnderlyingType.GetConstructors(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

			 //   foreach (var constructor in constructors1)
			 //   {
				//    var x =constructor.MetadataToken;

			 //   }

			 //   throw new System.NotImplementedException();
		  //  }
	    }
	}
}

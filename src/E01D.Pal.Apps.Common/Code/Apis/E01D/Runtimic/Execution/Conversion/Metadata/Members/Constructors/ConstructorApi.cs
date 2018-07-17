using System;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Getting;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors
{
    public class ConstructorApi<TContainer> : ConversionApiNode<TContainer>, ConstructorApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I ConstructorApiMask_I.Building => Building;

	    public GettingApi_I<TContainer> Getting { get; set; }

	    GettingApiMask_I ConstructorApiMask_I.Getting => Getting;



		public MemberInfo GetConstructor(ILConversion conversion, ConvertedTypeDefinition_I callingType, MemberReference memberReference)
        {
            // how does the member reference declaring type be resolved?
            var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, memberReference.DeclaringType);

	        if (declaringBound.SourceTypeReference.IsArray)
	        {
		        return Methods.Building.MakeArrayMethod(conversion, callingType, declaringBound, (MethodReference)memberReference);   
	        }

			// Check to see if the declaring type of the constructor is the same as the base type for the calling type.
			// If so, it means the calling type is calling a base constructor.
			var callingBaseConstructor = ReferenceEquals(callingType.BaseType, declaringBound);

            var hasTypeArgumentsThatAreTypeParameters = DetermineIfDeclaringTypeHasTypeArgumentsThatAreGenericTypeTypeParameters(conversion, declaringBound);

            

            switch (memberReference.MetadataToken.TokenType)
            {
                case TokenType.Method:
                case TokenType.MemberRef:
                {
                    var callInformation = new ConvertedConstructorCallInformation()
                    {
                        CallingBaseConstructor = callingBaseConstructor,
                        CallingType = callingType,
                        DeclaringType = declaringBound,
                        MethodReference = (MethodReference) memberReference,
                        DeclaringTypeHasTypeArgumentsThatAreTypeParameters = hasTypeArgumentsThatAreTypeParameters
                    };

                    return GetConstructor(conversion, callInformation);

                }
                case TokenType.MethodSpec:
                {
                    throw new System.Exception("Not handled");
                }
                default:
                {
                    throw new System.Exception("Not handled");
                }
            }
        }

        private bool DetermineIfDeclaringTypeHasTypeArgumentsThatAreGenericTypeTypeParameters(ILConversion conversion, BoundTypeDefinitionMask_I declaringBound)
        {
            if (!(declaringBound is SemanticGenericTypeDefinitionMask_I generic)) return false;

            for (int i = 0; i < generic.TypeArguments.All.Count; i++)
            {
                var typeArgument = generic.TypeArguments.All[i];

                if (typeArgument.IsTypeParameter())
                {
                    return true;
                }
            }

            return false;
        }

        public ConstructorInfo GetConstructor(ILConversion conversion, ConvertedConstructorCallInformation callInformation)
        {
	        

			if (callInformation.DeclaringType.IsConverted())//(callInformation.DeclaringTypeHasTypeArgumentsThatAreTypeParameters) // callInformation.CallingBaseConstructor && 
			{
				// This method HAS to be used for accessing constructors of types that are not fullying built.

				callInformation.DeclaringTypeWithConstructors =(BoundTypeDefinitionWithConstructorsMask_I) callInformation.DeclaringType;

				SemanticConstructorMask_I constructor = Constructors.Getting.GetConstructor(conversion, callInformation);

				return GetConstructorInfo(constructor);

			}

            // NOTE - This call can only be used when accessing types that fully built.  
            return Binding.Metadata.Members.Constructors.FindConstructorBySignature(conversion.Model, callInformation.DeclaringType, callInformation.MethodReference);
        }

	    private static ConstructorInfo GetConstructorInfo(SemanticConstructorMask_I semanticConstructor)
	    {
		    if (!(semanticConstructor is BoundConstructorDefinitionMask_I boundConstructor))
		    {
			    throw new Exception(
				    "Semantic constructor is not a bound constructor.  Cannot return a constructor info from a non-executive type.");
		    }

		    return boundConstructor.UnderlyingConstructor;
	    }

		//private ConstructorInfo FindConstructorBuilderBySignature(ILConversion conversion, ConvertedConstructorCallInformation callInformation)
		//{
		//    //if (callInformation.DeclaringType is ConvertedGenericTypeDefinition_I generic)
		//    //{
		//    //    if (!(generic.Blueprint is ConvertedTypeDefinitionWithConstructors_I declaringTypeWithConstructors))
		//    //    {
		//    //        throw new Exception("Expected the declaring type generic blueprint to contain at least one constructor.  Cannot return a ConstructorInfo from a class that " +
		//    //            "does not support having constructors.");
		//    //    }

		//    //    callInformation.DeclaringTypeWithConstructors = declaringTypeWithConstructors;


		//    //}


		//}

		//private ConstructorInfo FindConstructorBuilderBySignatureWithConstructors(ILConversion conversion, ConvertedConstructorCallInformation callInformation)
		//{



		//}


	}
}

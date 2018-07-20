using System;
using System.Diagnostics;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public class GenericInstanceApi<TContainer> : ConversionApiNode<TContainer>, GenericApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion,  TypeReference input, SemanticTypeDefinitionMask_I declaringType)
        {
			// DEBUG - trying to get methods copied so I do not have to do the following in the method GetMethodOrThrow:
	        //
	        //    if (convertedTypeWithMethods is BoundGenericTypeDefinitionMask_I generic
	        //    && generic.IsClosedType() && generic.TypeArguments.HasGenericParametersAsTypeArguments
	        //    && object.ReferenceEquals(generic.Blueprint, typeBeingBuilt))
	        //    {
	        //       // Change the type being searched to 
	        //       convertedTypeWithMethods = (BoundTypeDefinitionWithMethodsMask_I)generic.Blueprint;
	        //    }
	        // -----------------------------------
	        if (input.FullName ==
				"Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.GenericClassWithRecursiveMember`1<T>"
			)
	        {

	        }
	        // -----------------------------------

	        var converted = (ConvertedGenericTypeDefinition_I) Types.Creation.Create(conversion, input);

			// Perform Phase 1 Build - Pre Search - Build out all the neccesary information to determine if the instance is already created.
			// NOTE - I do not like that this is done after the creation call immediately above.  The searching should be possible without having to create the type
			//        but it requires changing the build process to possibly pass in type arguments and blueprint, as they would have to be figured out prior to 
			//        to creation.

	        var typeArgumentTypes = Types.Building.GenericInstances.Phase0PreSearch.Build(conversion, converted);

            if (IfAlreadyCreatedReturn(converted.Blueprint, typeArgumentTypes, out SemanticTypeDefinitionMask_I ensure)) return ensure;

			Debug.WriteLine($"Created generic instance type: {converted.SourceTypeReference}");

	        converted.Blueprint.Instances.Add(converted);

	        Types.Building.GenericInstances.Phase1Initial.Build(conversion, converted, typeArgumentTypes);

	        Types.Building.IfPossibleBuildPhase2(conversion, converted);
			

            return converted;
        }

	    

	    

		

	    private bool IfAlreadyCreatedReturn(BoundGenericTypeDefinitionMask_I genericBlueprint, Type[] typeArgumentTypes, out SemanticTypeDefinitionMask_I ensure)
	    {
			for (int i = 0; i < genericBlueprint.Instances.Count; i++)
            {
                var instance = genericBlueprint.Instances[i];

	           

                var currentInstance = (BoundGenericTypeDefinitionMask_I) instance;

                bool found = true;

                for (int j = 0; j < currentInstance.TypeArguments.All.Count; j++)
                {
                    var underlyingType = ((BoundTypeDefinitionMask_I) currentInstance.TypeArguments.All[j]).UnderlyingType;

                    if (!ReferenceEquals(underlyingType, typeArgumentTypes[j]))
                    {
                        found = false;

                        break;
                    }
                }

                if (found)
                {
                    {
                        ensure = currentInstance;
                        return true;
                    }
                }
            }
            ensure = null;
            return false;
        }
    }
}

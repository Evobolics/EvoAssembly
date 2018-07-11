using System.Diagnostics;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public class NonGenericInstanceApi<TContainer> : ConversionApiNode<TContainer>, NonGenericInstanceApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, ConvertedModule_I convertedModule, TypeReference input, ConvertedTypeDefinition_I convertedDeclaringType)
        {
	        if (input.FullName ==
				//"Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.GenericWithGenericMembers`1"
				"Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.BaseClass"
			)
	        {
		        
	        }

		    //  Try to see if the model is already present
		    if (Models.Types.TryGet(conversion.Model, input, out SemanticTypeDefinitionMask_I maskedType))
		    {
			    if (!(maskedType is BoundTypeDefinitionMask_I boundType))
			    {
				    throw new System.Exception(
					    $"The type {input.FullName} was found in the conversion model, but it is not a bound type definition.  " +
					    $"A bound type is required due to the need for a underlying type when creating type builders.");
			    }

			    return boundType;
		    }

	        //---------------------------------
	        // Conversion is going to occur.
	        //---------------------------------

			ConvertedTypeDefinition converted = Types.Creation.Create(conversion, input.Module, convertedModule, input);

            // Add the type instance to the model.  Do not do any recursive calls till this methods is called.
            Types.Addition.Add(conversion, convertedModule, converted);

	        

			Types.Building.NonGenericInstances.Phase1Initial.Build(conversion, converted, convertedDeclaringType);

            Types.Building.IfPossibleBuildPhase2(conversion, converted);

			return converted;
        }
    }
}

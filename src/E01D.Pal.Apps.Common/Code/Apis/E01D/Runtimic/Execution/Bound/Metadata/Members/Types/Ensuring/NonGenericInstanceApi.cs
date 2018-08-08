using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public class NonGenericApi<TContainer> : BoundApiNode<TContainer>, NonGenericApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(RuntimicSystemModel semanticModel, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType)
        {
	        throw new Exception("Fix");

			//   //  Try to see if the model is already present
			//   if (Models.Types.Collection.TryGet(semanticModel, input, out SemanticTypeDefinitionMask_I maskedType))
			//   {
			//    if (!(maskedType is BoundTypeDefinitionMask_I boundType))
			//    {
			//	    throw new System.Exception(
			//		    $"The type {input.FullName} was found in the conversion model, but it is not a bound type definition.  " +
			//		    $"A bound type is required due to the need for a underlying type when creating type builders.");
			//    }

			//    return boundType;
			//   }

			//      if (input.FullName == "System.Collections.Generic.Dictionary`2/ValueCollection/Enumerator")
			//      {
			//      }

			////---------------------------------
			//// Conversion is going to occur.
			////---------------------------------



			//var bound = Types.Creation.Create(semanticModel, input, underlyingType);

			//      // Get the module to ensure that the type is part of the module.
			//      var semanticModule = Modules.Getting.Get(semanticModel, input);

			//      if (!(semanticModule is BoundModuleMask_I boundModule))
			//      {
			//       var result = Semantic.Metadata.Members.Types.Ensuring.Ensure(semanticModel, semanticModule, input);

			//       throw new Exception("Need to fix return type.");
			//      }

			//      bound.Module = boundModule;


			//// Add the type instance to the model.  Do not do any recursive calls till this methods is called.
			//Types.Addition.Add(semanticModel, boundModule, bound);

			//         return Types.Building.NonGenericInstances.Phase1Initial.Build(semanticModel, bound, underlyingType, declaringType);
		}

	    

	    
    }
}

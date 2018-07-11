using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public class NonGenericApi<TContainer> : BindingApiNode<TContainer>, NonGenericApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType)
        {
		    //  Try to see if the model is already present
		    if (Models.Types.Collection.TryGet(semanticModel, input, out SemanticTypeDefinitionMask_I maskedType))
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

	        if (underlyingType?.AssemblyQualifiedName == "<>f__AnonymousType0`1, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
	        {
		        
	        }

			var bound = Types.Creation.Create(semanticModel, input.Module, boundModule, input, underlyingType);

            // Add the type instance to the model.  Do not do any recursive calls till this methods is called.
            Types.Addition.Add(semanticModel, boundModule, bound);

            return Types.Building.NonGenericInstances.Phase1Initial.Build(semanticModel, bound, underlyingType, declaringType);
        }

	    

	    
    }
}

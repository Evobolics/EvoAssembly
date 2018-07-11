using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Ensuring
{
    public class ArrayApi<TContainer> : BindingApiNode<TContainer>, ArrayApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType)
        {
	        ArrayType arrayType = (ArrayType)input;

	        SemanticTypeDefinitionMask_I elementType;


			if (underlyingType == null)
	        {
		        elementType = Types.Ensuring.Ensure(semanticModel, arrayType.ElementType, null);
	        }
	        else
	        {
		        elementType = Types.Ensuring.Ensure(semanticModel, arrayType.ElementType, underlyingType.GetElementType());
	        }

	        if (IfAlreadyCreatedReturn(elementType, arrayType.Rank, out SemanticArrayTypeDefinitionMask_I existing))
	        {
		        return existing;
	        }

			var bound = Types.Creation.Create(semanticModel, input.Module, boundModule, input, null);

	        bound.SourceTypeReference = input;
			
	        var arrayDef = (BoundArrayTypeDefinition_I)bound;

	        elementType.Arrays.Add(arrayType.Rank, arrayDef);

			arrayDef.ElementType = elementType;

	        bound.BaseType = Binding.Metadata.Members.Types.Ensuring.Ensure(semanticModel, typeof(System.Array));

	        if (!arrayDef.ElementType.IsBound())
	        {
		        throw new System.Exception("Expected the element type to be a bound type. Cannot create the undelrying array type without a runtime type.");
	        }

	        var arrayElementType = (BoundTypeDefinitionMask_I)arrayDef.ElementType;

	        var arrayElementUndelryingType = arrayElementType.UnderlyingType;

	        if (arrayType.Rank == 1)
	        {
		        // Makes a vector
		        bound.UnderlyingType = arrayElementUndelryingType.MakeArrayType();
	        }
	        else
	        {
		        // Makes an multi-dimensional array
		        bound.UnderlyingType = arrayElementUndelryingType.MakeArrayType(arrayType.Rank);
	        }

	        return bound;

			
        }

	    private bool IfAlreadyCreatedReturn(SemanticTypeDefinitionMask_I elementType, int rank, out SemanticArrayTypeDefinitionMask_I existing)
	    {
		    if (elementType.Arrays.TryGetValue(rank, out existing))
		    {
			    return true;
		    }

		    return false;
	    }
	}
}

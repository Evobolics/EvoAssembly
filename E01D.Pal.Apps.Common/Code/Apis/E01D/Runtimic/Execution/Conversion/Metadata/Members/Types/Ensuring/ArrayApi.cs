using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public class ArrayApi<TContainer> : ConversionApiNode<TContainer>, ArrayApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, ConvertedModule_I convertedModule, TypeReference input, SemanticTypeDefinitionMask_I declaringType)
        {
	        ArrayType arrayType = (ArrayType)input;

	        var elementType = Types.Ensuring.Ensure(conversion, arrayType.ElementType, null);

	        if (IfAlreadyCreatedReturn(elementType, arrayType.Rank, out SemanticArrayTypeDefinitionMask_I existing))
	        {
		        return existing;
	        }

			ConvertedTypeDefinition converted = Types.Creation.Create(conversion, input.Module, convertedModule, input);

	        var arrayDef = (ConvertedArrayTypeDefinition_I)converted;

			elementType.Arrays.Add(arrayType.Rank, arrayDef);

	        arrayDef.ElementType = elementType;

			converted.BaseType = (BoundTypeDefinitionMask_I)Binding.Metadata.Members.Types.Ensuring.Ensure(conversion.Model, typeof(System.Array));

            if (!(arrayDef.ElementType is BoundTypeDefinitionMask_I boundElementType))
            {
                throw new Exception("The element type is not a BoundTypeDefinitionMask_I. ");
            }

            if (arrayType.Rank == 1)
            {
                // Makes a vector
                converted.UnderlyingType = boundElementType.UnderlyingType.MakeArrayType();
            }
            else
            {
                // Makes an multi-dimensional array
                converted.UnderlyingType = boundElementType.UnderlyingType.MakeArrayType(arrayType.Rank);
            }

	        Routines.Building.BuildRoutines(conversion, converted);



			Types.Building.UpdateBuildPhase(converted, 3);

            return converted;
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

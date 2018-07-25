using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public class ArrayApi<TContainer> : ExecutionApiNode<TContainer>, ArrayApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType)
        {
	        ArrayType arrayType = (ArrayType)input;

	        BoundTypeDefinitionMask_I elementType;

	        if (arrayType.ElementType.FullName == "System.Collections.Generic.Dictionary`2/Entry<TKey,TValue>")
	        {
		        
	        }

	        var node = Unified.Arrays.Get(semanticModel, arrayType, arrayType.Rank);

	        if (node != null)
	        {
		        return node.SemanticType;
	        }

	        

			if (underlyingType == null)
	        {
		        // Possible element type is a generic instance type
				elementType = Execution.Types.Ensuring.EnsureBound(semanticModel, arrayType.ElementType, null);
	        }
	        else
	        {
		        // Possible element type is a generic instance type
				elementType = Execution.Types.Ensuring.EnsureBound(semanticModel, arrayType.ElementType, underlyingType.GetElementType());
	        }

	        ExecutionArrayTypeDefinition_I bound;

			if (elementType.IsConverted())
	        {
				// Converted multi-dimemsinal arrays do have constructors that need to come from a different source
				// than bound multi-dimemsinal arrays
				bound = (ExecutionArrayTypeDefinition_I)Conversion.Metadata.Members.Types.Creation.Create(semanticModel, input);

		        Conversion.Metadata.Members.Types.Building.UpdateBuildPhase((ConvertedTypeDefinition_I)bound, BuildPhaseKind.TypeCreated);
			}
	        else
	        {
		        bound = (ExecutionArrayTypeDefinition_I)Bound.Metadata.Members.Types.Creation.Create(semanticModel, input, null);

		        bound.UnderlyingType = underlyingType;
			}

	        bound.SourceTypeReference = input;
	        bound.BaseType = (BoundTypeDefinitionMask_I)Execution.Types.Ensuring.Ensure(semanticModel, typeof(System.Array));
	        bound.ElementType = elementType;

	        Unified.Arrays.Add(semanticModel, bound, arrayType.Rank);

            if (bound.UnderlyingType == null)
	        {
		        if (arrayType.Rank == 1)
		        {
			        // Makes a vector
			        bound.UnderlyingType = elementType.UnderlyingType.MakeArrayType();
		        }
		        else
		        {
			        // Makes an multi-dimensional array
			        bound.UnderlyingType = elementType.UnderlyingType.MakeArrayType(arrayType.Rank);
		        }
	        }

	        

           

	        

			return bound;

			
        }

	   
	}
}

using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public class ArrayApi<TContainer> : ExecutionApiNode<TContainer>, ArrayApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    

	    public ExecutionTypeNode_I Ensure(ExecutionEnsureContext context)
	    {
			ArrayType arrayType = (ArrayType)context.TypeReference;

		    var arrayStemType = Execution.Types.Ensuring.Ensure(new ExecutionEnsureContext()
		    {
			    Conversion = context.Conversion,
			    RuntimicSystem = context.RuntimicSystem,
			    StructuralInputTypeNode = context.StructuralInputTypeNode.StemType
		    });

		    if (CheckForBranch(arrayStemType, arrayType, out ExecutionTypeNode_I ensure)) return ensure;


		    ExecutionArrayTypeDefinition_I bound;

		    ExecutionTypeNode_I node;


			if (arrayStemType.Type.IsConverted())
		    {
			    // Converted multi-dimemsinal arrays do have constructors that need to come from a different source
			    // than bound multi-dimemsinal arrays
			    bound = (ExecutionArrayTypeDefinition_I)Conversion.Metadata.Members.Types.Creation.Create(context.RuntimicSystem, context.TypeReference);

			    Conversion.Metadata.Members.Types.Building.UpdateBuildPhase((ConvertedTypeDefinition_I)bound, BuildPhaseKind.TypeCreated);

			    node = new ConversionTypeNode()
			    {
				    IsArrayType = true,
				    StemType = (ConversionTypeNode) arrayStemType,
				    IsDerived = true,
				    InputStructuralNode = context.StructuralInputTypeNode,
				    Type = (ConvertedTypeDefinition_I) bound,
				    Rank = arrayType.Rank
				};

		    }
		    else
		    {
			    bound = (ExecutionArrayTypeDefinition_I)Bound.Metadata.Members.Types.Creation.Create(context.RuntimicSystem, context.TypeReference, null);

				bound.UnderlyingType = context.UnderlyingType;

			    node = new BoundTypeNode()
			    {
				    IsArrayType = true,
				    StemType = (BoundTypeNode)arrayStemType,
				    IsDerived = true,
				    InputStructuralNode = context.StructuralInputTypeNode,
				    Type = (BoundTypeDefinition)bound,
					Rank= arrayType.Rank
				};
			}

		    bound.SourceTypeReference = context.TypeReference;
//		    bound.BaseType = (BoundTypeDefinitionMask_I)Execution.Types.Ensuring.Ensure(semanticModel, typeof(System.Array));
		    bound.ElementType = arrayStemType.Type;

		    if (bound.UnderlyingType == null)
		    {
			    var elementType = arrayStemType.Type;


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

			SetNode(arrayStemType, node);

		    return node;
	    }

	    private void SetNode(ExecutionTypeNode_I arrayStemType, ExecutionTypeNode_I node)
	    {
		    if (arrayStemType.Arrays == null)

		    {
			    arrayStemType.Arrays = new ExecutionTypeNode_I[5];
		    }

		    var foundSlot = false;
		    int currentIndex = 0;

		    for (; currentIndex < arrayStemType.Arrays.Length; currentIndex++)
		    {
			    var arrayNode = arrayStemType.Arrays[currentIndex];

			    if (arrayNode == null)
			    {
				    foundSlot = true;
				    break;
			    }
		    }

		    if (!foundSlot)
		    {
			    var tempArrays = new ExecutionTypeNode_I[arrayStemType.Arrays.Length + 5];

			    Array.Copy(arrayStemType.Arrays, 0, tempArrays, 0, arrayStemType.Arrays.Length);

			    arrayStemType.Arrays = tempArrays;
		    }

		    arrayStemType.Arrays[currentIndex] = node;
	    }

	    private bool CheckForBranch(ExecutionTypeNode_I arrayStemType, ArrayType arrayType, out ExecutionTypeNode_I ensure)
	    {
		    if (arrayStemType.Arrays != null && arrayStemType.Arrays.Length > 0)
		    {
			    for (int i = 0; i < arrayStemType.Arrays.Length; i++)
			    {
				    var arrayNode = arrayStemType.Arrays[i];

				    if (arrayNode?.Rank == arrayType.Rank)
				    {
					    ensure = (ExecutionTypeNode_I) arrayNode;
					    return true;
				    }
			    }
		    }
		    ensure = null;

			return false;
	    }
    }
}

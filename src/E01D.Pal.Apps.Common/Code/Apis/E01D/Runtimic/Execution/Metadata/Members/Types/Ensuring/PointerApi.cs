using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
	public class PointerApi<TContainer> : ExecutionApiNode<TContainer>, PointerApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		
			

		public ExecutionTypeNode_I Ensure(ExecutionEnsureContext context)
		{
			var pointerStemType = Execution.Types.Ensuring.Ensure(new ExecutionEnsureContext()
			{
				Conversion = context.Conversion,
				RuntimicSystem = context.RuntimicSystem,
				StructuralInputTypeNode = context.StructuralInputTypeNode.StemType
			});

			if (pointerStemType.PointerType != null)
			{
				return pointerStemType.PointerType;
			}

			var boundTypeDefinition = new BoundPointerTypeDefinition()
			{
				UnderlyingType = pointerStemType.Type.UnderlyingType.MakePointerType()
			};

			pointerStemType.PointerType = new BoundTypeNode()
			{
				IsPointerType = true,
				StemType = pointerStemType,
				IsDerived = true,
				MetadataToken = context.StructuralInputTypeNode.MetadataToken,
				InputStructuralNode = context.StructuralInputTypeNode,
				Type = boundTypeDefinition
			};

			return pointerStemType.PointerType;
		}
	}
}

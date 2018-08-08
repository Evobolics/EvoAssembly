using System;
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
	public class ByReferenceApi<TContainer> : ExecutionApiNode<TContainer>, ByReferenceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		public ExecutionTypeNode_I Ensure(ExecutionEnsureContext context)
		{
			var byRefStemType = Execution.Types.Ensuring.Ensure(new ExecutionEnsureContext()
			{
				Conversion = context.Conversion,
				RuntimicSystem = context.RuntimicSystem,
				StructuralInputTypeNode = context.StructuralInputTypeNode.StemType
			});

			if (byRefStemType.ByReferenceType != null)
			{
				return byRefStemType.ByReferenceType;
			}

			var boundTypeDefinition = new BoundPointerTypeDefinition()
			{
				UnderlyingType = byRefStemType.Type.UnderlyingType.MakeByRefType()
			};

			byRefStemType.ByReferenceType = new BoundTypeNode()
			{
				IsByReferenceType = true,
				StemType = byRefStemType,
				IsDerived = true,
				MetadataToken = context.StructuralInputTypeNode.MetadataToken,
				InputStructuralNode = context.StructuralInputTypeNode,
				Type = boundTypeDefinition
			};

			return byRefStemType.ByReferenceType;
		}
	}
}

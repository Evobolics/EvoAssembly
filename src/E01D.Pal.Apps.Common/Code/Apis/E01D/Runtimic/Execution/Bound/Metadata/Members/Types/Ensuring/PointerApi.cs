using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
	public class PointerApi<TContainer> : BindingApiNode<TContainer>, PointerApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public SemanticTypeDefinitionMask_I Ensure(InfrastructureRuntimicModelMask_I semanticModel, BoundModule_I boundModule, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType)
		{
			string resolutionName = Cecil.Types.Naming.GetPointerElementName(input);

			var node = Unified.Types.Get(semanticModel, resolutionName);

			if (node.PointerType != null)
			{
				return node.PointerType;
			}

			var bound = Types.Creation.Create(semanticModel, input.Module, boundModule, input, underlyingType);

			// Add the type instance to the model.  Do not do any recursive calls till this methods is called.
			node.PointerType = bound;


			if (bound.IsNestedType())
			{
				if (declaringType == null)
				{
					throw new Exception("Declaring type is null.  Cannot create a nested type.");
				}

				var nestedType = (BoundTypeDefinitionWithDeclaringType_I)bound;

				nestedType.DeclaringType = declaringType;
			}


			bound.UnderlyingType = underlyingType;

			Members.TypeParameters.Building.EnsureTypeParametersIfAny(semanticModel, bound);

			return bound;
		}
	}
}

using System;
using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeArguments
{
	public class BuildingApi<TContainer> : BoundApiNode<TContainer>, BuildingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public Type[] Build(BoundRuntimicModelMask_I semanticModel, BoundTypeDefinition boundInput, System.Type type)
		{
			if (!boundInput.IsGeneric()) return Type.EmptyTypes;

			GenericInstanceType inputType = (GenericInstanceType)boundInput.SourceTypeReference;

			var list = new List<SemanticTypeDefinitionMask_I>();

			if (inputType.GenericArguments.Count <= 0) return Type.EmptyTypes;

			Type[] types = type.GetGenericArguments();

			bool hasGenericParametersAsTypeArguments = false;

			for (var i = 0; i < inputType.GenericArguments.Count; i++)
			{
				var genericArgument = inputType.GenericArguments[i];

				var semanticType = Execution.Types.Ensuring.Ensure(semanticModel, genericArgument, types[i], null);

				if (!(semanticType is BoundTypeDefinitionMask_I bound))
				{
					throw new System.Exception("Semantic type needs to be a bound type.");
				}

				hasGenericParametersAsTypeArguments |= types[i].IsGenericParameter;

				list.Add(Models.Types.GetBoundTypeOrThrow(semanticType, false));
			}

			var generic = (BoundGenericTypeDefinition_I)boundInput;

			generic.TypeArguments.All = list;
			generic.TypeArguments.HasGenericParametersAsTypeArguments = hasGenericParametersAsTypeArguments;

			return types;
		}
	}
}

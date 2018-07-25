using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeArguments
{
	public class BuildingApi<TContainer> : BoundApiNode<TContainer>, BuildingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public BoundTypeDefinitionMask_I[] Build(BoundRuntimicModelMask_I semanticModel, GenericInstanceType inputType)
		{
			if (inputType.GenericArguments.Count <= 0) return new BoundTypeDefinitionMask_I[0];

			var types = new BoundTypeDefinitionMask_I[inputType.GenericArguments.Count];

			for (var i = 0; i < inputType.GenericArguments.Count; i++)
			{
				var genericArgument = inputType.GenericArguments[i];

				types[i] = Execution.Types.Ensuring.EnsureBound(semanticModel, genericArgument, null);

				if (types[i].SourceTypeReference == null)
					throw new Exception("null type reference");
			}

			return types;
		}

		
	}
}

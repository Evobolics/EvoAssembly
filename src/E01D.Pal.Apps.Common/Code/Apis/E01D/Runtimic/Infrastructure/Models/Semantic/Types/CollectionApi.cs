using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
	public class CollectionApi<TContainer> : BoundApiNode<TContainer>, CollectionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		

		public SemanticTypeMask_I Get(RuntimicSystemModel semanticModel, TypeReference input)
		{
			string resolutionName = Types.Naming.GetResolutionName(input);

			return Get(semanticModel, resolutionName);
		}

		public SemanticTypeDefinitionMask_I Get(RuntimicSystemModel semanticModel, string resolutionName)
		{
			throw new System.NotImplementedException();
			//return Unified.Types.Get(semanticModel, resolutionName)?.SemanticType;
		}

		

		public SemanticTypeMask_I GetOrThrow(RuntimicSystemModel model, TypeDefinition typeDefinition)
		{
			string resolutionName = Types.Naming.GetResolutionName(typeDefinition);

			return GetOrThrow(model, resolutionName);
		}

		public SemanticTypeMask_I GetOrThrow(RuntimicSystemModel semanticModel, string resolutionName)
		{
			var result = Get(semanticModel, resolutionName);

			if (result == null)
			{
				throw new System.Exception($"Could not resolve type '{resolutionName}'");
			}

			return result;
		}

		



		

		

		public bool TryGet(RuntimicSystemModel model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry)
		{
			typeEntry = Get(model, resolutionName);

			return typeEntry != null;
		}

		public bool TryGet(RuntimicSystemModel model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry)
		{
			string resolutionName = Types.Naming.GetResolutionName(input);

			return TryGet(model, resolutionName, out typeEntry);
		}

		
	}
}

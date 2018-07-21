using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public class ArrayApi<TContainer> : UnifiedApiNode<TContainer>, ArrayApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public UnifiedArrayInstanceNode Get(BoundRuntimicModelMask_I model, TypeReference arrayType, int rank)
		{
			var resolutionName = Cecil.Types.Naming.GetResolutionName(arrayType);

			if (!model.Unified.Arrays.TryGetValue(resolutionName, out UnifiedArrayInstanceNodeSet set))
			{
				return null;
			}

			for (int i = 0; i < set.Instances.Count; i++)
			{
				var item = set.Instances[i];

				if (item.Rank != rank) continue;

				return item;
			}

			return null;
		}

		public void Add(BoundRuntimicModelMask_I model, SemanticTypeDefinitionMask_I semantic, int arrayTypeRank)
		{
			var resolutionName = Cecil.Types.Naming.GetResolutionName(semantic.SourceTypeReference);

			if (!model.Unified.Arrays.TryGetValue(resolutionName, out UnifiedArrayInstanceNodeSet set))
			{
				set = new UnifiedArrayInstanceNodeSet();

				model.Unified.Arrays.Add(resolutionName, set);
			}

            set.Instances.Add(new UnifiedArrayInstanceNode()
            {
	            ElementResolutionName = resolutionName,
                Rank = arrayTypeRank,
				SemanticType = semantic
            });
		}
	}
}

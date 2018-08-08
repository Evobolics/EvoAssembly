using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface ArrayApiMask_I
	{
		UnifiedArrayInstanceNode Get(BoundRuntimicModelMask_I model, TypeReference arrayType, int rank);

		void Add(BoundRuntimicModelMask_I model, SemanticTypeDefinitionMask_I semantic, int arrayTypeRank);
	}
}

using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public class GettingApi<TContainer> : BoundApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        

        public SemanticTypeMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, SemanticModuleMask_I module, TypeReference input)
        {
            string resolutionName = Types.Naming.GetResolutionName(input);

            if (!module.Types.ByResolutionName.TryGetValue(resolutionName, out SemanticTypeMask_I typeEntry))
            {
                return null;
            }

            return typeEntry;
        }
    }
}

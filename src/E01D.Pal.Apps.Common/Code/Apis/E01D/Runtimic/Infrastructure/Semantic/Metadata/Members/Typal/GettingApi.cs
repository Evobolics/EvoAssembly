using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
	public class GettingApi<TContainer> : SemanticApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        

        public SemanticTypeMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, SemanticModuleMask_I module, TypeReference input)
        {
            string resolutionName = Infrastructure.Structural.Naming.GetResolutionName(input);

            if (!module.Types.ByResolutionName.TryGetValue(resolutionName, out SemanticTypeMask_I typeEntry))
            {
                return null;
            }

            return typeEntry;
        }
    }
}

using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public class EnsuringApi<TContainer> : SemanticApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticModuleMask_I Ensure(InfrastructureRuntimicModelMask_I semanticModel, TypeReference typeReference)
        {
            throw new System.NotImplementedException();
        }

        public List<SemanticModuleMask_I> EnsureAll(InfrastructureRuntimicModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly)
        {
            throw new System.NotImplementedException();
        }
    }
}

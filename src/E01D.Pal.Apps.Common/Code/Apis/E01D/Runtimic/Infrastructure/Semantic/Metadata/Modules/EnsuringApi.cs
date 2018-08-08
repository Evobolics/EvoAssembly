using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public class EnsuringApi<TContainer> : SemanticApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticModuleMask_I Ensure(RuntimicSystemModel semanticModel, TypeReference typeReference)
        {
            throw new System.NotImplementedException();
        }

        public List<SemanticModuleMask_I> EnsureAll(RuntimicSystemModel semanticModel, SemanticAssemblyMask_I semanticAssembly)
        {
            throw new System.NotImplementedException();
        }
    }
}

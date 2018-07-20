using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public class EnsuringApi<TContainer> : SemanticApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void EnsureTypes(InfrastructureRuntimicModelMask_I semanticModel, SemanticModuleMask_I moduleEntry)
        {
            throw new NotImplementedException();
        }

        public object Ensure(InfrastructureRuntimicModelMask_I semanticModel, SemanticModuleMask_I semanticModule, TypeReference input)
        {
            throw new NotImplementedException();
        }
    }
}

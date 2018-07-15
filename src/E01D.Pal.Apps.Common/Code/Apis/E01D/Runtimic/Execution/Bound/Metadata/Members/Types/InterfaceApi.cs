using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public class InterfaceApi<TContainer> : BindingApiNode<TContainer>, InterfaceApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        

        public BoundTypeDefinitionInterfaces GetInterfaces(InfrastructureRuntimicModelMask_I semanticModel, TypeDefinition typeDefinition)
        {
            BoundTypeDefinitionInterfaces all = new BoundTypeDefinitionInterfaces();

            return all;
        }
    }
}

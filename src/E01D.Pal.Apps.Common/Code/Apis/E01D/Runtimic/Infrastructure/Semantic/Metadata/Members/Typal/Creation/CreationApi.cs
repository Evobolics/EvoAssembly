using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Creation
{
    public class CreationApi<TContainer> : SemanticApiNode<TContainer>,CreationApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

        public new CecilApi<TContainer> Cecil { get; set; }

        public DotNetApi<TContainer> DotNet { get; set; }

        public FactoryApi<TContainer> Factory { get; set; }

        CecilApiMask_I CreationApiMask_I.Cecil => Cecil;

        DotNetApiMask_I CreationApiMask_I.DotNet => DotNet;

        FactoryApiMask_I CreationApiMask_I.Factory => Factory;

        

        
    }
}

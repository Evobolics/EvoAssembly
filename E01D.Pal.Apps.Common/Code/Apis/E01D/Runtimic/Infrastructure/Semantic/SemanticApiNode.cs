using Root.Code.Apis.E01D.Runtimic.Execution.Binding;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic
{
    public class SemanticApiNode<TContainer> : Api<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
      

        public BindingApiMask_I Binding => Container.Api.Runtimic.Execution.Binding;



        

        public ConversionApiMask_I Conversion => Container.Api.Runtimic.Execution.Emitting.Conversion;

        public EmittingApiMask_I Emitting => Container.Api.Runtimic.Execution.Emitting;

        public InfrastructureApiMask_I Infrastructure => Container.Api.Runtimic.Infrastructure;

        

        public RuntimicApiMask_I Runtimic => Container.Api.Runtimic;

        public TypeApiMask_I Types
        {
            get
            {
                return Container.Api.Runtimic.Infrastructure.Semantic.Metadata.Members.Types;
            }
        }
    }
}

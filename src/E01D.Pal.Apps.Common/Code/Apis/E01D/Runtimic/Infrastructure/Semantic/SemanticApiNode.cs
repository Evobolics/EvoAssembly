using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic
{
    public class SemanticApiNode<TContainer> : RuntimeApiNode<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
      

        public BindingApiMask_I Binding => Container.Api.Runtimic.Execution.Bound;



		public CecilApiMask_I Cecil => Container.Api.Runtimic.Infrastructure.Structural.Cecil;

		public ConversionApiMask_I Conversion => Container.Api.Runtimic.Execution.Conversion;

        public EmittingApiMask_I Emitting => Container.Api.Runtimic.Execution.Emitting;

        

        

        

        public TypeApiMask_I Types
        {
            get
            {
                return Container.Api.Runtimic.Infrastructure.Semantic.Metadata.Members.Types;
            }
        }
    }
}

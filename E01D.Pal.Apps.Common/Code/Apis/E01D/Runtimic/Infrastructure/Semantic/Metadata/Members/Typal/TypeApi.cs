using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Creation;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public class TypeApi<TContainer> : SemanticApiNode<TContainer>, TypeApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public AdditionApi_I<TContainer> Addition { get; set; }

        public CreationApi_I<TContainer> Creation { get; set; }
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

	    public GenericInstanceApi_I<TContainer> GenericInstances { get; set; }

		public GettingApi_I<TContainer> Getting { get; set; }

        public InformationApi_I<TContainer> Information { get; set; }

        public NamingApi_I<TContainer> Naming { get; set; }

        AdditionApiMask_I TypeApiMask_I.Addition => Addition;

        CreationApiMask_I TypeApiMask_I.Creation => Creation;

	    GenericInstanceApiMask_I TypeApiMask_I.GenericInstances => GenericInstances;

		GettingApiMask_I TypeApiMask_I.Getting => Getting;

        EnsuringApiMask_I TypeApiMask_I.Ensuring => Ensuring;

        InformationApiMask_I TypeApiMask_I.Information => Information;

        NamingApiMask_I TypeApiMask_I.Naming => Naming;


    }
}

using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public class ModuleApi<TContainer> : BindingApiNode<TContainer>, ModuleApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    [ValueSetDynamically]
	    public AdditionApi_I<TContainer> Addition { get; set; }

        [ValueSetDynamically]
        public BuildingApi_I<TContainer> Building { get; set; }

        [ValueSetDynamically]
		public CreationApi_I<TContainer> Creation { get; set; }

        [ValueSetDynamically]
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

        [ValueSetDynamically]
        public GettingApi_I<TContainer> Getting { get; set; }


        AdditionApiMask_I ModuleApiMask_I.Addition => Addition;

        BuildingApiMask_I ModuleApiMask_I.Building => Building;

        CreationApiMask_I ModuleApiMask_I.Creation => Creation;

        EnsuringApiMask_I ModuleApiMask_I.Ensuring => Ensuring;

        GettingApiMask_I ModuleApiMask_I.Getting => Getting;
    }
}

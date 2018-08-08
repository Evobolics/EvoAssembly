using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public class ModuleApi<TContainer> : BoundApiNode<TContainer>, ModuleApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    
	    public AdditionApi_I<TContainer> Addition { get; set; }

        
        public BuildingApi_I<TContainer> Building { get; set; }

        
		public CreationApi_I<TContainer> Creation { get; set; }

        
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

        
        public GettingApi_I<TContainer> Getting { get; set; }


        AdditionApiMask_I ModuleApiMask_I.Addition => Addition;

        BuildingApiMask_I ModuleApiMask_I.Building => Building;

        CreationApiMask_I ModuleApiMask_I.Creation => Creation;

        EnsuringApiMask_I ModuleApiMask_I.Ensuring => Ensuring;

        GettingApiMask_I ModuleApiMask_I.Getting => Getting;
    }
}

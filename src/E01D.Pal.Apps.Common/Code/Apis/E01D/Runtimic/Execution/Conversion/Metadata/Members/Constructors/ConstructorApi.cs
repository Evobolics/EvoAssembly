using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors
{
    public class ConstructorApi<TContainer> : ConversionApiNode<TContainer>, ConstructorApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I ConstructorApiMask_I.Building => Building;

	    public GettingApi_I<TContainer> Getting { get; set; }

	    GettingApiMask_I ConstructorApiMask_I.Getting => Getting;



		

	    

		


	}
}

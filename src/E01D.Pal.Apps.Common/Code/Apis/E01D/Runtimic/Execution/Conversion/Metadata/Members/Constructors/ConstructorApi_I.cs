using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors
{
    public interface ConstructorApi_I<TContainer>: ConstructorApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new BuildingApi_I<TContainer> Building { get; set; }

	    new GettingApi_I<TContainer> Getting { get; set; }

	}
}

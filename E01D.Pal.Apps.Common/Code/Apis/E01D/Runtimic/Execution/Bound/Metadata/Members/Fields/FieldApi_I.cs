using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Fields
{
    public interface FieldApi_I<TContainer>: FieldApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new Fields.Building.BuildingApi_I<TContainer> Building { get; set; }
	}
}

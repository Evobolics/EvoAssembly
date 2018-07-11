using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeArguments
{
	public interface TypeArgumentApi_I<TContainer> : TypeArgumentApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new BuildingApi_I<TContainer> Building { get; set; }
	}
}

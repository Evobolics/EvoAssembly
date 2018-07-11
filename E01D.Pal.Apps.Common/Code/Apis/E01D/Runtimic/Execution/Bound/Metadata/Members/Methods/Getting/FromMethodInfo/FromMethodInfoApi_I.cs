using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public interface FromMethodInfoApi_I<TContainer> : FromMethodInfoApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new DefinitionApi_I<TContainer> Definitions { get; set; }

		new ReferenceApi_I<TContainer> References { get; set; }
	}
}

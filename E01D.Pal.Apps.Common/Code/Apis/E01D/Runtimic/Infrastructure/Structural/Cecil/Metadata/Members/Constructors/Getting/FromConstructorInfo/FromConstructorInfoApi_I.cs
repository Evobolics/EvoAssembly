using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo
{
	public interface FromConstructorInfoApi_I<TContainer> : FromConstructorInfoApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new DefinitionApi_I<TContainer> Definitions { get; set; }

		new ReferenceApi_I<TContainer> References { get; set; }
	}
}

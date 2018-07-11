using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting
{
	public interface GettingApi_I<TContainer> : GettingApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new FromConstructorInfoApi_I<TContainer> FromConstructorInfos { get; set; }
	}
}

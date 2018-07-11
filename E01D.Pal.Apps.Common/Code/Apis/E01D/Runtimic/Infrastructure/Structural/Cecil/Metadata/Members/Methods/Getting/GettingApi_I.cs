using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting.FromMethodInfo;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting
{
	public interface GettingApi_I<TContainer> : GettingApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new FromMethodInfoApi_I<TContainer> FromMethodInfos { get; set; }
	}
}

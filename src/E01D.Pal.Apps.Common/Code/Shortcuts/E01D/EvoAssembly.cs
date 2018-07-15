using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Domains.E01D;

namespace Root.Code.Shortcuts.E01D
{
	public static class EvoAssembly
	{
		public static RuntimicContainer CreateContainer()
		{
			return XCommonAppPal.Api.Containment.CreateContainer<RuntimicContainer>(false);
		}
	}
}

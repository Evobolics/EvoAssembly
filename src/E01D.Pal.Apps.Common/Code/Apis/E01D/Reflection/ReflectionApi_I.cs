using System.Reflection;

namespace Root.Code.Apis.E01D.Reflection
{
	public interface ReflectionApi_I
	{
		Assembly FindAssemblyInAppDomain(string fullAssemblyName);
	}
}

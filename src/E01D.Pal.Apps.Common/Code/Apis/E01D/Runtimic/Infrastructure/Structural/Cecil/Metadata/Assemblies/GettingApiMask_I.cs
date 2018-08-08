using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public interface GettingApiMask_I
	{
		

		StructuralAssemblyNode Get(RuntimicSystemModel runtimicModel, string resolutionName);

		bool Get(RuntimicSystemModel runtimicModel, string resolutionName, out StructuralAssemblyNode node);
	}
}

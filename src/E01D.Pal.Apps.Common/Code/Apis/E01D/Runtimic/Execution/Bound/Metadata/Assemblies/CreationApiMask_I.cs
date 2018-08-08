using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
	public interface CreationApiMask_I
	{

		BoundAssemblyMask_I CreateAssemblyEntry(RuntimicSystemModel runtimicSystem, BoundAssemblyNode assemblyNode);

	}
}

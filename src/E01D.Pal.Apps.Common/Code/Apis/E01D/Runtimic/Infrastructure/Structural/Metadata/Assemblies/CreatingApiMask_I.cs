using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Assemblies
{
	public interface CreatingApiMask_I
	{
		

		StructuralAssemblyNode Create(RuntimicSystemModel model, AssemblyDefinition assembly);

		
	}
}

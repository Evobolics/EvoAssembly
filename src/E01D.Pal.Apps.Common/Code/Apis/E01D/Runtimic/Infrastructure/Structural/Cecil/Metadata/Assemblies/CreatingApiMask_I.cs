using System.IO;
using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public interface CreatingApiMask_I
	{
		AssemblyDefinition Create(InfrastructureRuntimicModelMask_I semanticModel, Assembly assembly);

		AssemblyDefinition Create(InfrastructureRuntimicModelMask_I semanticModel, Stream stream);
	}
}

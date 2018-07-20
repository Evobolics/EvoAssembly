using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Metadata
{
	public class MetadataApi<TContainer> : BoundApiNode<TContainer>, MetadataApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void AddAssemblyDefinition(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
		{
			Infrastructure.Models.Structural.AddAssemblyDefinition(semanticModel, assemblyDefinition);
		}

		public void Ensure(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition typeDefinition)
		{
			Infrastructure.Models.Structural.Ensure(semanticModel, assemblyDefinition, module, typeDefinition);
		}
	}
}

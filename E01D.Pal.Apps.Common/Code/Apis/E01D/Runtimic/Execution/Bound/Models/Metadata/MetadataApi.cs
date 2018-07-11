using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models.Metadata
{
	public class MetadataApi<TContainer> : BindingApiNode<TContainer>, MetadataApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void AddAssemblyDefinition(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
		{
			Infrastructure.Models.Structural.AddAssemblyDefinition(semanticModel, assemblyDefinition);
		}

		public void Ensure(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition typeDefinition)
		{
			Infrastructure.Models.Structural.Ensure(semanticModel, assemblyDefinition, module, typeDefinition);
		}
	}
}

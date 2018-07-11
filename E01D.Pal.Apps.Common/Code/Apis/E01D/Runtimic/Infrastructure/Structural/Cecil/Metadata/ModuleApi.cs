using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public class ModuleApi<TContainer> : SemanticApiNode<TContainer>, ModuleApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Load(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
		{
			foreach (var moduleDefinition in assemblyDefinition.Modules)
			{
				Infrastructure.Structural.Cecil.Metadata.Members.Types.Load(semanticModel, moduleDefinition);
			}
		}
	}
}

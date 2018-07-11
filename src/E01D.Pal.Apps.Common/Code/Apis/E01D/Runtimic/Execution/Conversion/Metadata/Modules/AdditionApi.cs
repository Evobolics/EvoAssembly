using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
	public class AdditionApi<TContainer> : ConversionApiNode<TContainer>, AdditionApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public void AddModule(SemanticModuleMask_I moduleEntry)
		{
			var assemblyEntry = moduleEntry.Assembly;

			assemblyEntry.Modules.Add(moduleEntry.Name, moduleEntry);
		}
	}
}

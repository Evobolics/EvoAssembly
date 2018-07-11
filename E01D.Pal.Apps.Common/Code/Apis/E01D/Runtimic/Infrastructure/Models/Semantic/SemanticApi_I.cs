using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public interface SemanticApi_I<TContainer> : SemanticApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new ModelAssembliesApi_I<TContainer> Assemblies { get; set; }

		new ModelModulesApi_I<TContainer> Modules { get; set; }

		new ModelTypesApi_I<TContainer> Types { get; set; }
	}
}

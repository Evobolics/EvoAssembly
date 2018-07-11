using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public class SemanticApi<TContainer> : SemanticApiNode<TContainer>, SemanticApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public ModelAssembliesApi_I<TContainer> Assemblies { get; set; }

		public ModelModulesApi_I<TContainer> Modules { get; set; }

		public new ModelTypesApi_I<TContainer> Types { get; set; }

		ModelAssembliesApiMask_I SemanticApiMask_I.Assemblies => Assemblies;

		ModelModulesApiMask_I SemanticApiMask_I.Modules => Modules;

		ModelTypesApiMask_I SemanticApiMask_I.Types => Types;
	}
}

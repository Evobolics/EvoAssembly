using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public interface SemanticApiMask_I
	{
		ModelAssembliesApiMask_I Assemblies { get; }

		ModelModulesApiMask_I Modules { get; }

		ModelTypesApiMask_I Types { get; }
	}
}

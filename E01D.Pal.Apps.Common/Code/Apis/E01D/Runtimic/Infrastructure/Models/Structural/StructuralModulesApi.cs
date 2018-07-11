using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural
{
	class StructuralModulesApi<TContainer> : SemanticApiNode<TContainer>, StructuralModulesApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}

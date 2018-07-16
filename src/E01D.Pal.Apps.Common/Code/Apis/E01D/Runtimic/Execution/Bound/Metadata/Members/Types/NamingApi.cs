using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public class NamingApi<TContainer> : BoundApiNode<TContainer>, NamingApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public string GetResolutionName(TypeReference input)
		{
			return Infrastructure.Structural.Naming.GetResolutionName(input);
		}

		public string GetResolutionName(System.Type input)
		{
			return Infrastructure.Structural.Naming.GetResolutionName(input);
		}

		public string GetResolutionName(SemanticTypeMask_I input)
	    {
		    return Infrastructure.Semantic.Metadata.Members.Types.Naming.GetResolutionName(input);
		}
    }
}

using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
	public class NamingApi<TContainer> : BoundApiNode<TContainer>, NamingApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    

	    

	    public string GetResolutionName(SemanticTypeMask_I input)
	    {
		    var assemblyQualifiedName = input.AssemblyQualifiedName;

		    return Infrastructure.Structural.Naming.AdjustResolutionName(assemblyQualifiedName);
	    }


	    
	}
}

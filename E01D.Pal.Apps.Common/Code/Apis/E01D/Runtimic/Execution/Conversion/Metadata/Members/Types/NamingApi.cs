using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class NamingApi<TContainer> : ConversionApiNode<TContainer>, NamingApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
		public string GetResolutionName(TypeReference input)
		{
			return Binding.Metadata.Members.Types.Naming.GetResolutionName(input);
			
		}

        public string GetResolutionName(System.Type input)
        {
	        return Binding.Metadata.Members.Types.Naming.GetResolutionName(input);
        }

	    public string GetResolutionName(SemanticTypeMask_I input)
	    {
		    return Binding.Metadata.Members.Types.Naming.GetResolutionName(input);

		}
    }
}

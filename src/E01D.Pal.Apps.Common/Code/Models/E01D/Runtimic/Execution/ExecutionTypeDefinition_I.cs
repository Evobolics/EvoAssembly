using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution
{
	public interface ExecutionTypeDefinition_I: ExecutionTypeDefinitionMask_I
    {
		
	    new BoundTypeDefinitionMask_I BaseType { get; set; }
		new TypeReference SourceTypeReference { get; set; }
		new string ResolutionName { get; set; }
		new System.Type UnderlyingType { get; set; }

	}
}

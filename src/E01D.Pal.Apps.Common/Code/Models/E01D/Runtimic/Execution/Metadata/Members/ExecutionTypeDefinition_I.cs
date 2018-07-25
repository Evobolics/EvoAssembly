using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{

	public interface ExecutionTypeDefinition_I: ExecutionType_I, ExecutionTypeDefinitionMask_I
    {
		
	    new BoundTypeDefinitionMask_I BaseType { get; set; }
		new TypeReference SourceTypeReference { get; set; }
		new string ResolutionName { get; set; }
		new System.Type UnderlyingType { get; set; }

	}
}

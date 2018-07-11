using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundGenericTypeDefinitionMask_I: BoundTypeDefinitionMask_I, BoundTypeDefinitionWithTypeParametersMask_I, SemanticGenericTypeDefinitionMask_I
    {
	    new BoundGenericTypeDefinitionMask_I Blueprint { get;  }

		new BoundGenericTypeDefinitionGenericTypeArgumentsMask_I TypeArguments { get;  }
	}
}

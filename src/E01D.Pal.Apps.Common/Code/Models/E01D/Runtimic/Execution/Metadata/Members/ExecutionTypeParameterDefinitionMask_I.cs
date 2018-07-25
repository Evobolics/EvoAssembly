using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
    public interface ExecutionTypeParameterDefinitionMask_I: SemanticGenericParameterTypeDefinitionMask_I
    {
		ExecutionClassTypeParameterConstraintMask_I BaseTypeConstraint { get;  }

		List<ExecutionInterfaceTypeParameterConstraintMask_I> InterfaceTypeConstraints { get;  }
	}
}

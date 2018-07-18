using System.Collections.Generic;
using System.Reflection.Emit;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedGenericParameterTypeDefinition_I: ConvertedGenericParameterTypeDefinitionMask_I
    {
        new GenericTypeParameterBuilder Builder { get; set; }

        new GenericParameter Definition { get; set; }
        new System.Type UnderlyingType { get; set; }

	    ConvertedClassTypeParameterConstraint BaseTypeConstraint { get; set; }

	    List<ConvertedInterfaceTypeParameterConstraint> InterfaceTypeConstraints { get; set; } 
	}
}

using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Fields;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.TypeArguments;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members
{
    public interface MemberApiMask_I
    {
        ConstructorApiMask_I Constructors { get;  }

        EventApiMask_I Events { get;  }

        FieldApiMask_I Fields { get;  }

        InstructionApiMask_I Instructions { get;  }

        LocalApiMask_I Locals { get;  }

        MethodApiMask_I Methods { get;  }

       

        ParameterApiMask_I Parameters { get;  }

        PropertyApiMask_I Properties { get;  }

	    TypeArgumentApiMask_I TypeArguments { get; }

	    Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.TypeParameters.TypeParameterApiMask_I TypeParameters { get; }

        TypeApiMask_I Types { get;  }
        BoundTypeDefinitionMask_I GetDeclaringType(InfrastructureModelMask_I conversionModel, MemberReference memberReference);
    }
}

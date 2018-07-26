using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Events;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeArguments;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Parameters;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using TypeParameterApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeParameters.TypeParameterApiMask_I;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members
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

        RoutineApiMask_I Routines { get; }

	    TypeArgumentApiMask_I TypeArguments { get; }

		TypeParameterApiMask_I TypeParameters { get; }

        TypeApiMask_I Types { get;  }

	    bool GetMemberInfo(ILConversion conversion, ConvertedTypeDefinitionMask_I typeBeingBuilt, ConvertedRoutine routineBeingBuilt,

			MethodReference methodReference, out MemberInfo memberInfo);

		BoundTypeDefinitionMask_I GetDeclaringType(ILConversion conversion, MemberReference memberReference);
    }
}



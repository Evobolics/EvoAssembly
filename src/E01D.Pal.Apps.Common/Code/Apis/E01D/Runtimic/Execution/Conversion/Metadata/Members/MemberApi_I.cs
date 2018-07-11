using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Events;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Parameters;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface MemberApi_I<TContainer>:MemberApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new ConstructorApi_I<TContainer> Constructors { get; set; }

        new EventApi_I<TContainer> Events { get; set; }

        new FieldApi_I<TContainer> Fields { get; set; }

        new InstructionApi_I<TContainer> Instructions { get; set; }

        new LocalApi_I<TContainer> Locals { get; set; }

        new MethodApi_I<TContainer> Methods { get; set; }

        new ParameterApi_I<TContainer> Parameters { get; set; }

        new PropertyApi_I<TContainer> Properties { get; set; }

        new RoutineApi_I<TContainer> Routines { get; set; }

	    new TypeArguments.TypeArgumentApi_I<TContainer> TypeArguments { get; set; }

		new TypeParameters.TypeParameterApi_I<TContainer> TypeParameters { get; set; }

        new TypeApi_I<TContainer> Types { get; set; }
    }
}

using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Parameters;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members
{
	public interface MemberApi_I<TContainer> : MemberApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new ConstructorApi_I<TContainer> Constructors { get; set; }

		new FieldApi_I<TContainer> Fields { get; set; }

		new GenericParameterApi_I<TContainer> GenericParameters { get; set; }

		new MethodApi_I<TContainer> Methods { get; set; }

		new ParameterApi_I<TContainer> Parameters { get; set; }

		new TypeApi_I<TContainer> Types { get; set; }
	}
}

using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Parameters;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members
{
	public interface MemberApiMask_I
	{
		ConstructorApiMask_I Constructors { get; }

		FieldApiMask_I Fields { get; }

		GenericParameterApiMask_I GenericParameters { get; }

		MethodApiMask_I Methods { get; }

		ParameterApiMask_I Parameters { get; }

		TypeApiMask_I Types { get; }
	}
}

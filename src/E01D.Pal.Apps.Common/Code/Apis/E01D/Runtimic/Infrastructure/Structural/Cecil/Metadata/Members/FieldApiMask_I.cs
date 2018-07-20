using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members
{
	public interface FieldApiMask_I
	{
		System.Reflection.FieldAttributes GetFieldAttributes(FieldDefinition fieldDefinition);
	}
}

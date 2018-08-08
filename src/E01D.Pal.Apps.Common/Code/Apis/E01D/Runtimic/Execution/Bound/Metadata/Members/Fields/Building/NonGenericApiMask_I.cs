using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields.Building
{
	public interface NonGenericApiMask_I
	{
		void BuildFields(RuntimicSystemModel semanticModel, BoundTypeDefinition_I input);

		void BuildField(RuntimicSystemModel semanticModel, BoundTypeDefinitionWithFields_I typeWithFields,
			FieldDefinition field, FieldInfo fieldInfo);
	}
}

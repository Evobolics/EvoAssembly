using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Fields.Building
{
	public interface NonGenericApiMask_I
	{
		void BuildFields(InfrastructureModelMask_I semanticModel, BoundTypeDefinition_I input);

		void BuildField(InfrastructureModelMask_I semanticModel, BoundTypeDefinitionWithFields_I typeWithFields,
			FieldDefinition field, FieldInfo fieldInfo);
	}
}

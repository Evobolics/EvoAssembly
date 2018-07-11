using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Getting
{
    public interface GettingApiMask_I
    {
	    FieldInfo[] GetFieldsFromCollection(BoundGenericTypeDefinitionMask_I inputBlueprint);

	    BoundFieldDefinitionMask_I GetBoundField(BoundTypeDefinitionMask_I converted, string namedArgumentName);
	}
}

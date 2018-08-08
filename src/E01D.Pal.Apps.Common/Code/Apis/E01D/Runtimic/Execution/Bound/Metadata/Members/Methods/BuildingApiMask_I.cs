using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public interface BuildingApiMask_I
    {
		void BuildMethods(RuntimicSystemModel model, BoundTypeDefinition_I input);

	    BoundMethod BuildMethod(RuntimicSystemModel model, BoundTypeDefinition_I input, MethodInfo method, MethodReference methodReference);

	    void BuildMethodsForGenericInstance(RuntimicSystemModel model, BoundGenericTypeDefinition_I input);


    }
}

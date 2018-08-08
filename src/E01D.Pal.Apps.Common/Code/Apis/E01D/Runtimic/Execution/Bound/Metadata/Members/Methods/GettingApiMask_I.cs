using System.Collections.Generic;
using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public interface GettingApiMask_I
    {
	    SemanticMethodMask_I FindMethodByDefinition(RuntimicSystemModel model,
		    BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods, MethodDefinition methodDefinition);

	    List<BoundMethodDefinitionMask_I> GetMethods(BoundTypeDefinitionMask_I inputBlueprint);

	    MethodInfo[] GetMethodInfos(BoundTypeDefinitionMask_I inputBlueprint);

	}
}

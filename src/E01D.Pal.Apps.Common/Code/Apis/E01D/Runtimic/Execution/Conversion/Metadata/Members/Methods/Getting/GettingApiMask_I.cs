
using System.Collections.Generic;
using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting.FromMethodReference;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting
{
    public interface GettingApiMask_I
    {
	    

	    FromMethodReferenceApiMask_I FromMethodReference { get; }

	    MethodInfo[] GetMethodInfos(BoundTypeDefinitionMask_I inputBlueprint);

	    List<BoundMethodDefinitionMask_I> GetMethods(BoundTypeDefinitionMask_I inputBlueprint);


	    BoundMethodDefinitionMask_I GetBoundMethod(ILConversionRuntimicModel conversionModel, BoundModuleMask_I module, MethodInfo genericTypeDefinitionMethodInfo);

	    

	    MethodInfo GetMethodInfoOrThrow(ILConversion conversion, ConvertedTypeDefinition_I typeBeingBuilt, MethodReference methodReference);
	    ConvertedMethodMask_I GetMethod(ConvertedTypeDefinition_I convertedType, MethodDefinition propertyDefinitionGetMethod);
    }
}

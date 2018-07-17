using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.CustomAttributes
{
    public interface CustomAttributeApiMask_I
    {
	    void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinition_I converted);
		void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinitionMask_I input, ConvertedEmittedConstructor constructorEntry);
		void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinitionWithEvents_I converted, ConvertedEvent entry);
		void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedField convertedField);
		void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinitionWithMethods_I input, ConvertedBuiltMethod methodEntry);
		void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinitionWithProperties_I convertedType, ConvertedProperty entry);
		void BuildCustomAttributes(ILConversion conversion, ConvertedMethodParameter parameter);
		void BuildCustomAttributes(ILConversion conversion, ParameterBuilder returnParameter, MethodReturnType methodReturnType);
	}
}

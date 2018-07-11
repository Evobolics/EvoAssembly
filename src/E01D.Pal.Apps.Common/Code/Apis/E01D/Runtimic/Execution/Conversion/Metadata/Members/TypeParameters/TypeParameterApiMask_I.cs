using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeParameters
{
    public interface TypeParameterApiMask_I
    {
	    BuildingApiMask_I Building { get; }

		void Add(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, ConvertedGenericParameterTypeDefinition typeParameter);

        void Add(ILConversion conversion, ConvertedGenericParameterTypeDefinitions_I definitions, List<ConvertedGenericParameterTypeDefinition> typeParameters);

        void Clear(ILConversion conversion, ConvertedGenericParameterTypeDefinitions_I convertedTypeTypeParameters);

        ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, string name);

        ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, int position);

        string[] GetNames(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I convertedTypeTypeParameters);

        ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, string name);

        ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, int position);

        
    }
}

using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface TypeParameterApiMask_I
    {
        void Add(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I type, ConvertedGenericParameterTypeDefinition typeParameter);

        void Add(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I type, List<ConvertedGenericParameterTypeDefinition> typeParameters);

        void Clear(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I type);

        ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I type, string name);

        ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I type, int position);

        string[] GetNames(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType);

        ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I type, string name);

        ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I type, int position);


        
    }
}

using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods
{
    public interface TypeParameterApiMask_I
    {
        void Add(ILConversion conversion, ConvertedBuiltMethod method, ConvertedGenericParameterTypeDefinition typeParameter);

        void Add(ILConversion conversion, ConvertedBuiltMethod method, List<ConvertedGenericParameterTypeDefinition> typeParameters);

        void Clear(ILConversion conversion, ConvertedBuiltMethod method);

        ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedBuiltMethod method, string name);

        ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedBuiltMethod method, int position);

        string[] GetNames(ILConversion conversion, ConvertedBuiltMethod method);

        ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedBuiltMethod method, string name);

        ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedBuiltMethod method, int position);
    }
}

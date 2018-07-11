using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods
{
    public class TypeParameterApi<TContainer> : ConversionApiNode<TContainer>, TypeParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void Add(ILConversion conversion, ConvertedBuiltMethod method, ConvertedGenericParameterTypeDefinition typeParameter)
        {
            Members.TypeParameters.Add(conversion, method.TypeParameters, typeParameter);
        }

        public void Add(ILConversion conversion, ConvertedBuiltMethod method, List<ConvertedGenericParameterTypeDefinition> typeParameters)
        {
            Members.TypeParameters.Add(conversion, method.TypeParameters, typeParameters);
        }

        public void Clear(ILConversion conversion, ConvertedBuiltMethod method)
        {
            Members.TypeParameters.Clear(conversion, method.TypeParameters);
        }

        public ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedBuiltMethod method, string name)
        {
            return Members.TypeParameters.Get(conversion, method.TypeParameters, name);
        }

        public ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedBuiltMethod method, int position)
        {
            return Members.TypeParameters.Get(conversion, method.TypeParameters, position);
        }

        public string[] GetNames(ILConversion conversion, ConvertedBuiltMethod method)
        {
            return Members.TypeParameters.GetNames(conversion, method.TypeParameters);
        }

        public ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedBuiltMethod method, string name)
        {
            return Members.TypeParameters.GetOrThrow(conversion, method.TypeParameters, name);
        }

        public ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedBuiltMethod method, int position)
        {
            return Members.TypeParameters.GetOrThrow(conversion, method.TypeParameters, position);
        }
    }
}

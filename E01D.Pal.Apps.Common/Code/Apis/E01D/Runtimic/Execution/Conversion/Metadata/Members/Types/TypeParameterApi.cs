using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public class TypeParameterApi<TContainer> : ConversionApiNode<TContainer>, TypeParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void Add(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType, ConvertedGenericParameterTypeDefinition typeParameter)
        {
	        if (convertedType.AssemblyQualifiedName ==
	            "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.ClassWithGenericFieldAndMethodReference`1, E01D.Pal.Apps.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
	        )
	        {
		        
	        }

            Members.TypeParameters.Add(conversion, convertedType.TypeParameters, typeParameter);
        }

        public void Add(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType, List<ConvertedGenericParameterTypeDefinition> typeParameters)
        {
            Members.TypeParameters.Add(conversion, convertedType.TypeParameters, typeParameters);
        }

        public void Clear(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType)
        {
            Members.TypeParameters.Clear(conversion, convertedType.TypeParameters);
        }

        public ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType, string name)
        {
            return Members.TypeParameters.Get(conversion, convertedType.TypeParameters, name);
        }

        public ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType, int position)
        {
            return Members.TypeParameters.Get(conversion, convertedType.TypeParameters, position);
        }

        public string[] GetNames(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType)
        {
            return Members.TypeParameters.GetNames(conversion, convertedType.TypeParameters);
        }

        public ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType, string name)
        {
            return Members.TypeParameters.GetOrThrow(conversion, convertedType.TypeParameters, name);
        }

        public ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedTypeDefinitionWithTypeParameters_I convertedType, int position)
        {
            return Members.TypeParameters.GetOrThrow(conversion, convertedType.TypeParameters, position);
        }
    }
}

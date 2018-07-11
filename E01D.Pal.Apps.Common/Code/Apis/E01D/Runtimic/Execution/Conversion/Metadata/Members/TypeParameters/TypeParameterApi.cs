using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeParameters
{
    public class TypeParameterApi<TContainer> : ConversionApiNode<TContainer>, TypeParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public BuildingApi_I<TContainer> Building { get; set; }

	    BuildingApiMask_I TypeParameterApiMask_I.Building => Building;

		public void Add(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, ConvertedGenericParameterTypeDefinition typeParameter)
        {
            if (typeParameter.TypeParameterKind == TypeParameterKind.Unknown)
            {
                throw new Exception("Type parameter kind is set to unknown");
            }

            if (typeParameter.Position < 0)
            {
                throw new Exception("Position cannot be a negative number.  Make sure it is set to value greater than or equal to zero when creating the parameter.");
            }

            definitions.ByName.Add(typeParameter.Name, typeParameter);

            definitions.ByPosition.Add(typeParameter.Position, typeParameter);

            definitions.All.Add(typeParameter);
        }

        public void Create()
        {
            
        }

        public void Add(ILConversion conversion, ConvertedGenericParameterTypeDefinitions_I definitions, List<ConvertedGenericParameterTypeDefinition> inputList)
        {
            for (int i =0; i< inputList.Count; i++)
            {
                Add(conversion, definitions, inputList[i]);
            }
        }

        public void Clear(ILConversion conversion, ConvertedGenericParameterTypeDefinitions_I definitions)
        {
            definitions.ByName.Clear();

            definitions.ByPosition.Clear();

            definitions.All.Clear();
        }

        public ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, string name)
        {
            if (definitions.ByName.TryGetValue(name, out SemanticGenericParameterTypeDefinitionMask_I typeParameter))
            {
                return (ConvertedGenericParameterTypeDefinition_I)typeParameter;
            }

            return null;
        }

        public ConvertedGenericParameterTypeDefinition_I Get(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, int position)
        {
            if (definitions.ByPosition.TryGetValue(position, out SemanticGenericParameterTypeDefinitionMask_I typeParameter))
            {
                return (ConvertedGenericParameterTypeDefinition_I)typeParameter;
            }

            return null;
        }

        public string[] GetNames(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions)
        {
            var all = definitions.All;

            string[] nameList = new string[all.Count];

            for (int i = 0; i < all.Count; i++)
            {
                var tp = (ConvertedGenericParameterTypeDefinition)all[i];

                nameList[i] = tp.Name;
            }

            return nameList;
        }

        public ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, string name)
        {
            var result = Get(conversion, definitions, name);

            if (result == null)
            {
                throw new Exception($"Could not find type parameter with name {name}");
            }

            return result;
        }

        public ConvertedGenericParameterTypeDefinition_I GetOrThrow(ILConversion conversion, ConvertedGenericParameterTypeDefinitionsMask_I definitions, int position)
        {
            var result = Get(conversion, definitions, position);

            if (result == null)
            {
                throw new Exception($"Could not find type parameter with position {position}");
            }

            return result;
        }
    }
}

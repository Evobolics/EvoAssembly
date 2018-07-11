using System.Linq;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Baking
{
    public class BakingApi<TContainer> : ConversionApiNode<TContainer>, BakingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        //public void BakeTypes(ILConversion conversion, List<ConvertedTypeDefinition_I> list)
        //{
        //    // NEED TO GO THROUGH ALL;
        //    // * Base Types
        //    // * Interface Types
        //    // * Nested Types
        //    // * Generic Type Parameter Constraints

        //    // AND MAKE SURE THEY ARE BAKED FIRST

        //    //for (int i = 0; i < list.Count; i++)
        //    //{
        //    //    var input = list[i];

        //    //    Bake(conversion, input);
        //    //}
        //}

        

	   

	    

        private void EnsureGenericIsReadyForBaking(ILConversion conversion, ConvertedTypeDefinition_I input)
        {
            if (!input.IsGeneric()) return;

            if (!(input is ConvertedGenericTypeDefinition_I convertedGeneric)) throw new System.Exception("Expected at least a converted generic.");

            if (convertedGeneric.HasTypeArguments())
            {
                for (int i = 0; i < convertedGeneric.TypeArguments.All.Count; i++)
                {
                    var typeArgument = convertedGeneric.TypeArguments.All[i];

                   

                    //Bake(conversion, convertedTypeArgument);
                }
            }

            if (!convertedGeneric.HasTypeParameters()) return;
            
            for (int i = 0; i < convertedGeneric.TypeParameters.All.Count; i++)
            {
                var typeParameter = (ConvertedGenericParameterTypeDefinition)convertedGeneric.TypeParameters.All[i];

                if (typeParameter.BaseTypeConstraint != null)
                {
                    var classConstraint = typeParameter.BaseTypeConstraint.Class;

                    
                }

                if (typeParameter.InterfaceTypeConstraints == null) continue;

                for (int j = 0; j < typeParameter.InterfaceTypeConstraints.Count; j++)
                {
                    var interfaceTypeConstraint = typeParameter.InterfaceTypeConstraints[j];

                    if (interfaceTypeConstraint.Interface == null) continue;

                    var interfaceConstraint = interfaceTypeConstraint.Interface;

                    
                }
            }
            
        }

        private void EnsureNestedTypesAreReadyForBaking(ILConversion conversion, ConvertedTypeDefinition_I input)
        {
            var nestedTypes = input.NestedTypes.Values.ToList();

            for (int i = 0; i < nestedTypes.Count; i++)
            {
                var nestedType = nestedTypes[i];

                
            }
        }

        private void EnsureInterfacesAreReadyForBaking(ILConversion conversion, ConvertedTypeDefinition_I input)
        {
            if (!(input is SemanticTypeWithInterfaceTypeList_I typeWithInterfaceTypeList)) return;

            var interfaces = typeWithInterfaceTypeList.Interfaces.ByResolutionName.Values.ToList();

            for (int i = 0; i < interfaces.Count; i++)
            {
                var interfaceType = interfaces[i];

                
            }
        }

        private void EnsureBaseTypeIsReadyForBaking(ILConversion conversion, ConvertedTypeDefinition_I input)
        {
            
        }

	    //EnsureBaseTypeIsReadyForBaking(conversion, input);

	    //EnsureInterfacesAreReadyForBaking(conversion, input);

	    //EnsureNestedTypesAreReadyForBaking(conversion, input);

	    //EnsureGenericIsReadyForBaking(conversion, input);

	    //input.UnderlyingType = input.TypeBuilder.CreateType();
	}
}

using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public class AssignmentApi<TContainer> : ConversionApiNode<TContainer>, AssignmentApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
       

        public void AssignInterfaces(ConvertedTypeDefinition target, List<SemanticTypeMask_I> interfaces)
        {
            if (target.SupportsInterfaceTypeList() && target is SemanticTypeWithInterfaceTypeList_I tewii)
            {
                tewii.Interfaces = new SemanticTypeDefinitionInterfaces();

                for (var i = 0; i < interfaces.Count; i++)
                {
                    var item = interfaces[i];

	                var resolutionName = Types.Naming.GetResolutionName(item);

                    tewii.Interfaces.ByResolutionName.Add(resolutionName, (SemanticInterfaceTypeMask_I) item);

                    Types.Dependencies.Add(target, item);
                }
            }
        }

        

        

        public void AssignTypeParameters(ILConversion conversion, ConvertedTypeDefinition type, List<ConvertedGenericParameterTypeDefinition> typeParameters)
        {
            if (!type.IsGeneric()) return;

            ConvertedTypeDefinitionWithTypeParameters_I generic = (ConvertedTypeDefinitionWithTypeParameters_I)type;

            Types.TypeParameters.Clear(conversion, generic);

            Types.TypeParameters.Add(conversion, generic, typeParameters);
        }

        public void AssignGenericBlueprint(ConvertedTypeDefinition createdType, SemanticTypeDefinitionMask_I genericBlueprint)
        {
            
        }

        public void AssignNestedTypes(ConvertedTypeDefinition createdType, Dictionary<string, SemanticTypeMask_I> nestedTypes)
        {
            
        }
    }
}

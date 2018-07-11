using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Typal.Ensuring.Cecil
{
    public class AssignmentApi<TContainer> : ConversionApiNode<TContainer>, AssignmentApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void AssignGatheredTypes(ConvertedTypeDefinitionMask_I target, SemanticTypeMask_I baseType, List<SemanticTypeMask_I> interfaces, List<SemanticTypeMask_I> nestedTypes, SemanticTypeMask_I genericBlueprint, SemanticTypeMask_I[] typeArguments, SemanticTypeParameterMask_I[] typeParameters)
        {
            if (target.SupportsBaseType() && target is BoundTypeWithBaseType_I chbt)
            {
                chbt.BaseType = baseType;

                if (chbt.BaseType != null)
                {
                    Types.Dependencies.Add(target, chbt.BaseType);
                }
            }

            if (target.SupportsInterfaceTypeList() && target is SemanticTypeWithInterfaceTypeList_I tewii)
            {
                tewii.Interfaces = new SemanticTypeDefinitionInterfaces();

                for (var i = 0; i < interfaces.Count; i++)
                {
                    var item = interfaces[i];

                    tewii.Interfaces.ByResolutionName.Add(item.FullName, (SemanticInterfaceTypeMask_I)item);

                    Types.Dependencies.Add(target, item);
                }
            }

            if (nestedTypes != null && nestedTypes.Count > 0)
            {
                for (var i = 0; i < nestedTypes.Count; i++)
                {
                    var nestedType = nestedTypes[i];

                    var btwdt = (ConvertedMemberWithDeclaringType_I)nestedType;

                    btwdt.DeclaringType = target;

                    Types.Dependencies.Add(target, nestedType);

                    target.NestedTypes.Add(nestedType.ResolutionName(), nestedType);
                }
            }
        }
    }
}

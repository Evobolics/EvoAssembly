using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions
{
	public class InstructionApi<TContainer> : ConversionApiNode<TContainer>, InstructionApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {

        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I InstructionApiMask_I.Building => Building;

        public TypeScanningApi_I<TContainer> TypeScanning { get; set; }

        public bool GetGenericParameterType(ILConversion conversion, ConvertedTypeDefinitionMask_I input, ConvertedRoutine routine, GenericParameter genericParameter, out System.Type type)
        {
            switch (genericParameter.Type)
            {
                case GenericParameterType.Method:
                {
                    var method = (ConvertedBuiltMethod) routine;

                    var operandDeclaringType = method.DeclaringType;

                    if ((operandDeclaringType is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        type = null;
                        return false;
                    }

                    type = method.TypeParameters.Builders[genericParameter.Position];

                    return true;
                }
                case GenericParameterType.Type:
                {
                    var declaringType = genericParameter.DeclaringType;

                    var boundType = Execution.Types.Ensuring.EnsureBound(conversion, declaringType);

                    if ((boundType is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        type = null;
                        return false;
                    }

                    var x = (ConvertedTypeDefinitionWithTypeParameters_I)boundType;

                    type = x.TypeParameters.Builders[genericParameter.Position];

                    return true;
                }
                default:
                {
                    throw new System.Exception("Not a method or a type.");
                }
            }
        }

        TypeScanningApiMask_I InstructionApiMask_I.TypeScanning => TypeScanning;
    }
}

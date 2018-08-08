using System;
using System.Reflection.Emit;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines
{
    public interface BuildingApiMask_I
    {
        void BuildRoutines(ILConversion conversion, ConvertedTypeDefinitionMask_I input);

        void BuildRoutine(ILConversion conversion, ConvertedTypeDefinitionMask_I input, MethodDefinition method);


        Type[] CreateParameters(ILConversion conversion, ConvertedRoutine routine);

        Type SetReturnType(ILConversion conversion, ConvertedRoutine routine);

        void CreateParameterBuilders(ILConversion conversion, ConvertedRoutine routine);

        ParameterBuilder CreateParameterBuilder(ILConversion conversion, ConvertedRoutine routine,
            ConvertedRoutineParameter parameter);
    }
}
